using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.STScripts
{
	public class Transition1 : MonoBehaviour
	{
		public GameObject Canvas;
		public Image Image;
		public Sprite SecondImg;
		public Sprite ThirdImg;

		private void Start()
		{
			Invoke("GetImg2", 4);
			Invoke("Next", 7.5F);
		}
<<<<<<< HEAD
			
		void Update(){
			if (Input.GetMouseButtonDown (0) || Input.GetMouseButtonDown (1) || Input.GetMouseButtonDown (2)) {
				Next ();
			}
		}

		void getImg2(){
=======

		public void GetImg2()
		{
>>>>>>> 0ec943e2134124747fff0a33a9a47f91796f07da
			Image.sprite = SecondImg;
		}

		private void Next()
		{
			SceneManager.LoadScene("Scenario1");
		}
	}
}