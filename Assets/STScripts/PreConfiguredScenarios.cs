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
				var scene = new Scene ("Market Before School");
				scene.Place = "Market";
				scene.Time = "Morning";
				scene.Variables.Add (ServerVariablesConsts.MorningStreet_ManousheInsideCover_Shop);
				scene.Variables.Add (ServerVariablesConsts.MorningStreet_ManousheOnTable_Shop);
				scene.FoodItems.Add (Constants.Manouche1);
				scene.FoodItems.Add (Constants.Manouche2);
				scene.FoodItems.Add (Constants.CoverClosed);
				scene.FoodItems.Add (Constants.PriceTag3);
				scene.FoodItems.Add (Constants.PriceTag4);
				scene.constVariable.Add (Constants.Manouche1, ServerVariablesConsts.MorningStreet_ManousheInsideCover_Shop);
				scene.constVariable.Add (Constants.Manouche1, ServerVariablesConsts.MorningStreet_ManousheOnTable_Shop);
				return scene;
			case 2:
				var scene2 = new Scene ("Market Before School");
				scene2.Place = "Market";
				scene2.Time = "Morning";
				scene2.Variables.Add (ServerVariablesConsts.MorningStreet_Manoushe_Shop);
				scene2.Variables.Add (ServerVariablesConsts.MorningStreet_Banana_Shop);
				scene2.Variables.Add (ServerVariablesConsts.MorningStreet_Chips_Shop);
				scene2.Variables.Add (ServerVariablesConsts.MorningStreet_Custard_Shop);
				scene2.FoodItems.Add (Constants.PriceTag1);
				scene2.FoodItems.Add (Constants.PriceTag2);
				scene2.FoodItems.Add (Constants.PriceTag3);
				scene2.FoodItems.Add (Constants.PriceTag4);
				scene2.FoodItems.Add (Constants.Manouche1);
				scene2.FoodItems.Add (Constants.Banana);
				scene2.FoodItems.Add (Constants.Custard);
				scene2.FoodItems.Add (Constants.Chips);
				scene2.constVariable.Add (Constants.Chips, ServerVariablesConsts.MorningStreet_Chips_Shop);
				scene2.constVariable.Add (Constants.Custard, ServerVariablesConsts.MorningStreet_Custard_Shop);
				scene2.constVariable.Add (Constants.Banana, ServerVariablesConsts.MorningStreet_Banana_Shop);
				scene2.constVariable.Add (Constants.Manouche1, ServerVariablesConsts.MorningStreet_Manoushe_Shop);
				return scene2;
			case 3:
				var scene3 = new Scene ("Market Before School");
				scene3.Place = "Market";
				scene3.Time = "Morning";
				scene3.Variables.Add (ServerVariablesConsts.MorningStreet_Manoushe_Shop);
				scene3.FoodItems.Add (Constants.Manouche1);
				scene3.FoodItems.Add (Constants.Manouche2);
				scene3.FoodItems.Add (Constants.Manouche3);
				scene3.FoodItems.Add (Constants.PriceTag1);
				scene3.FoodItems.Add (Constants.PriceTag2);
				scene3.FoodItems.Add (Constants.PriceTag3);
				scene3.FoodItems.Add (Constants.PriceTag4);
				scene3.FoodItems.Add (Constants.Friend);
				scene3.constVariable.Add (Constants.Manouche1, ServerVariablesConsts.MorningStreet_Manoushe_Shop);
				scene3.constVariable.Add (Constants.Manouche2, ServerVariablesConsts.MorningStreet_Manoushe_Shop);
				scene3.constVariable.Add (Constants.Manouche3, ServerVariablesConsts.MorningStreet_Manoushe_Shop);
				return scene3;
			case 4:
				var scene4 = new Scene ("Market Before School");
				scene4.Place = "Market";
				scene4.Time = "Morning";
				scene4.Variables.Add (ServerVariablesConsts.MorningStreet_ManousheSmall_Shop);
				scene4.Variables.Add (ServerVariablesConsts.MorningStreet_ManousheMedium_Shop);
				scene4.Variables.Add (ServerVariablesConsts.MorningStreet_ManousheLarge_Shop);
				scene4.FoodItems.Add (Constants.Manouche2);
				scene4.FoodItems.Add (Constants.ManoucheMedium);
				scene4.FoodItems.Add (Constants.ManoucheSmall);
				scene4.FoodItems.Add (Constants.PriceTag1);
				scene4.FoodItems.Add (Constants.PriceTag2);
				scene4.FoodItems.Add (Constants.PriceTag3);
				scene4.constVariable.Add (Constants.ManoucheSmall, ServerVariablesConsts.MorningStreet_ManousheSmall_Shop);
				scene4.constVariable.Add (Constants.ManoucheMedium, ServerVariablesConsts.MorningStreet_ManousheMedium_Shop);
				scene4.constVariable.Add (Constants.Manouche2, ServerVariablesConsts.MorningStreet_ManousheLarge_Shop);
				return scene4;
			default:
				var scene5 = new Scene ("Market Before School");
				scene5.Place = "Market";
				scene5.Time = "Morning";
				scene5.Variables.Add (ServerVariablesConsts.MorningStreet_Manoushe100_Shop);
				scene5.Variables.Add (ServerVariablesConsts.MorningStreet_Manoushe250_Shop);
				scene5.Variables.Add (ServerVariablesConsts.MorningStreet_Manoushe500_Shop);
				scene5.FoodItems.Add (Constants.Manouche1);
				scene5.FoodItems.Add (Constants.Manouche2);
				scene5.FoodItems.Add (Constants.Manouche3);
				scene5.FoodItems.Add (Constants.PriceTag1);
				scene5.FoodItems.Add (Constants.PriceTag5);
				scene5.FoodItems.Add (Constants.PriceTag6);
				scene5.constVariable.Add (Constants.Manouche1, ServerVariablesConsts.MorningStreet_Manoushe100_Shop);
				scene5.constVariable.Add (Constants.Manouche2, ServerVariablesConsts.MorningStreet_Manoushe250_Shop);
				scene5.constVariable.Add (Constants.Manouche3, ServerVariablesConsts.MorningStreet_Manoushe500_Shop);
				return scene5;
			}
		}
			
		private Scene GetSchoolPlayGroundConfiguration()
		{
			var random = rndGenerator.Next(1, 5);
			switch (random)
			{
			case 1:
				var scene = new Scene ("Recess School Playground");
				scene.Place = "School";
				scene.Time = "Recess";
				scene.Variables.Add (ServerVariablesConsts.RecessSchool_Candy_Shop);
				scene.Variables.Add (ServerVariablesConsts.RecessSchool_Manoushe_Shop);
				scene.Variables.Add (ServerVariablesConsts.RecessSchool_Chips_Shop);
				scene.Variables.Add (ServerVariablesConsts.RecessSchool_LentilSoup_Shop);
				scene.FoodItems.Add (Constants.Manouche1);
				scene.FoodItems.Add (Constants.Candy);
				scene.FoodItems.Add (Constants.Chips);
				scene.FoodItems.Add (Constants.LentilSoup);
				scene.FoodItems.Add (Constants.PriceTag1);
				scene.FoodItems.Add (Constants.PriceTag2);
				scene.FoodItems.Add (Constants.PriceTag3);
				scene.FoodItems.Add (Constants.PriceTag4);
				scene.constVariable.Add (Constants.Manouche1, ServerVariablesConsts.RecessSchool_Manoushe_Shop);
				scene.constVariable.Add (Constants.Candy, ServerVariablesConsts.RecessSchool_Candy_Shop);
				scene.constVariable.Add (Constants.Chips, ServerVariablesConsts.RecessSchool_Chips_Shop);
				scene.constVariable.Add (Constants.LentilSoup, ServerVariablesConsts.RecessSchool_LentilSoup_Shop);
				return scene;
			case 2:
				var scene2 = new Scene ("Recess School Playground");
				scene2.Place = "School";
				scene2.Time = "Recess";
				scene2.Variables.Add (ServerVariablesConsts.RecessSchool_ManousheSmall_Shop);
				scene2.FoodItems.Add (Constants.Manouche1);
				scene2.FoodItems.Add (Constants.Manouche2);
				scene2.FoodItems.Add (Constants.Manouche3);
				scene2.FoodItems.Add (Constants.PriceTag1);
				scene2.FoodItems.Add (Constants.PriceTag4);
				scene2.FoodItems.Add (Constants.PriceTag3);
				scene2.FoodItems.Add (Constants.Friend);
				scene2.constVariable.Add (Constants.Manouche1, ServerVariablesConsts.RecessSchool_ManousheSmall_Shop);
				scene2.constVariable.Add (Constants.Manouche2, ServerVariablesConsts.RecessSchool_ManousheSmall_Shop);
				scene2.constVariable.Add (Constants.Manouche3, ServerVariablesConsts.RecessSchool_ManousheSmall_Shop);
				return scene2;
			case 3:
				var scene3 = new Scene ("Recess School Playground");
				scene3.Place = "School";
				scene3.Time = "Recess";
				scene3.Variables.Add (ServerVariablesConsts.RecessSchool_Manoushe100_Shop);
				scene3.Variables.Add (ServerVariablesConsts.RecessSchool_Manoushe250_Shop);
				scene3.Variables.Add (ServerVariablesConsts.RecessSchool_Manoushe500_Shop);
				scene3.FoodItems.Add (Constants.Manouche1);
				scene3.FoodItems.Add (Constants.Manouche2);
				scene3.FoodItems.Add (Constants.Manouche3);
				scene3.FoodItems.Add (Constants.PriceTag4);
				scene3.FoodItems.Add (Constants.PriceTag5);
				scene3.FoodItems.Add (Constants.PriceTag6);
				scene3.constVariable.Add (Constants.Manouche1, ServerVariablesConsts.RecessSchool_Manoushe500_Shop);
				scene3.constVariable.Add (Constants.Manouche2, ServerVariablesConsts.RecessSchool_Manoushe100_Shop);
				scene3.constVariable.Add (Constants.Manouche3, ServerVariablesConsts.RecessSchool_Manoushe250_Shop);
				return scene3;
			default:
				var scene4 = new Scene ("Recess School Playground");
				scene4.Place = "School";
				scene4.Time = "Recess";
				scene4.Variables.Add (ServerVariablesConsts.RecessSchool_ManousheMedium_Shop);
				scene4.Variables.Add (ServerVariablesConsts.RecessSchool_ManousheLarge_Shop);
				scene4.Variables.Add (ServerVariablesConsts.RecessSchool_ManousheSmall_Shop);
				scene4.FoodItems.Add (Constants.Manouche1);
				scene4.FoodItems.Add (Constants.ManoucheMedium);
				scene4.FoodItems.Add (Constants.ManoucheSmall);
				scene4.FoodItems.Add (Constants.PriceTag1);
				scene4.FoodItems.Add (Constants.PriceTag4);
				scene4.FoodItems.Add (Constants.PriceTag3);
				scene4.constVariable.Add (Constants.Manouche1, ServerVariablesConsts.RecessSchool_ManousheLarge_Shop);
				scene4.constVariable.Add (Constants.ManoucheMedium, ServerVariablesConsts.RecessSchool_ManousheMedium_Shop);
				scene4.constVariable.Add (Constants.ManoucheSmall, ServerVariablesConsts.RecessSchool_ManousheSmall_Shop);
				return scene4;
			}
		}

		private Scene GetHomeLunchConfiguration()
		{
			var random = rndGenerator.Next(1, 5);
			switch (random)
			{
			case 1:
				var scene = new Scene ("Lunch Home");
				scene.Place = "Kitchen";
				scene.Time = "Afternoon";
				scene.Variables.Add (ServerVariablesConsts.LunchHome_SimpleSalad_Table);
				scene.Variables.Add (ServerVariablesConsts.LunchHome_ClassicSalad_Fridge);
				scene.FoodItems.Add (Constants.SimpleSalad);
				scene.FoodItems.Add (Constants.Salad);
				scene.constVariable.Add (Constants.SimpleSalad, ServerVariablesConsts.LunchHome_SimpleSalad_Table);
				scene.constVariable.Add (Constants.Salad, ServerVariablesConsts.LunchHome_ClassicSalad_Fridge);
				return scene;
			case 2:
				var scene2 = new Scene ("Lunch Home");
				scene2.Place = "Kitchen";
				scene2.Time = "Afternoon";
				scene2.Variables.Add (ServerVariablesConsts.LunchHome_Stew_Table);
				scene2.Variables.Add (ServerVariablesConsts.LunchHome_Pizza_Table);
				scene2.FoodItems.Add (Constants.Stew);
				scene2.FoodItems.Add (Constants.Pizza);
				scene2.constVariable.Add (Constants.Stew, ServerVariablesConsts.LunchHome_Stew_Table);
				scene2.constVariable.Add (Constants.Pizza, ServerVariablesConsts.LunchHome_Pizza_Table);
				return scene2;

			case 3:
				var scene3 = new Scene ("Lunch Home");
				scene3.Place = "Kitchen";
				scene3.Time = "Afternoon";
				scene3.Variables.Add (ServerVariablesConsts.LunchHome_Stew_Table);
				scene3.FoodItems.Add (Constants.Stew);
				scene3.FoodItems.Add (Constants.Mom);
				scene3.constVariable.Add (Constants.Stew, ServerVariablesConsts.LunchHome_Stew_Table);
				return scene3;
			default:
				var scene4 = new Scene ("Lunch Home");
				scene4.Place = "Kitchen";
				scene4.Time = "Afternoon";
				scene4.Variables.Add (ServerVariablesConsts.LunchHome_SmallPizza_Table);
				scene4.Variables.Add (ServerVariablesConsts.LunchHome_MediumPizza_Table);
				scene4.Variables.Add (ServerVariablesConsts.LunchHome_LargePizza_Table);
				scene4.FoodItems.Add (Constants.SmallPizza);
				scene4.FoodItems.Add (Constants.MediumPizza);
				scene4.FoodItems.Add (Constants.Pizza);
				scene4.constVariable.Add (Constants.SmallPizza, ServerVariablesConsts.LunchHome_SmallPizza_Table);
				scene4.constVariable.Add (Constants.MediumPizza, ServerVariablesConsts.LunchHome_MediumPizza_Table);
				scene4.constVariable.Add (Constants.Pizza, ServerVariablesConsts.LunchHome_LargePizza_Table);
				return scene4;
			}
		}

		private Scene GetHomeDinnerConfiguration()
		{
			var random = rndGenerator.Next(1, 4);
			switch (random)
			{
			case 1:
				var scene = new Scene ("Dinner Home");
				scene.Place = "Kitchen";
				scene.Time = "Evening";
				scene.Variables.Add (ServerVariablesConsts.EveningDinner_Croissant_Table);
				scene.Variables.Add (ServerVariablesConsts.EveningDinner_CheeseSandwich_Table);
				scene.FoodItems.Add (Constants.Croissant);
				scene.FoodItems.Add (Constants.CheeseSandwich);
				scene.constVariable.Add (Constants.Croissant, ServerVariablesConsts.EveningDinner_Croissant_Table);
				scene.constVariable.Add (Constants.CheeseSandwich, ServerVariablesConsts.EveningDinner_CheeseSandwich_Table);
				return scene;
			case 2:
				var scene2 = new Scene ("Dinner Home");
				scene2.Place = "Kitchen";
				scene2.Time = "Evening";
				scene2.Variables.Add (ServerVariablesConsts.EveningDinner_Soup_Table);
				scene2.FoodItems.Add (Constants.Soup);
				scene2.FoodItems.Add (Constants.Mom);
				scene2.constVariable.Add (Constants.Soup, ServerVariablesConsts.EveningDinner_Soup_Table);
				return scene2;
			default:
				var scene3 = new Scene ("Dinner Home");
				scene3.Place = "Kitchen";
				scene3.Time = "Evening";
				scene3.Variables.Add (ServerVariablesConsts.EveningDinner_OneEgg_Table);
				scene3.Variables.Add (ServerVariablesConsts.EveningDinner_ThreeEggs_Table);
				scene3.Variables.Add (ServerVariablesConsts.EveningDinner_TwoEggs_Table);
				scene3.FoodItems.Add (Constants.OneEgg);
				scene3.FoodItems.Add (Constants.TwoEggs);
				scene3.FoodItems.Add (Constants.ThreeEggs);
				scene3.constVariable.Add (Constants.OneEgg, ServerVariablesConsts.EveningDinner_OneEgg_Table);
				scene3.constVariable.Add (Constants.TwoEggs, ServerVariablesConsts.EveningDinner_ThreeEggs_Table);
				scene3.constVariable.Add (Constants.ThreeEggs, ServerVariablesConsts.EveningDinner_TwoEggs_Table);
				return scene3;
			}
		}
	}
}