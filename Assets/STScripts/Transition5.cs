using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.STScripts
{
	public class Transition5 : MonoBehaviour
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

		void getImg2(){
=======
		private void Start()
		{
			//Invoke ("getImg2", 4);
			Invoke("Next", 1F);
		}

		private void GetImg2()
		{
>>>>>>> 0ec943e2134124747fff0a33a9a47f91796f07da
			Image.sprite = SecondImg;
		}

		private void Next()
		{
			SceneManager.LoadScene("Scenario5");
		}
	}
}