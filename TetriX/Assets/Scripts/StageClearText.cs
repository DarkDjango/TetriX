using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class StageClearText : MonoBehaviour {
	private static Flash flsh;
	private static Text sr;
	private static bool BeingHandled;
	// Use this for initialization
	void Start () {
		flsh =  GameObject.Find ("Flash").GetComponent<Flash> ();
		sr = gameObject.GetComponent<Text>(); 
	}

	private IEnumerator HandleIt ()
	{
		BeingHandled = true;
		yield return new WaitForSeconds (0.05f);
		if (flsh.endStage)
			sr.color += new Color (0, 0, 0, 0.05f);
		if (sr.color == new Color (0, 0, 0, 1)) {
			yield return new WaitForSeconds (2);
			SceneManager.LoadScene ("MainMenu");
		}
		BeingHandled = false;
	}

	// Update is called once per frame
	void Update () {
		if (!BeingHandled) {
			StartCoroutine (HandleIt ());
		}
	}
}