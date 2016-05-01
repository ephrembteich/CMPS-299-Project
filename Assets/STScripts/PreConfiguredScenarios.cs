using System;
using System.Collections.Generic;

namespace Assets.STScripts
{
	public class PreConfiguredScenarios
	{
		//Breakfast
		public List<Scene> BreakfastScenes { get; set; }
		//market on the way to school
		public List<Scene> SchoolMarketScenes { get; set; }
		//school play ground
		public List<Scene> SchoolPlayGroundScenes { get; set; }

		public List<Scene> GenerateScenes()
		{
			var gameScenes = new List<Scene>
			{
				GetBreakfastConfiguration(),
				GetSchoolMarketConfiguration(),
				GetSchoolPlayGroundConfiguration()
			};
			return gameScenes;
		}

		private Scene GetBreakfastConfiguration()
		{
			var rndGenerator = new Random();
			var random = rndGenerator.Next(1, 5);
			switch (random)
			{
				case 1:
					var scene = new Scene("Breakfast Home");
					scene.Place = "Kitchen";
					scene.Time = "Morning";
					scene.Variables.Add(new Variable("Convenience", "Croissant and Labneh Sandwich are on the table"));
					scene.Variables.Add(new Variable("Food Type", "Labneh Sandwich, Croissant"));
					scene.Variables.Add(new Variable("Pressure", "Mother is not in the kitchen"));
					scene.Variables.Add(new Variable("Portion Size", "Same Portion Size"));
					scene.FoodItems.Add(Constants.Croissant);
					scene.FoodItems.Add(Constants.Sandwich);
					return scene;
				case 2:
					var scene2 = new Scene("Breakfast Home");
					scene2.Place = "Kitchen";
					scene2.Time = "Morning";
					scene2.Variables.Add(new Variable("Convenience",
						"Sandwich is on the table. Ingredients of a sandwich (with olives) are in the fridge"));
					scene2.Variables.Add(new Variable("Food Type", "Labneh Sandwich"));
					scene2.Variables.Add(new Variable("Pressure", "Mother is not in the kitchen"));
					scene2.Variables.Add(new Variable("Portion Size", "Same Portion Size"));
					scene2.FoodItems.Add(Constants.Sandwich);
					scene2.FoodItems.Add(Constants.Labneh);
					scene2.FoodItems.Add(Constants.Bread);
					scene2.FoodItems.Add(Constants.Olives);
					return scene2;

				case 3:
					var scene3 = new Scene("Breakfast Home");
					scene3.Place = "Kitchen";
					scene3.Time = "Morning";
					scene3.Variables.Add(new Variable("Convenience", "Labneh sandwich is on the table"));
					scene3.Variables.Add(new Variable("Food Type", "Labneh Sandwich"));
					scene3.Variables.Add(new Variable("Pressure", "Mother is in the kitchen"));
					scene3.Variables.Add(new Variable("Portion Size", "Same Portion Size"));
					scene3.FoodItems.Add(Constants.Sandwich);
					scene3.FoodItems.Add(Constants.Mom);
					return scene3;
				default:
					var scene4 = new Scene("Breakfast Home");
					scene4.Place = "Kitchen";
					scene4.Time = "Morning";
					scene4.Variables.Add(new Variable("Convenience", "Labneh sandwiches are on the table"));
					scene4.Variables.Add(new Variable("Food Type", "Labneh Sandwich"));
					scene4.Variables.Add(new Variable("Pressure", "Mother is not in the kitchen"));
					scene4.Variables.Add(new Variable("Portion Size", "small, medium, large sandwich"));
					scene4.FoodItems.Add(Constants.Sandwich);
					scene4.FoodItems.Add(Constants.SmallSand);
					scene4.FoodItems.Add(Constants.MediumSand);
					return scene4;
			}
		}

		private Scene GetSchoolPlayGroundConfiguration()
		{
			return null;
		}

		private Scene GetSchoolMarketConfiguration()
		{
			return null;
		}
	}
}