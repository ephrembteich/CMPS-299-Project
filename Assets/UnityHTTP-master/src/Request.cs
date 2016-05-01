using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using Assets.lib;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Assets.src
{
	public class HttpException : Exception
	{
		public HttpException(string message) : base(message)
		{
		}
	}

	public enum RequestState
	{
		Waiting,
		Reading,
		Done
	}

	public class Request
	{
		public static bool LogAllRequests = false;
		public static bool VerboseLogging = false;
		public static string UnityVersion = Application.unityVersion;
		public static string OperatingSystem = SystemInfo.operatingSystem;
		public static byte[] Eol = {(byte) '\r', (byte) '\n'};
		private static readonly Dictionary<string, string> Etags = new Dictionary<string, string>();
		private static readonly string[] Sizes = {"B", "KB", "MB", "GB"};
		private readonly Dictionary<string, List<string>> _headers = new Dictionary<string, List<string>>();
		public bool AcceptGzip = true;
		public int BufferSize = 4*1024;
		public Stream ByteStream;
		public Action<Request> CompletedCallback;
		public CookieJar CookieJar = CookieJar.Instance;
		public Exception Exception;
		public bool IsDone;
		public int MaximumRetryCount = 8;
		public string Method = "GET";
		public string Protocol = "HTTP/1.1";
		public Response Response;
		public long ResponseTime; // in milliseconds
		public RequestState State = RequestState.Waiting;
		public bool Synchronous = false;
		public Uri Uri;
		public bool UseCache;

		public Request(string method, string uri)
		{
			this.Method = method;
			this.Uri = new Uri(uri);
		}

		public Request(string method, string uri, bool useCache)
		{
			this.Method = method;
			this.Uri = new Uri(uri);
			this.UseCache = useCache;
		}

		public Request(string method, string uri, byte[] bytes)
		{
			this.Method = method;
			this.Uri = new Uri(uri);
			ByteStream = new MemoryStream(bytes);
		}

		public Request(string method, string uri, StreamedWwwForm form)
		{
			this.Method = method;
			this.Uri = new Uri(uri);
			ByteStream = form.Stream;
			foreach (DictionaryEntry entry in form.Headers)
			{
				AddHeader((string) entry.Key, (string) entry.Value);
			}
		}

		public Request(string method, string uri, WWWForm form)
		{
			this.Method = method;
			this.Uri = new Uri(uri);
			ByteStream = new MemoryStream(form.data);
#if UNITY_5
			foreach (var entry in form.headers)
			{
				AddHeader(entry.Key, entry.Value);
			}
#else
            foreach ( DictionaryEntry entry in form.headers )
            {
                this.AddHeader( (string)entry.Key, (string)entry.Value );
            }
#endif
		}

		public Request(string method, string uri, Hashtable data)
		{
			this.Method = method;
			this.Uri = new Uri(uri);
			ByteStream = new MemoryStream(Encoding.UTF8.GetBytes(Json.JsonEncode(data)));
			AddHeader("Content-Type", "application/json");
		}

		public string Text
		{
			set { ByteStream = new MemoryStream(Encoding.UTF8.GetBytes(value)); }
		}

		public void AddHeader(string name, string value)
		{
			name = name.ToLower().Trim();
			value = value.Trim();
			if (!_headers.ContainsKey(name))
				_headers[name] = new List<string>();
			_headers[name].Add(value);
		}

		public string GetHeader(string name)
		{
			name = name.ToLower().Trim();
			if (!_headers.ContainsKey(name))
				return "";
			return _headers[name][0];
		}

		public List<string> GetHeaders()
		{
			var result = new List<string>();
			foreach (var name in _headers.Keys)
			{
				foreach (var value in _headers[name])
				{
					result.Add(name + ": " + value);
				}
			}

			return result;
		}

		public List<string> GetHeaders(string name)
		{
			name = name.ToLower().Trim();
			if (!_headers.ContainsKey(name))
				_headers[name] = new List<string>();
			return _headers[name];
		}

		public void SetHeader(string name, string value)
		{
			name = name.ToLower().Trim();
			value = value.Trim();
			if (!_headers.ContainsKey(name))
				_headers[name] = new List<string>();
			_headers[name].Clear();
			_headers[name].TrimExcess();
			_headers[name].Add(value);
		}

		private void GetResponse()
		{
			var curcall = new Stopwatch();
			curcall.Start();
			try
			{
				var retry = 0;
				while (++retry < MaximumRetryCount)
				{
					if (UseCache)
					{
						var etag = "";
						if (Etags.TryGetValue(Uri.AbsoluteUri, out etag))
						{
							SetHeader("If-None-Match", etag);
						}
					}

					SetHeader("Host", Uri.Host);

					var client = new TcpClient();
					client.Connect(Uri.Host, Uri.Port);
					using (var stream = client.GetStream())
					{
						var ostream = stream as Stream;
						if (Uri.Scheme.ToLower() == "https")
						{
							ostream = new SslStream(stream, false, ValidateServerCertificate);
							try
							{
								var ssl = ostream as SslStream;
								ssl.AuthenticateAsClient(Uri.Host);
							}
							catch (Exception e)
							{
#if !UNITY_EDITOR
                                Console.WriteLine ("SSL authentication failed.");
                                Console.WriteLine (e);
#else
								Debug.LogError("SSL authentication failed.");
								Debug.LogException(e);
#endif
								return;
							}
						}
						WriteToStream(ostream);
						Response = new Response();
						Response.Request = this;
						State = RequestState.Reading;
						Response.ReadFromStream(ostream);
					}
					client.Close();

					switch (Response.Status)
					{
						case 307:
						case 302:
						case 301:
							Uri = new Uri(Response.GetHeader("Location"));
							continue;
						default:
							retry = MaximumRetryCount;
							break;
					}
				}
				if (UseCache)
				{
					var etag = Response.GetHeader("etag");
					if (etag.Length > 0)
						Etags[Uri.AbsoluteUri] = etag;
				}
			}
			catch (Exception e)
			{
#if !UNITY_EDITOR
                Console.WriteLine ("Unhandled Exception, aborting request.");
                Console.WriteLine (e);
#else
				Debug.LogError("Unhandled Exception, aborting request.");
				Debug.LogException(e);
#endif
				Exception = e;
				Response = null;
			}

			State = RequestState.Done;
			IsDone = true;
			ResponseTime = curcall.ElapsedMilliseconds;

			if (ByteStream != null)
			{
				ByteStream.Close();
			}

			if (CompletedCallback != null)
			{
				if (Synchronous)
				{
					CompletedCallback(this);
				}
				else
				{
					// we have to use this dispatcher to avoid executing the callback inside this worker thread
					ResponseCallbackDispatcher.Singleton.Requests.Enqueue(this);
				}
			}

			if (LogAllRequests)
			{
#if !UNITY_EDITOR
                System.Console.WriteLine("NET: " + InfoString( VerboseLogging ));
#else
				if (Response != null && Response.Status >= 200 && Response.Status < 300)
				{
					Debug.Log(InfoString(VerboseLogging));
				}
				else if (Response != null && Response.Status >= 400)
				{
					Debug.LogError(InfoString(VerboseLogging));
				}
				else
				{
					Debug.LogWarning(InfoString(VerboseLogging));
				}
#endif
			}
		}

		public virtual void Send(Action<Request> callback = null)
		{
			if (!Synchronous && callback != null && ResponseCallbackDispatcher.Singleton == null)
			{
				ResponseCallbackDispatcher.Init();
			}

			CompletedCallback = callback;

			IsDone = false;
			State = RequestState.Waiting;
			if (AcceptGzip)
			{
				SetHeader("Accept-Encoding", "gzip");
			}

			if (CookieJar != null)
			{
				var cookies = CookieJar.GetCookies(new CookieAccessInfo(Uri.Host, Uri.AbsolutePath));
				var cookieString = GetHeader("cookie");
				for (var cookieIndex = 0; cookieIndex < cookies.Count; ++cookieIndex)
				{
					if (cookieString.Length > 0 && cookieString[cookieString.Length - 1] != ';')
					{
						cookieString += ';';
					}
					cookieString += cookies[cookieIndex].Name + '=' + cookies[cookieIndex].Value + ';';
				}
				SetHeader("cookie", cookieString);
			}

			if (ByteStream != null && ByteStream.Length > 0 && GetHeader("Content-Length") == "")
			{
				SetHeader("Content-Length", ByteStream.Length.ToString());
			}

			if (GetHeader("User-Agent") == "")
			{
				try
				{
					SetHeader("User-Agent", "UnityWeb/1.0 (Unity " + UnityVersion + "; " + OperatingSystem + ")");
				}
				catch (Exception)
				{
					SetHeader("User-Agent", "UnityWeb/1.0");
				}
			}

			if (GetHeader("Connection") == "")
			{
				SetHeader("Connection", "close");
			}

			// Basic Authorization
			if (!String.IsNullOrEmpty(Uri.UserInfo))
			{
				SetHeader("Authorization", "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes(Uri.UserInfo)));
			}

			if (Synchronous)
			{
				GetResponse();
			}
			else
			{
				ThreadPool.QueueUserWorkItem(delegate { GetResponse(); });
			}
		}

		public static bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain,
			SslPolicyErrors sslPolicyErrors)
		{
#if !UNITY_EDITOR
            System.Console.WriteLine( "NET: SSL Cert: " + sslPolicyErrors.ToString() );
#else
			Debug.LogWarning("SSL Cert Error: " + sslPolicyErrors);
#endif
			return true;
		}

		private void WriteToStream(Stream outputStream)
		{
			var stream = new BinaryWriter(outputStream);
			stream.Write(Encoding.ASCII.GetBytes(Method.ToUpper() + " " + Uri.PathAndQuery + " " + Protocol));
			stream.Write(Eol);

			foreach (var name in _headers.Keys)
			{
				foreach (var value in _headers[name])
				{
					stream.Write(Encoding.ASCII.GetBytes(name));
					stream.Write(':');
					stream.Write(Encoding.ASCII.GetBytes(value));
					stream.Write(Eol);
				}
			}

			stream.Write(Eol);

			if (ByteStream == null)
			{
				return;
			}

			var numBytesToRead = ByteStream.Length;
			var buffer = new byte[BufferSize];
			while (numBytesToRead > 0)
			{
				var readed = ByteStream.Read(buffer, 0, BufferSize);
				stream.Write(buffer, 0, readed);
				numBytesToRead -= readed;
			}
		}

		public string InfoString(bool verbose)
		{
			var status = IsDone && Response != null ? Response.Status.ToString() : "---";
			var message = IsDone && Response != null ? Response.Message : "Unknown";
			double size = IsDone && Response != null && Response.Bytes != null ? Response.Bytes.Length : 0.0f;

			var order = 0;
			while (size >= 1024.0f && order + 1 < Sizes.Length)
			{
				++order;
				size /= 1024.0f;
			}

			var sizeString = String.Format("{0:0.##}{1}", size, Sizes[order]);

			var result = Uri + " [ " + Method.ToUpper() + " ] [ " + status + " " + message + " ] [ " + sizeString + " ] [ " +
			             ResponseTime + "ms ]";

			if (verbose && Response != null)
			{
				result += "\n\nRequest Headers:\n\n" + String.Join("\n", GetHeaders().ToArray());
				result += "\n\nResponse Headers:\n\n" + String.Join("\n", Response.GetHeaders().ToArray());

				if (Response.Text != null)
				{
					result += "\n\nResponse Body:\n" + Response.Text;
				}
			}

			return result;
		}
	}
}