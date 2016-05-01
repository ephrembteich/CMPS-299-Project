using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.STScripts
{
	public class Scenario2 : AbstractScenario, IDrop
	{
		public GameObject Banana;
		public GameObject Chips;
		public GameObject ChoiceLeave;
		public GameObject Custard;
		public GameObject Manouche;

		public void Chosen(string item)
		{
			InvokeRepeating("Exit", 0, 0.6f);
			Destroy(Manouche.GetComponent<Draggable>());
			Destroy(Banana.GetComponent<Draggable>());
			Destroy(Custard.GetComponent<Draggable>());
			Destroy(Chips.GetComponent<Draggable>());
			AbstractChoose(item);
		}

		public void Start()
		{
			AbstractStart();
		}

		public void Next()
		{
			AbstractNext("Transition3");
		}

		private void Exit()
		{
			ChoiceLeave.GetComponent<Button>().image.canvasRenderer.SetAlpha(1);
			ChoiceLeave.GetComponent<Button>().image.CrossFadeAlpha(0.5f, 0.6f, false);
		}

		protected override void InitMap()
		{

		}
	}
}