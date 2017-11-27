using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstBoss : MonoBehaviour {

	UnityEngine.UI.Text txt;
	public int timer;
	private bool BeingHandled = false;
	private static Image sr;
	private static Flash flsh;
	// Use this for initialization

	void Start () {
		flsh =  GameObject.Find ("Flash").GetComponent<Flash> ();
		timer = 180;
	}
	void Update () {
		if (!BeingHandled) {
			StartCoroutine (HandleIt ());
		}
	}

	private IEnumerator HandleIt ()
		{
			BeingHandled = true;
			yield return new WaitForSeconds (1);
		if (timer > 0)
			timer--;
		else {
			flsh.endStage = true;
		}
		txt = gameObject.GetComponent<UnityEngine.UI.Text>(); 
		txt.text = timer.ToString();
		BeingHandled = false;
		}
}