using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bubbles : MonoBehaviour {
	Image sr;
	Time time;
	private bool BeingHandled = false;
	private bool bluescreen = false;

	// Use this for initialization
	public void BlueBubbles() {
		
		sr.color = new Color (0, 0.5f, 1, 0.25f);
		bluescreen = true;
		Debug.Log("BLUE SCREEN");
	}

	private IEnumerator HandleIt ()
	{
		BeingHandled = true;
		if (bluescreen) {
			yield return new WaitForSeconds (1.25f);
			bluescreen = false;
		}
		yield return new WaitForSeconds (0.05f);
		sr.color -= new Color (0, 0, 0, 0.1f);
		BeingHandled = false;
	}
		
	void Start() {
		sr = gameObject.GetComponent<Image>(); 

	}
	void Update () {
		if (!BeingHandled) {
			StartCoroutine (HandleIt ());
		}

	}
}
