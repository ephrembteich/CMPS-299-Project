using System;
using System.Collections.Generic;

namespace Assets.STScripts
{
	public class PreConfiguredScenarios
	{
		//Breakfast
		public List<Scene> BreakfastScenes { get; set; }
		//market on the way to school
		public List<Scene> MarketScenes { get; set; }
		//school play ground
		public List<Scene> SchoolPlayGroundScenes { get; set; }

		public List<Scene> GenerateScenes()
		{
			var gameScenes = new List<Scene>
			{
				GetBreakfastConfiguration(),
				GetMarketConfiguration(),
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

		private Scene GetMarketConfiguration()
		{
			var rndGenerator = new Random();
			var random = rndGenerator.Next(1, 5);
			switch (random)
			{
			case 1:
				var scene = new Scene("Market Before School");
				scene.Place = "Market";
				scene.Time = "Morning";
				scene.Variables.Add(new Variable("Convenience", "Food item inside a protecting cover or on the table"));
				scene.Variables.Add(new Variable("Food Type", "Manouche"));
				scene.Variables.Add(new Variable("Peer Pressure", "No friends are there"));
				scene.Variables.Add(new Variable("Item Price", "Same Price"));
				scene.FoodItems.Add(Constants.Manouche1);
				scene.FoodItems.Add(Constants.Manouche2);
				scene.FoodItems.Add(Constants.CoverClosed);
				scene.FoodItems.Add(Constants.PriceTag3);
				scene.FoodItems.Add(Constants.PriceTag4);
				return scene;
			case 2:
				var scene2 = new Scene("Market Before School");
				scene2.Place = "Market";
				scene2.Time = "Morning";
				scene2.Variables.Add(new Variable("Convenience", "Food is on the table outside the shop"));
				scene2.Variables.Add(new Variable("Food Type", "Manouche Banana Custard Chips"));
				scene2.Variables.Add(new Variable("Peer Pressure", "No friends are there"));
				scene2.Variables.Add(new Variable("Item Price", "Same Price"));
				scene2.FoodItems.Add(Constants.PriceTag1);
				scene2.FoodItems.Add(Constants.PriceTag2);
				scene2.FoodItems.Add(Constants.PriceTag3);
				scene2.FoodItems.Add(Constants.PriceTag4);
				scene2.FoodItems.Add(Constants.Manouche1);
				scene2.FoodItems.Add(Constants.Banana);
				scene2.FoodItems.Add(Constants.Custard);
				scene2.FoodItems.Add(Constants.Chips);
				return scene2;
			case 3:
				var scene3 = new Scene("Market Before School");
				scene3.Place = "Market";
				scene3.Time = "Morning";
				scene3.Variables.Add(new Variable("Convenience", "Food is on the table outside the shop"));
				scene3.Variables.Add(new Variable("Food Type", "Manouche"));
				scene3.Variables.Add(new Variable("Peer Pressure", "Friend is buying a manouche"));
				scene3.Variables.Add(new Variable("Item Price", "Same Price"));
				scene3.FoodItems.Add(Constants.Manouche1);
				scene3.FoodItems.Add(Constants.Manouche2);
				scene3.FoodItems.Add(Constants.Manouche3);
				scene3.FoodItems.Add(Constants.PriceTag1);
				scene3.FoodItems.Add(Constants.PriceTag2);
				scene3.FoodItems.Add(Constants.PriceTag3);
				scene3.FoodItems.Add(Constants.PriceTag4);
				scene3.FoodItems.Add(Constants.Friend);
				return scene3;
			default:
				var scene4 = new Scene("Market Before School");
				scene4.Place = "Market";
				scene4.Time = "Morning";
				scene4.Variables.Add(new Variable("Convenience", "Food is on the table outside the shop"));
				scene4.Variables.Add(new Variable("Food Type", "Manouche"));
				scene4.Variables.Add(new Variable("Peer Pressure", "No friends are there"));
				scene4.Variables.Add(new Variable("Item Price", "100LL, 200LL, 500LL"));
				scene4.FoodItems.Add(Constants.Manouche1);
				scene4.FoodItems.Add(Constants.Manouche2);
				scene4.FoodItems.Add(Constants.Manouche3);
				scene4.FoodItems.Add(Constants.PriceTag1);
				scene4.FoodItems.Add(Constants.PriceTag5);
				scene4.FoodItems.Add(Constants.PriceTag6);
				return scene4;
			}
		}

		private Scene GetSchoolPlayGroundConfiguration()
		{
			return null;
		}
	}
}