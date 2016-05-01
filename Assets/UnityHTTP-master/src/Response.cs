using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using Assets.lib;
using Ionic.Zlib;

namespace Assets.src
{
	public class Response
	{
		private readonly Dictionary<string, List<string>> _headers = new Dictionary<string, List<string>>();
		public byte[] Bytes;
		public string Message = "OK";
		public Request Request;
		public int Status = 200;

		public string Text
		{
			get
			{
				if (Bytes == null)
					return "";
				return Encoding.UTF8.GetString(Bytes);
			}
		}

		public string Asset
		{
			get { throw new NotSupportedException("This can't be done, yet."); }
		}

		public Hashtable Object
		{
			get
			{
				if (Bytes == null)
				{
					return null;
				}

				var result = false;
				var obj = (Hashtable) Json.JsonDecode(Text, ref result);
				if (!result)
				{
					obj = null;
				}

				return obj;
			}
		}

		public ArrayList Array
		{
			get
			{
				if (Bytes == null)
				{
					return null;
				}

				var result = false;
				var array = (ArrayList) Json.JsonDecode(Text, ref result);
				if (!result)
				{
					array = null;
				}

				return array;
			}
		}

		private void AddHeader(string name, string value)
		{
			name = name.ToLower().Trim();
			value = value.Trim();
			if (!_headers.ContainsKey(name))
				_headers[name] = new List<string>();
			_headers[name].Add(value);
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
				return new List<string>();
			return _headers[name];
		}

		public string GetHeader(string name)
		{
			name = name.ToLower().Trim();
			if (!_headers.ContainsKey(name))
				return string.Empty;
			return _headers[name][_headers[name].Count - 1];
		}

		private string ReadLine(Stream stream)
		{
			var line = new List<byte>();
			while (true)
			{
				var c = stream.ReadByte();
				if (c == -1)
				{
					throw new HttpException("Unterminated Stream Encountered.");
				}
				if ((byte) c == Request.Eol[1])
					break;
				line.Add((byte) c);
			}
			var s = Encoding.ASCII.GetString(line.ToArray()).Trim();
			return s;
		}

		private string[] ReadKeyValue(Stream stream)
		{
			var line = ReadLine(stream);
			if (line == "")
				return null;
			var split = line.IndexOf(':');
			if (split == -1)
				return null;
			var parts = new string[2];
			parts[0] = line.Substring(0, split).Trim();
			parts[1] = line.Substring(split + 1).Trim();
			return parts;
		}

		public void ReadFromStream(Stream inputStream)
		{
			//var inputStream = new BinaryReader(inputStream);
			var top = ReadLine(inputStream).Split(' ');

			if (!int.TryParse(top[1], out Status))
				throw new HttpException("Bad Status Code");

			// MemoryStream is a disposable
			// http://stackoverflow.com/questions/234059/is-a-memory-leak-created-if-a-memorystream-in-net-is-not-closed
			using (var output = new MemoryStream())
			{
				Message = string.Join(" ", top, 2, top.Length - 2);
				_headers.Clear();

				while (true)
				{
					// Collect Headers
					var parts = ReadKeyValue(inputStream);
					if (parts == null)
						break;
					AddHeader(parts[0], parts[1]);
				}

				if (Request.CookieJar != null)
				{
					var cookies = GetHeaders("set-cookie");
					for (var cookieIndex = 0; cookieIndex < cookies.Count; ++cookieIndex)
					{
						var cookieString = cookies[cookieIndex];
						if (cookieString.IndexOf("domain=", StringComparison.CurrentCultureIgnoreCase) == -1)
						{
							cookieString += "; domain=" + Request.Uri.Host;
						}

						if (cookieString.IndexOf("path=", StringComparison.CurrentCultureIgnoreCase) == -1)
						{
							cookieString += "; path=" + Request.Uri.AbsolutePath;
						}

						Request.CookieJar.SetCookie(new Cookie(cookieString));
					}
				}

				if (GetHeader("transfer-encoding") == "chunked")
				{
					while (true)
					{
						// Collect Body
						var length = int.Parse(ReadLine(inputStream), NumberStyles.AllowHexSpecifier);

						if (length == 0)
						{
							break;
						}

						for (var i = 0; i < length; i++)
						{
							output.WriteByte((byte) inputStream.ReadByte());
						}

						//forget the CRLF.
						inputStream.ReadByte();
						inputStream.ReadByte();
					}

					while (true)
					{
						//Collect Trailers
						var parts = ReadKeyValue(inputStream);
						if (parts == null)
							break;
						AddHeader(parts[0], parts[1]);
					}
				}
				else
				{
					// Read Body
					var contentLength = 0;

					try
					{
						contentLength = int.Parse(GetHeader("content-length"));
					}
					catch
					{
						contentLength = 0;
					}

					int b;
					while ((contentLength == 0 || output.Length < contentLength)
					       && (b = inputStream.ReadByte()) != -1)
					{
						output.WriteByte((byte) b);
					}

					if (contentLength > 0 && output.Length != contentLength)
					{
						throw new HttpException("Response length does not match content length");
					}
				}

				if (GetHeader("content-encoding").Contains("gzip"))
				{
					Bytes = UnZip(output);
				}
				else
				{
					Bytes = output.ToArray();
				}
			}
		}

		private byte[] UnZip(MemoryStream output)
		{
			var cms = new MemoryStream();
			output.Seek(0, SeekOrigin.Begin);
			using (var gz = new GZipStream(output, CompressionMode.Decompress))
			{
				var buf = new byte[1024];
				var byteCount = 0;
				while ((byteCount = gz.Read(buf, 0, buf.Length)) > 0)
				{
					cms.Write(buf, 0, byteCount);
				}
			}
			return cms.ToArray();
		}
	}
}