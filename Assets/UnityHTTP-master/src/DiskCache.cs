using System;
using System.Collections;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

namespace Assets.src
{
	public class DiskCacheOperation
	{
		public bool FromCache = false;
		public bool IsDone;
		public Request Request;
	}

#if UNITY_WEBPLAYER
    public class DiskCache : MonoBehaviour
    {
        static DiskCache _instance = null;
        public static DiskCache Instance {
            get {
                if (_instance == null) {
                    var g = new GameObject ("DiskCache", typeof(DiskCache));
                    g.hideFlags = HideFlags.HideAndDontSave;
                    _instance = g.GetComponent<DiskCache> ();
                }
                return _instance;
            }
        }

        public DiskCacheOperation Fetch (Request request)
        {
            var handle = new DiskCacheOperation ();
            handle.request = request;
            StartCoroutine (Download (request, handle));
            return handle;
        }

        IEnumerator Download(Request request, DiskCacheOperation handle)
        {
            request.Send ();
            while (!request.isDone)
                yield return new WaitForEndOfFrame ();
            handle.isDone = true;
        }
    }
#else
	public class DiskCache : MonoBehaviour
	{
		private static DiskCache _instance;
		private string _cachePath;

		public static DiskCache Instance
		{
			get
			{
				if (_instance == null)
				{
					var g = new GameObject("DiskCache", typeof (DiskCache));
					g.hideFlags = HideFlags.HideAndDontSave;
					_instance = g.GetComponent<DiskCache>();
				}
				return _instance;
			}
		}

		private void Awake()
		{
			_cachePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "uwcache");
			if (!Directory.Exists(_cachePath))
				Directory.CreateDirectory(_cachePath);
		}

		public DiskCacheOperation Fetch(Request request)
		{
			var guid = string.Empty;
			// MD5 is disposable
			// http://msdn.microsoft.com/en-us/library/system.security.cryptography.md5.aspx#3
			using (var md5 = MD5.Create())
			{
				foreach (var b in md5.ComputeHash(Encoding.ASCII.GetBytes(request.Uri.ToString())))
				{
					guid = guid + b.ToString("X2");
				}
			}

			var filename = Path.Combine(_cachePath, guid);
			if (File.Exists(filename) && File.Exists(filename + ".etag"))
				request.SetHeader("If-None-Match", File.ReadAllText(filename + ".etag"));
			var handle = new DiskCacheOperation();
			handle.Request = request;
			StartCoroutine(DownloadAndSave(request, filename, handle));
			return handle;
		}

		private IEnumerator DownloadAndSave(Request request, string filename, DiskCacheOperation handle)
		{
			var useCachedVersion = File.Exists(filename);
			var callback = request.CompletedCallback;
			request.Send(); // will clear the completedCallback
			while (!request.IsDone)
				yield return new WaitForEndOfFrame();
			if (request.Exception == null && request.Response != null)
			{
				if (request.Response.Status == 200)
				{
					var etag = request.Response.GetHeader("etag");
					if (etag != string.Empty)
					{
						File.WriteAllBytes(filename, request.Response.Bytes);
						File.WriteAllText(filename + ".etag", etag);
					}
					useCachedVersion = false;
				}
			}

			if (useCachedVersion)
			{
				if (request.Exception != null)
				{
					Debug.LogWarning("Using cached version due to exception:" + request.Exception);
					request.Exception = null;
				}
				request.Response.Status = 304;
				request.Response.Bytes = File.ReadAllBytes(filename);
				request.IsDone = true;
			}
			handle.IsDone = true;

			if (callback != null)
			{
				callback(request);
			}
		}
	}
#endif
}