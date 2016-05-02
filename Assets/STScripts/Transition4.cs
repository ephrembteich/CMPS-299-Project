﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.STScripts{
	public class Transition4 : MonoBehaviour{
		public GameObject Canvas;
		public Image Image;
		public Sprite SecondImg;
		public Sprite ThirdImg;

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
			SceneManager.LoadScene("Scenario4");
		}
	}
}