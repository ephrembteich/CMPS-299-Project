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
			ChangeName();
		}

		protected void TurnOnConfig()
		{
			var scene = Session.CurrentScene;

			foreach (var fItem in scene.FoodItems) {
				Map [fItem].SetActive (true);
			}

			if (scene.IsMom)
			{
				Map[Constants.Mom].SetActive(true);
			}

			Map[Session.Gender].SetActive(true);
		}

		protected void ChangeName()
		{
			var scene = Session.CurrentScene;
			//Debug.Log(scene.constVariable.Keys);
			foreach (var constVar in scene.constVariable.Keys)
			{
				//Debug.Log("Old Name"+Map[constVar].name +" " + scene.constVariable[constVar].Name);
				Map[constVar].transform.GetChild(0).name = scene.constVariable[constVar].Name;
				//Debug.Log("New Name"+Map[constVar].name+"End");
			}
		}



		protected void AbstractChoose(String item)
		{
			Session.AddChoice(item);
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