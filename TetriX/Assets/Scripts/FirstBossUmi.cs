using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class FirstBossUmi : MonoBehaviour {

	UnityEngine.UI.Text txt;
	public int timer;
	private bool BeingHandled = false;
	private static Image sr;
	private static Flash flsh;
	private ScoreText gameScoreDisplay;
	// Use this for initialization

	void Start () {
		flsh =  GameObject.Find ("Flash").GetComponent<Flash> ();
		gameScoreDisplay = GameObject.Find ("Score").GetComponent<ScoreText> ();
		timer = 300;
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
			SceneManager.LoadScene ("MainMenu");
		}
		if (gameScoreDisplay.score > 2000)
			flsh.endStage = true;
		txt = gameObject.GetComponent<UnityEngine.UI.Text>(); 
		txt.text = timer.ToString();
		BeingHandled = false;
	}
}