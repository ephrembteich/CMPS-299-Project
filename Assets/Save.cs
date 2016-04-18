using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Globalization;
using System.Threading;
using System;


public class Save : MonoBehaviour {

	public void Start () {
		Savecsv();
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