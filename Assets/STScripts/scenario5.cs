using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.STScripts
{
	public class Scenario5 : AbstractScenario, IDrop
	{
		public GameObject ChoiceLeave;
		// Use this for initialization
		private void Start()
		{
		}

		public void Chosen(string item)
		{
			InvokeRepeating("Exit", 0, 0.6f);
			AbstractChoose(item);
		}

		// Update is called once per frame
		private void Update()
		{
		}

		public void Next()
		{
			SceneManager.LoadScene("Feedback");
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