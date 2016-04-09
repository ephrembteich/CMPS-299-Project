using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class introFunction : MonoBehaviour {

	private int age = 0;
	private string gender = null;
	public GameObject nextBtn;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void setAge(int param){
		age = param;
		if(gender!=null){
			nextBtn.GetComponentInChildren<Button> ().interactable = true;
		}
	}

	public void setGender(string param){
		gender = param;
		if(age!=0){
			nextBtn.GetComponentInChildren<Button> ().interactable = true;
		}
	}

	public void next(){
		SceneManager.LoadScene("scenario1");
	}
}