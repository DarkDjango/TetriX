using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flash : MonoBehaviour {
	Image sr;
	private bool BeingHandled = false;
	public bool endStage = false;
	// Use this for initialization
	public void FlashBang () {
		sr.color = new Color (1, 1, 1, 1);
	}
	private IEnumerator HandleIt ()
	{
		BeingHandled = true;
		yield return new WaitForSeconds (0.1f);
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
