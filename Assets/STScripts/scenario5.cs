using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.STScripts
{
	public class Scenario5 : MonoBehaviour
	{
		public GameObject ChoiceLeave;
		// Use this for initialization
		private void Start()
		{
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
	}
}