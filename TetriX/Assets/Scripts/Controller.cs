using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour {
	public bool Right;
	public bool Left;
	public bool Up;
	public bool Down;
	public bool paused = false;
	private static AudioSource backSound;


	public void onClickLeft () {
		Left = true;
	}
	public void onClickRight () {
		Right = true;
	}
	public void onClickUp () {
		Up = true;
	}
	public void onClickDown () {
		Down = true;
	}
	public void toPause() {
		if(!paused){
			Time.timeScale = 0;
			paused = true;
			backSound.Pause();
		}else{
			Time.timeScale = 1;
			paused = false;
			backSound.Play();
		}
	}
	public void toReturn() {
		SceneManager.LoadScene("MainMenu");
	}
	// Use this for initialization
	void Start () {
		backSound = GameObject.Find ("Backgound sound").GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	}
}
