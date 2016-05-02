using System.Collections;
using UnityEngine;

namespace Assets.src
{
	public class ResponseCallbackDispatcher : MonoBehaviour
	{
		private static GameObject _singletonGameObject;
		private static readonly object SingletonLock = new object();
		public Queue Requests = Queue.Synchronized(new Queue());

		static ResponseCallbackDispatcher()
		{
			Singleton = null;
		}

		public static ResponseCallbackDispatcher Singleton { get; private set; }

		public static void Init()
		{
			if (Singleton != null)
			{
				return;
			}

			lock (SingletonLock)
			{
				if (Singleton != null)
				{
					return;
				}

				_singletonGameObject = new GameObject();
				DontDestroyOnLoad(_singletonGameObject);
				Singleton = _singletonGameObject.AddComponent<ResponseCallbackDispatcher>();
				_singletonGameObject.name = "HTTPResponseCallbackDispatcher";
			}
		}

		public void Update()
		{
			while (Requests.Count > 0)
			{
				var request = (Request) Requests.Dequeue();
				request.CompletedCallback(request);
			}
		}
	}
}