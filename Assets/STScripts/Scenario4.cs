using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Globalization;
using System;
using System.Collections.Generic;

namespace Assets.STScripts
{
	public class Scenario4 : AbstractScenario, IDrop
	{
		public GameObject door;
		public GameObject openDoor;
		public GameObject ChoiceLeave;
		public GameObject Tray;
		public GameObject Text;
		public GameObject GoStew;
		public GameObject GoPizza;
		public GameObject GoSalad;
		public GameObject GoSimpleSalad;
		public GameObject GoMediumPizza;
		public GameObject GoSmallPizza;
		public GameObject GoMother;
		public GameObject GoBoy;
		public GameObject GoGirl;

		public void Start(){
			SetCalendar();
			AbstractStart();
		}
			
		public void Chosen(string item)
		{
			InvokeRepeating("Exit", 0, 0.6f);
			AbstractChoose(item);
		}

		public void Next(){
			AbstractNext("Transition5");
		}
			
		public void OpenDoor(){
			door.SetActive (false);
			openDoor.SetActive (true);
		}

		public void CloseDoor(){
			openDoor.SetActive (false);
			door.SetActive (true);
		}

		protected override void InitMap()
		{
			Map = new Dictionary<string, GameObject>
			{
				{Constants.Boy, GoBoy},
				{Constants.Girl, GoGirl},
				{Constants.Mom, GoMother},
				{Constants.SmallPizza, GoSmallPizza},
				{Constants.MediumPizza, GoMediumPizza},
				{Constants.SimpleSalad, GoSimpleSalad},
				{Constants.Salad, GoSalad},
				{Constants.Pizza, GoPizza},
				{Constants.Stew, GoStew}
			};
		}

		private void SetCalendar()
		{
			var t = Text.GetComponent<Text>();
			t.text = DateTime.Today.Day + " " +
				CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Today.Month);
		}

		private void Exit(){
			ChoiceLeave.GetComponent<Button>().image.canvasRenderer.SetAlpha(1);
			ChoiceLeave.GetComponent<Button>().image.CrossFadeAlpha(0.5f, 0.6f, false);
		}
	}
}