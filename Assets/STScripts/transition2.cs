using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class transition2 : MonoBehaviour {

	public GameObject canvas;
	public Image image;
	public Sprite secondImg;
	public Sprite thirdImg;

	void Start(){
		//Invoke ("getImg2", 4);
		Invoke ("next", 1F);
	}

	void getImg2(){
		image.sprite = secondImg;
	}

	private void next(){
		SceneManager.LoadScene ("scenario2");
	}
}
