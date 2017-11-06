using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class OptionsMenu : MonoBehaviour {
	
	public void BackToMainMenu () {
		SceneManager.LoadScene("MainMenu");
	}
	public void TouchPlay () {
		if (PlayerPrefs.GetInt ("TouchPlay") == 0) {
			PlayerPrefs.SetInt ("TouchPlay",1);
		} else {
			PlayerPrefs.SetInt ("TouchPlay",0);
		}
	}
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}
}
