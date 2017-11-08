using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour {
	
	public void AdventureStart() {
		SceneManager.LoadScene("TetriX");
	}

	public void ClassicStart() {
		SceneManager.LoadScene("Classic");
	}

	public void OptionStart() {
		SceneManager.LoadScene("Options");
	}

	// Use this for initialization
	void Start () {
		if (!PlayerPrefs.HasKey("TouchPlay"))
			PlayerPrefs.SetInt("TouchPlay", 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
