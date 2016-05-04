using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainScene : MonoBehaviour {

	public InputField mainInputField;
	public GameObject playBtn;

	// Use this for initialization
	void Start () {
		mainInputField.contentType = InputField.ContentType.Alphanumeric;
	}
	
	// Update is called once per frame
	void Update () {
		if (mainInputField.text == "") {
			playBtn.GetComponentInChildren<Button> ().interactable = false;
		} else {
			playBtn.GetComponentInChildren<Button> ().interactable = true;
		}
	}

	public void Play(){
		//to retract the id of the child take the below param
		//mainInputField.text
		SceneManager.LoadScene("introLevel");
	}
}
