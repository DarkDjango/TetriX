using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeAndDie : MonoBehaviour {

	SpriteRenderer sr;
	Time time;
	private bool BeingHandled = false;
	bool alive;
	// Use this for initialization
	// Use this for initialization
	private IEnumerator HandleIt ()
	{
		BeingHandled = true;
		if (alive) {
			yield return new WaitForSeconds (1.25f);
			alive = false;
		}
		yield return new WaitForSeconds (0.05f);
		sr.color -= new Color (0, 0, 0, 0.1f);
		BeingHandled = false;
	}

	void Start() {
		sr = gameObject.GetComponent<SpriteRenderer>(); 
		alive = true;
	}
	void Update () {
		if (!BeingHandled) {
			StartCoroutine (HandleIt ());
		}

	}
}
