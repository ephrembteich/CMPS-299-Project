using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class scenario4 : MonoBehaviour {

	public GameObject door;
	public GameObject openDoor;
	public GameObject ChoiceLeave;

	// Use this for initialization
	void Start () {
		openDoor.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OpenDoor(){
		door.SetActive (false);
		openDoor.SetActive (true);
	}

	public void CloseDoor(){
		openDoor.SetActive (false);
		door.SetActive (true);
	}

	public void next(){
		SceneManager.LoadScene ("transition5");
	}

	void Exit(){
		ChoiceLeave.GetComponent<Button> ().image.canvasRenderer.SetAlpha(1);
		ChoiceLeave.GetComponent<Button> ().image.CrossFadeAlpha (0.5f, 0.6f, false);
	}
}
