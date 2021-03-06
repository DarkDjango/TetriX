﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour {

	private static AudioSource click;

	public void AdventureStart() {
		click.Play();
		SceneManager.LoadScene("CharacterSelect");
	}

	public void ClassicStart() {
		click.Play();
		SceneManager.LoadScene("Classic");
	}

	public void OptionStart() {
		SceneManager.LoadScene("Options");
	}

	// Use this for initialization
	void Start () {

		click = GameObject.Find ("Click").GetComponent<AudioSource> ();

		if (!PlayerPrefs.HasKey("TouchPlay"))
			PlayerPrefs.SetInt("TouchPlay", 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
