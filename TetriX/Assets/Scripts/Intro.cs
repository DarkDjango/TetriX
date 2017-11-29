using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Intro : MonoBehaviour {

	private TextFadeInFadeOut text1;
	private TextFadeInFadeOut text2;
	private TextFadeInFadeOut text3;
	private TextFadeInFadeOut text4;
	private FadeInFadeOut Flash;	
	public float time0, currentTime, goToMenu;
	public bool skipIntro;
	void Start() {
		text1 =  GameObject.Find ("Text1").GetComponent<TextFadeInFadeOut> ();
		text2 =  GameObject.Find ("Text2").GetComponent<TextFadeInFadeOut> ();
		text3 =  GameObject.Find ("Text3").GetComponent<TextFadeInFadeOut> ();
		text4 =  GameObject.Find ("Text4").GetComponent<TextFadeInFadeOut> ();
		Flash =  GameObject.Find ("Flash").GetComponent<FadeInFadeOut> ();
		time0 = Time.time;
		goToMenu = -1;
		skipIntro = false;
	}
	public void skipIntroButton() {
		skipIntro = true;
	}
	void Update () {
		currentTime = Time.time;
		if ((currentTime > time0) && (currentTime < time0 + 4)) {
			text1.fadeIn = true;	
		} else if ((currentTime > time0 + 4) && (currentTime < time0 + 9)) {
			text1.fadeIn = false;
			text1.fadeOut = true;
		} else if ((currentTime > time0 + 9) && (currentTime < time0 + 16)) {
			text2.fadeIn = true;
		} else if ((currentTime > time0 + 16) && (currentTime < time0 + 23)) {
			text2.fadeIn = false;
			text2.fadeOut = true;
		} else if ((currentTime > time0 + 23) && (currentTime < time0 + 27)) {
			text3.fadeIn = true;
		} else if ((currentTime > time0 + 27) && (currentTime < time0 + 32)) {
			text3.fadeIn = false;
			text3.fadeOut = true;
		} else if ((currentTime > time0 + 32))  {
			text4.fadeIn = true;
		} 
		if (((currentTime >= time0 + 40) || (skipIntro))&& (goToMenu < 0))	 {
			Flash.fadeIn = true;
			goToMenu = Time.time;
		}
		if ((goToMenu > 0) && (currentTime > goToMenu + 4))
			SceneManager.LoadScene ("MainMenu");
	}
}