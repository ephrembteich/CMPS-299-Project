using System;
using System.Collections.Generic;
using System.Linq;
using Assets.src;
using Assets.STScripts;
using UnityEngine;

namespace Assets
{
	public class GameSession
	{
		private static GameSession _session;
		public CookieAccessInfo C;
		public LinkedList<String> Results;
		private PreConfiguredScenarios _generator;
		private ServerGameSession _serverResult;

		private GameSession()
		{
			_generator = new PreConfiguredScenarios();
			Results = new LinkedList<String>();
			Scenes = _generator.GenerateScenes();
			CurrentScene = Scenes.ElementAt(CurrentLevel);
			_serverResult = new ServerGameSession();
			foreach (var scene in Scenes)
			{
				_serverResult.Variables.AddRange(scene.Variables);
			}
		}

		public int Age { get; set; }
		public String Gender { get; set; }
		public String PlayerId { get; set; }
		public List<Scene> Scenes { get; set; }
		public Scene CurrentScene { get; set; }
		public int CurrentLevel { get; set; }

		public void WriteResult()
		{
			Results.AddLast("Scene: " + CurrentScene.SceneName + " ");
		}

		public void IncrementLevel()
		{
			CurrentLevel++;
			CurrentScene = Scenes.ElementAt(CurrentLevel);
		}

		public void AddChoice(String variableName)
		{
			foreach (var variable in _serverResult.Variables)
			{
				if (variable.Name.Equals(variableName))
				{
					_serverResult.Choices.Add(variable);
					break;
				}
			}
		}

		public ServerGameSession GetServerVariable()
		{
			_serverResult.Age = Age;
			_serverResult.Gender = Gender;
			_serverResult.PlayerId = PlayerId;
			return _serverResult;
		}

		public static GameSession GetSession()
		{
			return _session ?? (_session = new GameSession());
		}
	}
}