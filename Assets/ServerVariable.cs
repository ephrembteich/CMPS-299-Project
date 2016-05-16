using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets
{
	[Serializable]
	public class ServerVariable
	{
		public String Name;

		public String Description;

		public int VariableNumber;

		public ServerVariable()
		{
		}

		public ServerVariable(String name, int variableNum)
		{
			Name = name;
			VariableNumber = variableNum;
		}

		public static List<ServerVariable> GetAllVariables()
		{
			List<ServerVariable> variables = new List<ServerVariable>
			{
				new ServerVariable("Breakfast_LabnehOlives_Fridge", 1),
				new ServerVariable("Breakfast_Sandwich_Table", 2),
				new ServerVariable("Breakfast_SandwichLarge_Table", 3),
				new ServerVariable("Breakfast_SandwichSmall_Table", 4),
				new ServerVariable("Breakfast_SandwichMedium_Table", 5),
				new ServerVariable("Breakfast_Croissant", 6),
				new ServerVariable("Breakfast_Mother", 7),
				new ServerVariable("MorningStreet_ManousheInsideCover_Shop", 8),
				new ServerVariable("MorningStreet_ManousheOnTable_Shop", 9),
				new ServerVariable("MorningStreet_Chips_Shop", 10),
				new ServerVariable("MorningStreet_Custard_Shop", 11),
				new ServerVariable("MorningStreet_Banana_Shop", 12),
				new ServerVariable("MorningStreet_Manoushe_Shop", 13),
				new ServerVariable("MorningStreet_FriendWithAManoushe_Shop", 14),
				new ServerVariable("MorningStreet_Manoushe500_Shop", 15),
				new ServerVariable("MorningStreet_Manoushe250_Shop", 16),
				new ServerVariable("MorningStreet_Manoushe100_Shop", 17),
				new ServerVariable("MorningStreet_ManousheSmall_Shop", 18),
				new ServerVariable("MorningStreet_ManousheMedium_Shop", 19),
				new ServerVariable("MorningStreet_ManousheLarge_Shop", 20),
				new ServerVariable("RecessSchool_ManousheInsideCover_Shop", 21),
				new ServerVariable("RecessSchool_ManousheOnTable_Shop", 22),
				new ServerVariable("RecessSchool_Manoushe_Shop", 23),
				new ServerVariable("RecessSchool_LentilSoup_Shop", 24),
				new ServerVariable("RecessSchool_Chips_Shop", 25),
				new ServerVariable("RecessSchool_Candy_Shop", 26),
				new ServerVariable("RecessSchool_FriendWithManoushe_Shop", 27),
				new ServerVariable("RecessSchool_Manoushe500_Shop", 28),
				new ServerVariable("RecessSchool_Manoushe250_Shop", 29),
				new ServerVariable("RecessSchool_Manoushe100_Shop", 30),
				new ServerVariable("RecessSchool_ManousheSmall_Shop", 31),
				new ServerVariable("RecessSchool_ManousheMedium_Shop", 32),
				new ServerVariable("RecessSchool_ManousheLarge_Shop", 33),
				new ServerVariable("LunchHome_SimpleSalad_Table", 34),
				new ServerVariable("LunchHome_ClassicSalad_Fridge", 35),
				new ServerVariable("LunchHome_Stew_Table", 36),
				new ServerVariable("LunchHome_Pizza_Table", 37),
				new ServerVariable("LunchHome_Mother_Kitchen", 38),
				new ServerVariable("LunchHome_SmallPizza_Table", 39),
				new ServerVariable("LunchHome_MediumPizza_Table", 40),
				new ServerVariable("LunchHome_LargePizza_Table", 41),
				new ServerVariable("EveningDinner_CheeseSandwich_Table", 42),
				new ServerVariable("EveningDinner_CheeseSandwichIngredients_Fridge", 43),
				new ServerVariable("EveningDinner_Croissant_Table", 44),
				new ServerVariable("EveningDinner_Soup_Table", 45),
				new ServerVariable("EveningDinner_Mother_Kitchen", 46),
				new ServerVariable("EveningDinner_OneEgg_Table", 47),
				new ServerVariable("EveningDinner_TwoEggs_Table", 48),
				new ServerVariable("EveningDinner_ThreeEggs_Table", 49)
			};
			return variables;
		}
	}
}
