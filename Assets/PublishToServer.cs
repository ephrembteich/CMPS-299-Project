using Assets.src;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets
{
	class PublishToServer
	{
		private const String ServerAdreess = "http://localhost:22355/api/GameSessions";
		public static void Post(ServerGameSession server)
		{
			Debug.Log("llll");
			var theRequest = new Request("post", ServerAdreess , JsonUtility.ToJson(server));
			theRequest.Send((request) =>
			{
				Hashtable result = request.Response.Object;
				if (result == null)
				{
					Debug.LogWarning("Could not parse JSON response!");
					return;
				}
				Debug.Log(result);

			});
		}
	}
}
