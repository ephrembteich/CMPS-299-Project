using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class scenario3 : MonoBehaviour, IDrop {
	public GameObject manouche;
	public GameObject candy;
	public GameObject lentilSoup;
	public GameObject chips;
	public GameObject ChoiceLeave;

	public void Chosen(string item){
		InvokeRepeating ("Exit", 0, 0.6f);
		Destroy (manouche.GetComponent<Draggable>());
		Destroy (candy.GetComponent<Draggable>());
		Destroy (lentilSoup.GetComponent<Draggable>());
		Destroy (chips.GetComponent<Draggable>());
	}

	public void next(){
		SceneManager.LoadScene ("feedback");
	}

	void Exit(){
		ChoiceLeave.GetComponent<Button> ().image.canvasRenderer.SetAlpha(1);
		ChoiceLeave.GetComponent<Button> ().image.CrossFadeAlpha (0.5f, 0.6f, false);
	}
}