using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class scenario1 : MonoBehaviour{

	public GameObject door;
	public GameObject openDoor;
	public GameObject sandwich;
	public GameObject croissant;
	public GameObject choiceSandwich;
	public GameObject choiceCroissant;
	public GameObject ChoiceLeave;

	// Use this for initialization
	void Start () {
		openDoor.SetActive (false);
		sandwich.SetActive (false);
	}

	private void OpenDoor(){
		door.SetActive (false);
		openDoor.SetActive (true);
		sandwich.SetActive (true);
	}

	private void CloseDoor(){
		openDoor.SetActive (false);
		sandwich.SetActive (false);
		door.SetActive (true);
	}

	public void Chosen(string item){
		Destroy (sandwich.GetComponent<Draggable>());
		Destroy (croissant.GetComponent<Draggable>());
		openDoor.SetActive (false);
		door.SetActive (true);
		door.GetComponent<Button>().interactable = false;
	}

	public void next(){
		SceneManager.LoadScene ("scenario2");
	}
}