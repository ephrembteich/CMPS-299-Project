using System;
using System.Collections.Generic;
using Assets.STScripts;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets
{
	public abstract class AbstractScenario : MonoBehaviour
	{
		public Dictionary<String, GameObject> Map;
		protected GameSession Session = GameSession.GetSession();
		protected abstract void InitMap();

		protected void AbstractStart()
		{
			InitMap();
			TurnOnConfig();
		}

		protected void TurnOnConfig()
		{
			var scene = Session.CurrentScene;
			foreach (var fItem in scene.FoodItems)
			{
				Map[fItem].SetActive(true);
			}

			if (scene.IsMom)
			{
				Map[Constants.Mom].SetActive(true);
			}

			Map[Session.Gender].SetActive(true);
		}

		protected void AbstractChoose(String item)
		{
			Session.CurrentScene.SelectedFoodItem = item;
		}

		protected void AbstractNext(String nextScene)
		{
			var result = Session.CurrentScene.GetResult();
			Session.Results.AddLast(result);
			Session.IncrementLevel();
			SceneManager.LoadScene(nextScene);
		}
	}
}