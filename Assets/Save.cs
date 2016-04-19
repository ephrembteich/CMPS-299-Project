using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using HTTP;
using UnityEngine;
//using System.JSON;

public class Save : MonoBehaviour {

	public void Start () {
		Savecsv();
	}

	public IEnumerator SomeRoutine()
	{
		Debug.Log("Before request");
		Request someRequest = new Request("get", "http://jsonplaceholder.typicode.com/posts");
		someRequest.Send();

		Debug.Log("Before While");
		while (!someRequest.isDone)
		{
			yield return null;
		}

		// parse some JSON, for example:
		Debug.Log("HERE");
		Debug.Log(someRequest.response.Text);
		Debug.Log("again");
	}

	public static void Savecsv() {
		Debug.Log ("Start");
		string filePath = @"Game_Result" /*+ @System.DateTime.Now.ToString()*/ +".csv";  
		string delimiter = ",";  
		  
		LinkedList<String> output = GameSession.getSession().Results;  
		StringBuilder sb = new StringBuilder();  
		foreach (var result in output)  {
			sb.AppendLine(result + delimiter);  
		}
		File.WriteAllText(filePath, sb.ToString());
		Debug.Log ("END");
	}
}