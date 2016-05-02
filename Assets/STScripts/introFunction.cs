using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets
{
	public class IntroFunction : MonoBehaviour
	{
		private int age;
		private string gender;
		public GameObject NextBtn;
		public GameSession Session;
		// Use this for initialization
		private void Start()
		{
			Session = GameSession.GetSession();
		}

		// Update is called once per frame
		private void Update()
		{
		}

		public void SetAge(int param)
		{
			Session.Age = param;
			age = param;
			if (gender != null)
			{
				NextBtn.GetComponentInChildren<Button>().interactable = true;
			}
		}

		public void SetGender(string param)
		{
			Session.Gender = param;
			gender = param;
			if (age != 0)
			{
				NextBtn.GetComponentInChildren<Button>().interactable = true;
			}
		}

		public void Next()
		{
			SceneManager.LoadScene("Transition1");
		}
	}
}