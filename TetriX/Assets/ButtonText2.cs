using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayScore : MonoBehaviour {

	Text txt;
	// Use this for initialization
	void Start () {
		txt = gameObject.GetComponent<Text>(); 
	}

	// Update is called once per frame
	void Update () {
		if (PlayerPrefs.GetInt ("TouchPlay") == 0) {
			txt.text = "OFF";
			txt.color = Color.red;
		} else {
			txt.text = "ON";
			txt.color = Color.blue;
		}
	}
}