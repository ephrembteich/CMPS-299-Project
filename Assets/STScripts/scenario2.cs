using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class scenario2 : MonoBehaviour, IDrop{

	public GameObject manouche;
	public GameObject banana;
	public GameObject custard;
	public GameObject chips;
	public GameObject ChoiceLeave;

	public void Chosen(string item){
		InvokeRepeating ("Exit", 0, 0.6f);
		Destroy (manouche.GetComponent<Draggable>());
		Destroy (banana.GetComponent<Draggable>());
		Destroy (custard.GetComponent<Draggable>());
		Destroy (chips.GetComponent<Draggable>());
	}

	public void next(){
		SceneManager.LoadScene ("transition3");
	}

	void Exit(){
		ChoiceLeave.GetComponent<Button> ().image.canvasRenderer.SetAlpha(1);
		ChoiceLeave.GetComponent<Button> ().image.CrossFadeAlpha (0.5f, 0.6f, false);
	}
}