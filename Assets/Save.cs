using System.Collections;
using Assets.src;
using UnityEngine;

namespace Assets
{
	public class Save
	{

		public IEnumerator SomeRoutine()
		{
			Debug.Log("Before request");
			var someRequest = new Request("get", "http://jsonplaceholder.typicode.com/posts");
			someRequest.Send();

			Debug.Log("Before While");
			while (!someRequest.IsDone)
			{
				yield return null;
			}

			// parse some JSON, for example:
			Debug.Log("HERE");
			Debug.Log(someRequest.Response.Text);
			Debug.Log("again");
			//JsonUtility.ToJson(new Scene("Issa"));
		}
	}
}