using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class scenario3 : MonoBehaviour {
	public GameObject manouche;
	public GameObject candy;
	public GameObject lentilSoup;
	public GameObject chips;
	public GameObject ChoiceLeave;

	public void Chosen(string item){
		Destroy (manouche.GetComponent<Draggable>());
		Destroy (candy.GetComponent<Draggable>());
		Destroy (lentilSoup.GetComponent<Draggable>());
		Destroy (chips.GetComponent<Draggable>());
	}

	public void next(){
		SceneManager.LoadScene ("feedback");
	}
}