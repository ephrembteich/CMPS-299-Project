using UnityEngine;
using System.Collections;
using Assets;
using Assets.src;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainScene : MonoBehaviour {

	public InputField mainInputField;
	public GameObject playBtn;

	// Use this for initialization
	void Start () {
		//Debug.Log("SSSS");
		//var someRequest = new Request("get", "http://localhost:22355/api/Variable");
		//someRequest.Send(request =>
		//{
		//	//parse some JSON, for example:
		//	Debug.Log(request.Response.Text);

		//});

		Debug.Log("llll");
		ServerVariable variable = new ServerVariable("falafel", 90);
		variable.Description = "Blah";

		ServerGameSession server = new ServerGameSession("Yehya", "Girl", 21);
		server.Variables.Add(new ServerVariable("Breakfast_LabnehOlives_Fridge", 1));
		server.Variables.Add(new ServerVariable("Breakfast_SandwichSmall_Table", 4));

		server.Choices.Add(new ServerVariable("Breakfast_SandwichSmall_Table", 4));
		Debug.Log(JsonUtility.ToJson(server));
		var theRequest = new Request("post", "http://localhost:22355/api/GameSessions", JsonUtility.ToJson(server));
		theRequest.Send((request) =>
		{

			// we provide Object and Array convenience methods that attempt to parse the response as JSON
			// if the response cannot be parsed, we will return null
			// note that if you want to send json that isn't either an object ({...}) or an array ([...])
			// that you should use JSON.JsonDecode directly on the response.Text, Object and Array are
			// only provided for convenience
			Hashtable result = request.Response.Object;
			if (result == null)
			{
				Debug.LogWarning("Could not parse JSON response!");
				return;
			}
			Debug.Log(result);

		});
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
