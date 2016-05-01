using System;
using System.Collections.Generic;
using System.Linq;
using Assets.src;
using Assets.STScripts;

namespace Assets
{
	public class GameSession
	{
		private static GameSession _session;
		public CookieAccessInfo C;
		public LinkedList<String> Results;
		private PreConfiguredScenarios _generator;

		private GameSession()
		{
			_generator = new PreConfiguredScenarios();
			Results = new LinkedList<String>();
			Scenes = _generator.GenerateScenes();
			CurrentScene = Scenes.ElementAt(CurrentLevel);
		}

		public int Age { get; set; }
		public String Gender { get; set; }
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

		public static GameSession GetSession()
		{
			return _session ?? (_session = new GameSession());
		}
	}
}