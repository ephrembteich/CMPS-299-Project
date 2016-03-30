using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class scenario2 : MonoBehaviour{

	public GameObject manouche;
	public GameObject banana;
	public GameObject custard;
	public GameObject chips;
	public GameObject ChoiceLeave;

	public void Chosen(string item){
		Destroy (manouche.GetComponent<Draggable>());
		Destroy (banana.GetComponent<Draggable>());
		Destroy (custard.GetComponent<Draggable>());
		Destroy (chips.GetComponent<Draggable>());
	}

	public void next(){
		SceneManager.LoadScene ("scenario3");
	}
}