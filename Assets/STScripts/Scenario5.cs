using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.STScripts
{
<<<<<<< HEAD
	public class Scenario5 : AbstractScenario, IDrop
=======
	public class Scenario5 : MonoBehaviour
>>>>>>> 0ec943e2134124747fff0a33a9a47f91796f07da
	{
		public GameObject ChoiceLeave;
		// Use this for initialization
		private void Start()
		{
		}
<<<<<<< HEAD

		public void Chosen(string item)
		{
			InvokeRepeating("Exit", 0, 0.6f);
			AbstractChoose(item);
		}
=======
>>>>>>> 0ec943e2134124747fff0a33a9a47f91796f07da

		// Update is called once per frame
		private void Update()
		{
		}

		public void Next()
		{
			SceneManager.LoadScene("Feedback");
		}
<<<<<<< HEAD

		private void Exit()
		{
			ChoiceLeave.GetComponent<Button>().image.canvasRenderer.SetAlpha(1);
			ChoiceLeave.GetComponent<Button>().image.CrossFadeAlpha(0.5f, 0.6f, false);
		}

		protected override void InitMap()
		{

=======

		private void Exit()
		{
			ChoiceLeave.GetComponent<Button>().image.canvasRenderer.SetAlpha(1);
			ChoiceLeave.GetComponent<Button>().image.CrossFadeAlpha(0.5f, 0.6f, false);
>>>>>>> 0ec943e2134124747fff0a33a9a47f91796f07da
		}
	}
}