using System.Collections;
using System.IO;
using System.Text;
using Assets.src;
using UnityEngine;

//using System.JSON;

namespace Assets
{
	public class Save : MonoBehaviour
	{
		public void Start()
		{
			Savecsv();
		}

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
		}

		public static void Savecsv()
		{
			Debug.Log("Start");
			var filePath = @"Game_Result" /*+ @System.DateTime.Now.ToString()*/+ ".csv";
			var delimiter = ",";

			var output = GameSession.GetSession().Results;
			var sb = new StringBuilder();
			foreach (var result in output)
			{
				sb.AppendLine(result + delimiter);
			}
			File.WriteAllText(filePath, sb.ToString());
			Debug.Log("END");
		}
	}
}