using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.STScripts
{
	public class Transition2 : MonoBehaviour
	{
		public GameObject Canvas;
		public Image Image;
		public Sprite SecondImg;
		public Sprite ThirdImg;

<<<<<<< HEAD
		void Start(){
			Invoke ("getImg2", 4);
			Invoke ("next", 7.5F);
		}

		void Update(){
			if (Input.GetMouseButtonDown (0) || Input.GetMouseButtonDown (1) || Input.GetMouseButtonDown (2)) {
				Next ();
			}
		}
	
=======
		private void Start()
		{
			//Invoke ("getImg2", 4);
			Invoke("Next", 1F);
		}

>>>>>>> 0ec943e2134124747fff0a33a9a47f91796f07da
		private void GetImg2()
		{
			Image.sprite = SecondImg;
		}

		private void Next()
		{
			SceneManager.LoadScene("Scenario2");
		}
	}
}