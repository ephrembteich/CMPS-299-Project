using System;
using System.Collections.Generic;

namespace Assets
{
	public class Scene
	{
		public String Result;

		public Scene(String sceneName)
		{
			this.SceneName = sceneName;
			Variables = new List<ServerVariable>();
			FoodItems = new List<String>();
			constVariable = new Dictionary<String, ServerVariable>();
		}

		public String SceneName { get; set; }
		public String Place { get; set; }
		public String Time { get; set; }
		public List<ServerVariable> Variables { get; set; }
		public List<String> FoodItems { get; set; }
		public bool IsMom { get; set; }
		public String SelectedFoodItem { get; set; }
		public Dictionary<String, ServerVariable>  constVariable { get; set; }

		public String GetResult()
		{
			Result += SceneName;
			foreach (var varr in Variables)
			{
				Result += varr.Description;
			}

			Result += SelectedFoodItem;
			return Result;
		}
	}
}