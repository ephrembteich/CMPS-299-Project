using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;

namespace Assets.STScripts
{
	public class Scenario2 : AbstractScenario, IDrop
	{
		public GameObject GoBanana;
		public GameObject GoChips;
		public GameObject ChoiceLeave;
		public GameObject GoCustard;
		public GameObject GoManouche1;
		public GameObject GoManouche2;
		public GameObject GoManouche3;
		public GameObject GoFriend;
		public GameObject GoBoy;
		public GameObject GoGirl;
		public GameObject Tray;
		public GameObject GoCoverOpened;
		public GameObject GoCoverClosed;
		public GameObject GoPriceTag1;
		public GameObject GoPriceTag2;
		public GameObject GoPriceTag3;
		public GameObject GoPriceTag4;
		public GameObject GoPriceTag5;
		public GameObject GoPriceTag6;

		private bool invoked = false;

		public void Start()
		{
			AbstractStart();
		}
			
		public void Update(){
			/*if(Tray.transform.childCount==0 && !invoked){
				InvokeRepeating("TrayAnimation", 0, 0.6f);
				invoked = true;
			}else if(Tray.transform.childCount>0 && invoked){
				CancelInvoke("TrayAnimation");
				invoked = false;
			}*/
		}

		public void Chosen(string item)
		{
			InvokeRepeating("Exit", 0, 0.6f);
			AbstractChoose(item);
		}
			
		public void Next()
		{
			AbstractNext("Transition3");
		}
			
		public void CloseCover()
		{
			GoCoverOpened.SetActive (false);
			GoCoverClosed.SetActive (true);
		}

		public void OpenCover()
		{
			GoCoverClosed.SetActive (false);
			GoCoverOpened.SetActive (true);
		}

		protected override void InitMap()
		{
			Map = new Dictionary<string, GameObject>
			{
				{Constants.Boy, GoBoy},
				{Constants.Girl, GoGirl},
				{Constants.Banana, GoBanana},
				{Constants.Chips, GoChips},
				{Constants.Custard, GoCustard},
				{Constants.Manouche1, GoManouche1},
				{Constants.Manouche2, GoManouche2},
				{Constants.Manouche3, GoManouche3},
				{Constants.Friend, GoFriend},
				{Constants.CoverClosed, GoCoverClosed},
				{Constants.CoverOpened, GoCoverOpened},
				{Constants.PriceTag1, GoPriceTag1},
				{Constants.PriceTag2, GoPriceTag2},
				{Constants.PriceTag3, GoPriceTag3},
				{Constants.PriceTag4, GoPriceTag4},
				{Constants.PriceTag5, GoPriceTag5},
				{Constants.PriceTag6, GoPriceTag6},
			};
		}

		/*private void TrayAnimation(){
			Tray.GetComponent<Image>().canvasRenderer.SetAlpha(1);
			Tray.GetComponent<Image>().CrossFadeAlpha(0.5f, 0.6f, false);
		}*/

		private void Exit()
		{
			ChoiceLeave.GetComponent<Button>().image.canvasRenderer.SetAlpha(1);
			ChoiceLeave.GetComponent<Button>().image.CrossFadeAlpha(0.5f, 0.6f, false);
		}
	}
}