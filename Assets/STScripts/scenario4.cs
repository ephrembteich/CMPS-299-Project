using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.STScripts
{
	public class Scenario4 : AbstractScenario, IDrop
	{
		public GameObject door;
		public GameObject openDoor;
		public GameObject ChoiceLeave;
		public GameObject Tray;

		public void Start(){
			InvokeRepeating("TrayAnimation", 0, 0.6f);
		}

		public void Next(){
			SceneManager.LoadScene("Transition5");
		}

		public void Chosen(string item)
		{
			InvokeRepeating("Exit", 0, 0.6f);
			AbstractChoose(item);
		}

		public void OpenDoor(){
			door.SetActive (false);
			openDoor.SetActive (true);
		}

		public void CloseDoor(){
			openDoor.SetActive (false);
			door.SetActive (true);
		}

		private void TrayAnimation(){
			
		}

		private void Exit(){
			ChoiceLeave.GetComponent<Button>().image.canvasRenderer.SetAlpha(1);
			ChoiceLeave.GetComponent<Button>().image.CrossFadeAlpha(0.5f, 0.6f, false);
		}

		protected override void InitMap()
		{

		}
	}
}