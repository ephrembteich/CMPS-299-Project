using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.STScripts
{
	public class Transition3 : MonoBehaviour
	{
		public GameObject Canvas;
		public Image Image;
		public Sprite SecondImg;

		void Start(){
			Invoke ("GetImg2", 3F);
			Invoke ("Next", 7.5F);
		}

		void Update(){
			if (Input.GetMouseButtonDown (0) || Input.GetMouseButtonDown (1) || Input.GetMouseButtonDown (2)) {
				Next ();
			}
		}

		private void GetImg2()
		{
			Image.sprite = SecondImg;
		}

		private void Next()
		{
			SceneManager.LoadScene("Scenario3");
		}
	}
}