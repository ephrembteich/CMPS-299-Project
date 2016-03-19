using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class introFunction : MonoBehaviour {

	private int age = 0;
	private int gender = 0;
	public GameObject nextBtn;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {

	}

	public void setAge(int param){
		age = param;
		if(gender!=0){
			nextBtn.GetComponentInChildren<Button> ().interactable = true;
		}
	}

	public void setGender(int param){
		gender = param;
		if(age!=0){
			nextBtn.GetComponentInChildren<Button> ().interactable = true;
		}
	}

	public void next(){
		SceneManager.LoadScene("randomLevel");
	}
}