using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.STScripts
{
	public class Scenario3 : MonoBehaviour, IDrop
	{
		public GameObject Candy;
		public GameObject Chips;
		public GameObject ChoiceLeave;
		public GameObject LentilSoup;
		public GameObject Manouche;

		public void Chosen(string item)
		{
			InvokeRepeating("Exit", 0, 0.6f);
			Destroy(Manouche.GetComponent<Draggable>());
			Destroy(Candy.GetComponent<Draggable>());
			Destroy(LentilSoup.GetComponent<Draggable>());
			Destroy(Chips.GetComponent<Draggable>());
		}

		public void Next()
		{
			SceneManager.LoadScene("Transition4");
		}

		private void Exit()
		{
			ChoiceLeave.GetComponent<Button>().image.canvasRenderer.SetAlpha(1);
			ChoiceLeave.GetComponent<Button>().image.CrossFadeAlpha(0.5f, 0.6f, false);
		}
	}
}