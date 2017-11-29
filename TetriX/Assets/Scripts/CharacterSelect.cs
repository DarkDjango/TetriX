using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour {

	public bool whiteOut;
	private Image sr;

	public void SengoSelect () {
		StartCoroutine (SelectCharacter (1));
	}
	public void UmiSelect () {
		StartCoroutine (SelectCharacter (2));
	}
	public IEnumerator SelectCharacter (int character)
	{
		sr.rectTransform.sizeDelta = new Vector2 (2000, 2000);
		for (int c = 0; c < 10; c++) {
			yield return new WaitForSeconds (0.1f);
			sr.color += new Color (0, 0, 0, 0.1f);
		}
		yield return new WaitForSeconds (1);
		if (character == 1)
			SceneManager.LoadScene ("Cutscene1");
		else if (character == 2)
			SceneManager.LoadScene ("UmiCutscene1");
	}

	// Use this for initialization
	void Start () {
		sr = GameObject.Find ("White").GetComponent<Image> ();
	}

	// Update is called once per frame
	void Update () {
		
	}
}
