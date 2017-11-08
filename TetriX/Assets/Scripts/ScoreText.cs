using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreText : MonoBehaviour {

	UnityEngine.UI.Text txt;
	public int score;

	// Use this for initialization
	void Start () {
		
		score = 0;

	}
	
	// Update is called once per frame
	void Update () {

		txt = gameObject.GetComponent<UnityEngine.UI.Text>(); 
      	txt.text = score.ToString(); ;

	}
}
