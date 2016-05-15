using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Assets.src;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = System.Random;

namespace Assets.STScripts
{
	public class Scenario1 : AbstractScenario, IDrop
	{
		public GameObject Canvas;
		public GameObject ChoiceLeave;
		public GameObject Door;
		public GameObject GoBoy;
		public GameObject GoCroissant;
		public GameObject GoGirl;
		public GameObject GoLabnehWithVegetables;
		public GameObject GoMediumSandwich;
		public GameObject GoMother;
		public GameObject GoSandwich;
		public GameObject GoSmallSandwich;
		public GameObject DoorOpen;
		private float _savedTimeScale;
		public GameObject Text;

		// Use this for initialization
		private void Start()
		{
			Canvas.GetComponent<AudioSource>().Play();
			//*****
			//Session.Age = 8;
			//int rand = new Random().Next(10);
			//Session.Gender = rand <=5 ? Constants.Boy : Constants.Girl;
			//****
			AbstractStart();

			//Debug.Log("SSSS");
			//var someRequest = new Request("get", "http://jsonplaceholder.typicode.com/posts");
			//someRequest.Send(request =>
			//{
				// parse some JSON, for example:
				//Debug.Log(request.response.Text);
				//var filePath = @"Game_Result" /*+ @System.DateTime.Now.ToString()*/+ ".txt";
				//string delimiter = ",";
				//File.WriteAllText(filePath, request.Response.Text);
			//});

			//Save s = new Save();
			//var ass = s.SomeRoutine();
			//Debug.Log("EEEE" + ass);
			DoorOpen.SetActive(false);

			//Debug.Log (session.Age +" " + session.Gender);
			SetCalendar();
		}

		public void Chosen(string item)
		{
			InvokeRepeating("Exit", 0, 0.6f);
			AbstractChoose(item);
		}

		public void OpenDoor()
		{
			Door.SetActive(false);
			DoorOpen.SetActive(true);
		}

		public void CloseDoor()
		{
			DoorOpen.SetActive(false);
			Door.SetActive(true);
		}

		public void Next()
		{
			AbstractNext("Transition2");
		}
			
		protected override void InitMap()
		{
			Map = new Dictionary<string, GameObject>
			{
				{Constants.Boy, GoBoy},
				{Constants.Girl, GoGirl},
				{Constants.Mom, GoMother},
				{Constants.Croissant, GoCroissant},
				{Constants.Sandwich, GoSandwich},
				{Constants.LabnehVegetables, GoLabnehWithVegetables},
				{Constants.SmallSand, GoSmallSandwich},
				{Constants.MediumSand, GoMediumSandwich}
			};
		}

		private void SetCalendar()
		{
			var t = Text.GetComponent<Text>();
			t.text = DateTime.Today.Day + " " +
			         CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Today.Month);
		}
			
		private void Exit()
		{
			ChoiceLeave.GetComponent<Button>().image.canvasRenderer.SetAlpha(1);
			ChoiceLeave.GetComponent<Button>().image.CrossFadeAlpha(0.5f, 0.6f, false);
		}
	}
}