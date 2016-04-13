using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Globalization;

public class scenario1 : MonoBehaviour, IDrop{

	public GameObject door;
	public GameObject openDoor;
	public GameObject sandwich;
	public GameObject croissant;
	public GameObject ChoiceLeave;
	public GameObject Text;

	// Use this for initialization
	void Start () {
		openDoor.SetActive (false);
		setCalendar ();
	}

	private void setCalendar(){
		Text t = Text.GetComponent<Text> ();
		t.text = System.DateTime.Today.Day+" "+
			CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(System.DateTime.Today.Month);
	}

	private void OpenDoor(){
		door.SetActive (false);
		openDoor.SetActive (true);
	}

	private void CloseDoor(){
		openDoor.SetActive (false);
		door.SetActive (true);
	}

	public void Chosen(string item){
		InvokeRepeating ("Exit", 0, 0.6f);
		//Destroy (sandwich.GetComponent<Draggable>());
		//Destroy (croissant.GetComponent<Draggable>());
		//openDoor.SetActive (false);
		//door.SetActive (true);
		//door.GetComponent<Button>().interactable = false;
	}

	public void next(){
		SceneManager.LoadScene ("scenario2");
	}

	void Exit(){
		ChoiceLeave.GetComponent<Button> ().image.canvasRenderer.SetAlpha(1);
		ChoiceLeave.GetComponent<Button> ().image.CrossFadeAlpha (0.5f, 0.6f, false);
	}
}