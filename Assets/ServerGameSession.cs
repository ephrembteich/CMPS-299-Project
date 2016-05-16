using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets
{
	[Serializable]
	public class ServerGameSession
	{
		public String PlayerId;

		public String Gender;

		public int Age;

		public List<ServerVariable> Choices;

		public List<ServerVariable> Variables;

		public ServerGameSession(String playerId, String gender, int age)
		{
			PlayerId = playerId;
			Gender = gender;
			Age = age;
			Choices = new List<ServerVariable>();
			Variables = new List<ServerVariable>();
		}
	}
}