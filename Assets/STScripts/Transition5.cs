﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.STScripts{
	public class Transition5 : MonoBehaviour{
		public GameObject Canvas;
		public Image Image;
		public Sprite SecondImg;

		private void Start(){
			Invoke ("GetImg2", 3.2F);
			Invoke ("Next", 8.2F);
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
			SceneManager.LoadScene("Scenario5");
		}
	}
}