using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

<<<<<<< HEAD
namespace Assets.STScripts{
	public class Transition4 : MonoBehaviour{
=======
namespace Assets.STScripts
{
	public class Transition4 : MonoBehaviour
	{
>>>>>>> 0ec943e2134124747fff0a33a9a47f91796f07da
		public GameObject Canvas;
		public Image Image;
		public Sprite SecondImg;
		public Sprite ThirdImg;

<<<<<<< HEAD
		private void Start(){
			Invoke ("getImg2", 4);
			Invoke ("next", 7.5F);
		}
			
		void Update(){
			if (Input.GetMouseButtonDown (0) || Input.GetMouseButtonDown (1) || Input.GetMouseButtonDown (2)) {
				Next ();
			}
		}

		private void GetImg2(){
			Image.sprite = SecondImg;
		}

		private void Next(){
=======
		private void Start()
		{
			//Invoke ("getImg2", 4);
			Invoke("Next", 1F);
		}

		private void GetImg2()
		{
			Image.sprite = SecondImg;
		}

		private void Next()
		{
>>>>>>> 0ec943e2134124747fff0a33a9a47f91796f07da
			SceneManager.LoadScene("Scenario4");
		}
	}
}