using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;

namespace Assets.STScripts
{
	public class Scenario5 : AbstractScenario, IDrop
	{
		public GameObject ChoiceLeave;
		public GameObject GoBoy;
		public GameObject GoGirl;
		public GameObject GoMother;
		public GameObject GoCheeseSandwich;
		public GameObject GoCroissant;
		public GameObject GoSoup;
		public GameObject GoOneEgg;
		public GameObject GoTwoEggs;
		public GameObject GoThreeEggs;

		// Use this for initialization
		private void Start()
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
			SceneManager.LoadScene("Feedback");
		}

		protected override void InitMap()
		{
			Map = new Dictionary<string, GameObject>
			{
				{Constants.Boy, GoBoy},
				{Constants.Girl, GoGirl},
				{Constants.Mom, GoMother},
				{Constants.CheeseSandwich, GoCheeseSandwich},
				{Constants.Croissant, GoCroissant},
				{Constants.Soup, GoSoup},
				{Constants.OneEgg, GoOneEgg},
				{Constants.TwoEggs, GoTwoEggs},
				{Constants.ThreeEggs, GoThreeEggs}
			};
		}

		private void Exit()
		{
			ChoiceLeave.GetComponent<Button>().image.canvasRenderer.SetAlpha(1);
			ChoiceLeave.GetComponent<Button>().image.CrossFadeAlpha(0.5f, 0.6f, false);
		}
	}
}