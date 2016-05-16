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

		private Random rndGenerator;

		public List<Scene> GenerateScenes()
		{
			rndGenerator = new Random();
			var gameScenes = new List<Scene>
			{
				GetBreakfastConfiguration(),
				GetMarketConfiguration(),
				GetSchoolPlayGroundConfiguration(),
				GetHomeLunchConfiguration(),
				GetHomeDinnerConfiguration()
			};
			return gameScenes;
		}

		private Scene GetBreakfastConfiguration()
		{
			var random = rndGenerator.Next(1, 5);
			switch (random)
			{
				case 1:
					var scene = new Scene("Breakfast Home");
					scene.Place = "Kitchen";
					scene.Time = "Morning";
					scene.Variables.Add(ServerVariablesConsts.Breakfast_Croissant);
					scene.Variables.Add(ServerVariablesConsts.Breakfast_Sandwich_Table);
					scene.FoodItems.Add(Constants.Croissant);
					scene.FoodItems.Add(Constants.Sandwich);
					scene.constVariable.Add(Constants.Croissant, ServerVariablesConsts.Breakfast_Croissant);
					scene.constVariable.Add(Constants.Sandwich, ServerVariablesConsts.Breakfast_Sandwich_Table);
					return scene;
				case 2:
					var scene2 = new Scene("Breakfast Home");
					scene2.Place = "Kitchen";
					scene2.Time = "Morning";
					scene2.Variables.Add(ServerVariablesConsts.Breakfast_Sandwich_Table);
					scene2.Variables.Add(ServerVariablesConsts.Breakfast_LabnehOlives_Fridge);
					scene2.FoodItems.Add(Constants.Sandwich);
					scene2.FoodItems.Add(Constants.LabnehVegetables);
					scene2.constVariable.Add(Constants.Sandwich, ServerVariablesConsts.Breakfast_Sandwich_Table);
					scene2.constVariable.Add(Constants.LabnehVegetables, ServerVariablesConsts.Breakfast_LabnehOlives_Fridge);
					return scene2;

				case 3:
					var scene3 = new Scene("Breakfast Home");
					scene3.Place = "Kitchen";
					scene3.Variables.Add(ServerVariablesConsts.Breakfast_Sandwich_Table);
					scene3.Variables.Add(ServerVariablesConsts.Breakfast_Mother);
					scene3.FoodItems.Add(Constants.Sandwich);
					scene3.FoodItems.Add(Constants.Mom);
					scene3.constVariable.Add(Constants.Sandwich, ServerVariablesConsts.Breakfast_Sandwich_Table);
					return scene3;
				default:
					var scene4 = new Scene("Breakfast Home");
					scene4.Place = "Kitchen";
					scene4.Time = "Morning";
					scene4.Variables.Add(ServerVariablesConsts.Breakfast_Sandwich_Table);
					scene4.Variables.Add(ServerVariablesConsts.Breakfast_SandwichSmall_Table);
					scene4.Variables.Add(ServerVariablesConsts.Breakfast_SandwichMedium_Table);
					scene4.FoodItems.Add(Constants.Sandwich);
					scene4.FoodItems.Add(Constants.SmallSand);
					scene4.FoodItems.Add(Constants.MediumSand);
					scene4.constVariable.Add(Constants.Sandwich, ServerVariablesConsts.Breakfast_Sandwich_Table);
					scene4.constVariable.Add(Constants.SmallSand, ServerVariablesConsts.Breakfast_SandwichSmall_Table);
					scene4.constVariable.Add(Constants.MediumSand, ServerVariablesConsts.Breakfast_SandwichMedium_Table);
					return scene4;
			}
		}
			
		private Scene GetMarketConfiguration()
		{
			var random = rndGenerator.Next(1, 6);
			switch (random)
			{
			case 1:
				var scene = new Scene("Market Before School");
				scene.Place = "Market";
				scene.Time = "Morning";
				//scene.Variables.Add(new Variable("Convenience", "Food item inside a protecting cover or on the table"));
				//scene.Variables.Add(new Variable("Food Type", "Manouche"));
				//scene.Variables.Add(new Variable("Peer Pressure", "No friends are there"));
				//scene.Variables.Add(new Variable("Item Price", "Same Price"));
				scene.FoodItems.Add(Constants.Manouche1);
				scene.FoodItems.Add(Constants.Manouche2);
				scene.FoodItems.Add(Constants.CoverClosed);
				scene.FoodItems.Add(Constants.PriceTag3);
				scene.FoodItems.Add(Constants.PriceTag4);
				//Constants.Manouche1 -> variable
				return scene;
			case 2:
				var scene2 = new Scene("Market Before School");
				scene2.Place = "Market";
				scene2.Time = "Morning";
				//scene2.Variables.Add(new Variable("Convenience", "Food is on the table outside the shop"));
				//scene2.Variables.Add(new Variable("Food Type", "Manouche Banana Custard Chips"));
				//scene2.Variables.Add(new Variable("Peer Pressure", "No friends are there"));
				//scene2.Variables.Add(new Variable("Item Price", "Same Price"));
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
				//scene3.Variables.Add(new Variable("Convenience", "Food is on the table outside the shop"));
				//scene3.Variables.Add(new Variable("Food Type", "Manouche"));
				//scene3.Variables.Add(new Variable("Peer Pressure", "Friend is buying a manouche"));
				//scene3.Variables.Add(new Variable("Item Price", "Same Price"));
				scene3.FoodItems.Add(Constants.Manouche1);
				scene3.FoodItems.Add(Constants.Manouche2);
				scene3.FoodItems.Add(Constants.Manouche3);
				scene3.FoodItems.Add(Constants.PriceTag1);
				scene3.FoodItems.Add(Constants.PriceTag2);
				scene3.FoodItems.Add(Constants.PriceTag3);
				scene3.FoodItems.Add(Constants.PriceTag4);
				scene3.FoodItems.Add(Constants.Friend);
				return scene3;
			case 4:
				var scene4 = new Scene("Market Before School");
				scene4.Place = "Market";
				scene4.Time = "Morning";
				scene4.FoodItems.Add(Constants.Manouche2);
				scene4.FoodItems.Add(Constants.ManoucheMedium);
				scene4.FoodItems.Add(Constants.ManoucheSmall);
				scene4.FoodItems.Add(Constants.PriceTag1);
				scene4.FoodItems.Add(Constants.PriceTag2);
				scene4.FoodItems.Add(Constants.PriceTag3);
				return scene4;
			default:
				var scene5 = new Scene("Market Before School");
				scene5.Place = "Market";
				scene5.Time = "Morning";
				//scene5.Variables.Add(new Variable("Convenience", "Food is on the table outside the shop"));
				//scene5.Variables.Add(new Variable("Food Type", "Manouche"));
				//scene5.Variables.Add(new Variable("Peer Pressure", "No friends are there"));
				//scene5.Variables.Add(new Variable("Item Price", "100LL, 200LL, 500LL"));
				scene5.FoodItems.Add(Constants.Manouche1);
				scene5.FoodItems.Add(Constants.Manouche2);
				scene5.FoodItems.Add(Constants.Manouche3);
				scene5.FoodItems.Add(Constants.PriceTag1);
				scene5.FoodItems.Add(Constants.PriceTag5);
				scene5.FoodItems.Add(Constants.PriceTag6);
				return scene5;
			}
		}
			
		private Scene GetSchoolPlayGroundConfiguration()
		{
			var random = rndGenerator.Next(1, 5);
			switch (random)
			{
			case 1:
				var scene = new Scene("Recess School Playground");
				scene.Place = "School";
				scene.Time = "Recess";
				scene.FoodItems.Add(Constants.Manouche1);
				scene.FoodItems.Add(Constants.Candy);
				scene.FoodItems.Add(Constants.Chips);
				scene.FoodItems.Add(Constants.LentilSoup);
				scene.FoodItems.Add(Constants.PriceTag1);
				scene.FoodItems.Add(Constants.PriceTag2);
				scene.FoodItems.Add(Constants.PriceTag3);
				scene.FoodItems.Add(Constants.PriceTag4);
				return scene;
			case 2:
				var scene2 = new Scene ("Recess School Playground");
				scene2.Place = "School";
				scene2.Time = "Recess";
				scene2.FoodItems.Add (Constants.Manouche1);
				scene2.FoodItems.Add (Constants.Manouche2);
				scene2.FoodItems.Add (Constants.Manouche3);
				scene2.FoodItems.Add (Constants.PriceTag1);
				scene2.FoodItems.Add (Constants.PriceTag4);
				scene2.FoodItems.Add (Constants.PriceTag3);
				scene2.FoodItems.Add (Constants.Friend);
				return scene2;
			case 3:
				var scene3 = new Scene("Recess School Playground");
				scene3.Place = "School";
				scene3.Time = "Recess";
				scene3.FoodItems.Add(Constants.Manouche1);
				scene3.FoodItems.Add(Constants.Manouche2);
				scene3.FoodItems.Add(Constants.Manouche3);
				scene3.FoodItems.Add(Constants.PriceTag4);
				scene3.FoodItems.Add(Constants.PriceTag5);
				scene3.FoodItems.Add(Constants.PriceTag6);
				return scene3;
			default:
				var scene4 = new Scene("Recess School Playground");
				scene4.Place = "School";
				scene4.Time = "Recess";
				scene4.FoodItems.Add(Constants.Manouche1);
				scene4.FoodItems.Add(Constants.ManoucheMedium);
				scene4.FoodItems.Add(Constants.ManoucheSmall);
				scene4.FoodItems.Add(Constants.PriceTag1);
				scene4.FoodItems.Add(Constants.PriceTag4);
				scene4.FoodItems.Add(Constants.PriceTag3);
				return scene4;
			}
		}

		private Scene GetHomeLunchConfiguration()
		{
			var random = rndGenerator.Next(1, 5);
			switch (random)
			{
			case 1:
				var scene = new Scene("Lunch Home");
				scene.Place = "Kitchen";
				scene.Time = "Afternoon";
				scene.FoodItems.Add(Constants.SimpleSalad);
				scene.FoodItems.Add(Constants.Salad);
				return scene;
			case 2:
				var scene2 = new Scene("Lunch Home");
				scene2.Place = "Kitchen";
				scene2.Time = "Afternoon";
				scene2.FoodItems.Add(Constants.Stew);
				scene2.FoodItems.Add(Constants.Pizza);
				return scene2;

			case 3:
				var scene3 = new Scene("Lunch Home");
				scene3.Place = "Kitchen";
				scene3.Time = "Afternoon";
				scene3.FoodItems.Add(Constants.Stew);
				scene3.FoodItems.Add(Constants.Mom);
				return scene3;
			default:
				var scene4 = new Scene("Lunch Home");
				scene4.Place = "Kitchen";
				scene4.Time = "Afternoon";
				scene4.FoodItems.Add(Constants.SmallPizza);
				scene4.FoodItems.Add(Constants.MediumPizza);
				scene4.FoodItems.Add(Constants.Pizza);
				return scene4;
			}
		}

		private Scene GetHomeDinnerConfiguration()
		{
			var random = rndGenerator.Next(1, 4);
			switch (random)
			{
			case 1:
				var scene = new Scene("Dinner Home");
				scene.Place = "Kitchen";
				scene.Time = "Evening";
				scene.FoodItems.Add(Constants.Croissant);
				scene.FoodItems.Add(Constants.CheeseSandwich);
				return scene;
			case 2:
				var scene2 = new Scene("Dinner Home");
				scene2.Place = "Kitchen";
				scene2.Time = "Evening";
				scene2.FoodItems.Add(Constants.Soup);
				scene2.FoodItems.Add(Constants.Mom);
				return scene2;

			default:
				var scene3 = new Scene ("Dinner Home");
				scene3.Place = "Kitchen";
				scene3.Time = "Evening";
				scene3.FoodItems.Add (Constants.OneEgg);
				scene3.FoodItems.Add (Constants.TwoEggs);
				scene3.FoodItems.Add (Constants.ThreeEggs);
				return scene3;
			}
		}
	}
}