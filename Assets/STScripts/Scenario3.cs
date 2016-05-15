using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;

namespace Assets.STScripts
{
	public class Scenario3 : AbstractScenario, IDrop
	{
		public GameObject GoPriceTag1;
		public GameObject GoPriceTag2;
		public GameObject GoPriceTag3;
		public GameObject GoPriceTag4;
		public GameObject GoPriceTag250LL;
		public GameObject GoPriceTag100LL;
		public GameObject GoBoy;
		public GameObject GoGirl;
		public GameObject GoFriend;
		public GameObject Tray;
		public GameObject GoChips;
		public GameObject GoCandy;
		public GameObject GoLentilSoup;
		public GameObject GoManouche1;
		public GameObject GoManouche2;
		public GameObject GoManouche3;
		public GameObject GoManoucheMedium;
		public GameObject GoManoucheSmall;
		public GameObject ChoiceLeave;

		public void Start()
		{
			AbstractStart();
		}

		public void Chosen(string item)
		{
			InvokeRepeating("Exit", 0, 0.6f);
			AbstractChoose(item);
		}

		public void Next()
		{
			AbstractNext("Transition4");
		}

		protected override void InitMap()
		{
			Map = new Dictionary<string, GameObject>
			{
				{Constants.Boy, GoBoy},
				{Constants.Girl, GoGirl},
				{Constants.Friend, GoFriend},
				{Constants.PriceTag1, GoPriceTag1},
				{Constants.PriceTag2, GoPriceTag2},
				{Constants.PriceTag3, GoPriceTag3},
				{Constants.PriceTag4, GoPriceTag4},
				{Constants.PriceTag5, GoPriceTag250LL},
				{Constants.PriceTag6, GoPriceTag100LL},
				{Constants.Candy, GoCandy},
				{Constants.Chips, GoChips},
				{Constants.LentilSoup, GoLentilSoup},
				{Constants.Manouche1, GoManouche1},
				{Constants.Manouche2, GoManouche2},
				{Constants.Manouche3, GoManouche3},
				{Constants.ManoucheMedium, GoManoucheMedium},
				{Constants.ManoucheSmall, GoManoucheSmall}
			};
		}

		private void Exit()
		{
			ChoiceLeave.GetComponent<Button>().image.canvasRenderer.SetAlpha(1);
			ChoiceLeave.GetComponent<Button>().image.CrossFadeAlpha(0.5f, 0.6f, false);
		}
	}
}