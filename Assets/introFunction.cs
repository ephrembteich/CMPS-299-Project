using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class introFunction : MonoBehaviour {

	private int age;
	private string gender;
	public GameObject nextBtn;
	public GameSession session;

	// Use this for initialization
	void Start () {
		session = GameSession.getSession ();
	}

	// Update is called once per frame
	void Update () {

	}

	public void setAge(int param){
		session.Age = param;
		age = param;
		if(gender!= null){
			nextBtn.GetComponentInChildren<Button> ().interactable = true;
		}
	}

	public void setGender(string param){
		session.Gender = param;
		gender = param;
		if(age != 0){
			nextBtn.GetComponentInChildren<Button> ().interactable = true;
		}
	}

	public void next(){
		SceneManager.LoadScene("transition1");
	}
}