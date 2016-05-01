using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class transition3 : MonoBehaviour {

	public GameObject canvas;
	public Image image;
	public Sprite secondImg;
	public Sprite thirdImg;

	void Start(){
		Invoke ("getImg2", 4);
		Invoke ("next", 7.5F);
	}

	void Update(){
		if (Input.GetMouseButtonDown (0) || Input.GetMouseButtonDown (1) || Input.GetMouseButtonDown (2)) {
			next ();
		}
	}

	void getImg2(){
		image.sprite = secondImg;
	}

	private void next(){
		SceneManager.LoadScene ("scenario3");
	}
}