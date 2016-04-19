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
	public GameObject Canvas;

	private float savedTimeScale;

	public GameSession session;

	public Scene scene;

	// Use this for initialization
	void Start () {
		Canvas.GetComponent<AudioSource>().Play();
		session = GameSession.getSession();
		scene = new Scene ("Breakfast Home");
		scene.Place = "Kitchen";
		scene.Time = "Morning"; 
		scene.Variables.Add (new Variable("Convinene", "Croissent is availabe on the table. Labneh Sandwich is in the fridge"));
		scene.Variables.Add (new Variable("Food Type", "Labneh Croissent"));
		scene.Variables.Add (new Variable("Pressure", "Mother is not the home"));
		scene.Variables.Add (new Variable("Portion Size", "Same Portion Size"));
		session.currentScene = scene;
		//Debug.Log (session.Age +" " + session.Gender);
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
		session.currentScene.SelectedFoodItem = item;
		InvokeRepeating ("Exit", 0, 0.6f);
		//Destroy (sandwich.GetComponent<Draggable>());
		//Destroy (croissant.GetComponent<Draggable>());
		//openDoor.SetActive (false);
		//door.SetActive (true);
		//door.GetComponent<Button>().interactable = false;
	}

	public void next(){
		string result = scene.GetResult();
		session.Results.AddLast (result);
		Save.Savecsv ();
		SceneManager.LoadScene ("scenario2");
	}

	public void GenerateComb(){
		//enable
		//disable
	}

	void Exit(){
		ChoiceLeave.GetComponent<Button> ().image.canvasRenderer.SetAlpha(1);
		ChoiceLeave.GetComponent<Button> ().image.CrossFadeAlpha (0.5f, 0.6f, false);
	}
}