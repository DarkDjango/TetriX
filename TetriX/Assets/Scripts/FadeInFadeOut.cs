﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInFadeOut : MonoBehaviour {
	private SpriteRenderer sr;
	private bool BeingHandled = false;
	public bool fadeIn;
	public bool fadeOut;
	private IEnumerator HandleIt ()
	{
		BeingHandled = true;
		yield return new WaitForSeconds (0.1f);
		if ((fadeOut)&&(sr.color != new Color (0, 0, 0, 0)))
			sr.color -= new Color (0, 0, 0, 0.1f);
		else if ((fadeIn)&&(sr.color != new Color (0, 0, 0, 1)))
			sr.color += new Color (0, 0, 0, 0.1f);
		BeingHandled = false;
	}

	void Start() {
		fadeIn = false;
		fadeOut = false;
		sr = gameObject.GetComponent<SpriteRenderer>(); 

	}
	void Update () {
		if (!BeingHandled) {
			StartCoroutine (HandleIt ());
		}
	}
}