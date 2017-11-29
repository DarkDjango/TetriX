using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UmiCutscene1 : MonoBehaviour {
	private Image Char1;
	private Image Char2;
	private Image Dialog1;
	private Image Dialog2;
	private Image Back1;
	private Image Back2;
	private Image FlashColor;
	private FadeInFadeOut Background1;
	private FadeInFadeOut Char1Fade;
	private FadeInFadeOut Char2Fade;
	private FadeInFadeOut Flash;
	private FadeInFadeOut TitleCard;
	private Text Name1;
	private Text Name2;
	private Text Dialog;
	public int currentEvent;
	public int previousEvent;
	public float time;
	public float setTime;
	public void ButtonClick () {
		if (currentEvent < 28)
			currentEvent++;
	}
	private void Char1NotTalking () {
		Char1.color = new Color (0.5f, 0.5f, 0.5f, 1);	
		Dialog1.color = new Color (1, 1, 1, 0);
		Back1.color = new Color (1, 1, 1, 0);
		Name1.text = "";
	}

	private void Char2NotTalking () {
		Char2.color = new Color (0.5f, 0.5f, 0.5f, 1);	
		Dialog2.color = new Color (1, 1, 1, 0);
		Back2.color = new Color (1, 1, 1, 0);
		Name2.text = "";
	}

	private void Char1Talking () {
		Char1.color = new Color (1, 1, 1, 1);	
		Dialog1.color = new Color (1, 1, 1, 1);
		Back1.color = new Color (1, 1, 1, 1);
		Name1.text = "Umi";
	}

	private void Char2Talking () {
		Char2.color = new Color (1, 1, 1, 1);	
		Dialog2.color = new Color (1, 1, 1, 1);
		Back2.color = new Color (1, 1, 1, 1);
		Name2.text = "????";
	}

	void Start () {
		Char1 =  GameObject.Find ("Char1").GetComponent<Image> ();
		Char2 =  GameObject.Find ("Char2").GetComponent<Image> ();
		Dialog1 =  GameObject.Find ("1NameBox").GetComponent<Image> ();
		Dialog2 =  GameObject.Find ("2NameBox").GetComponent<Image> ();
		Back1 =  GameObject.Find ("1NameTrans").GetComponent<Image> ();
		Back2 =  GameObject.Find ("2NameTrans").GetComponent<Image> ();
		FlashColor =  GameObject.Find ("Flash").GetComponent<Image> ();
		Name1 =  GameObject.Find ("1NameText").GetComponent<Text> ();
		Name2 =  GameObject.Find ("2NameText").GetComponent<Text> ();
		Dialog =  GameObject.Find ("DialogText").GetComponent<Text> ();
		Background1 =  GameObject.Find ("Background1").GetComponent<FadeInFadeOut> ();
		Char1Fade = GameObject.Find ("Char1").GetComponent<FadeInFadeOut> ();
		Char2Fade =  GameObject.Find ("Char2").GetComponent<FadeInFadeOut> ();
		Flash =  GameObject.Find ("Flash").GetComponent<FadeInFadeOut> ();
		TitleCard =  GameObject.Find ("TitleCard").GetComponent<FadeInFadeOut> ();
		currentEvent = 0;
		previousEvent = 0;
		time = -1;
	}

	// Update is called once per frame
	void Update () {
		if (currentEvent != previousEvent) {
			if (currentEvent == 0) {
				Name1.text = "Umi";
				Dialog.text = "(Eu não sou capaz de entender...)";
			} else if (currentEvent == 1) {
				Dialog.text = "(Como que outras garotas mágicas conseguem continuar vivendo, normalmente...)";
			} else if (currentEvent == 2) {
				Dialog.text = "(Como se nada tivesse acontecido... Mesmo adquirindo a magia?)";
			} else if (currentEvent == 3) {
				Dialog.text = "Se eu desejasse, poderia muito bem escravizar todas pessoas da cidade.";
			} else if (currentEvent == 4) {
				Dialog.text = "Isso mesmo...";
			} else if (currentEvent == 5) {
				Name1.text = "Garoto";
				Dialog.text = "Socoooorro!! Por favor, alguéém!!";
			} else if (currentEvent == 6) {
				Name1.text = "Umi";
				Dialog.text = "Hm?";
			} else if (currentEvent == 7) {
				Name1.text = "Garoto";
				Dialog.text = "S-socoooorro!! Eu não... Eu não sei nadar!!";
			} else if (currentEvent == 8) {
				Name1.text = "Umi";
				Dialog.text = "Humpf.";
			} else if (currentEvent == 9) {
				Name1.text = "";
				Dialog.text = "*SPLASH*";
			} else if (currentEvent == 10) {
				Name1.text = "Garoto";
				Dialog.text = "O que aconteceu...? Isso foi magia?";
			} else if (currentEvent == 11) {
				Dialog.text = "A s-senhorita... Me salvou...?";
			} else if (currentEvent == 12) {
				Name1.text = "Umi";
				Dialog.text = "Eu fiz. Continue falando, no entanto, e eu te jogo de novo na água.";
			} else if (currentEvent == 13) {
				Dialog.text = "Você precisa ser muito estúpido pra entrar no lago sem saber nadar, sabia?";
			} else if (currentEvent == 14) {
				Name1.text = "Garoto";
				Dialog.text = "E-eu...";
			} else if (currentEvent == 15) {
				Name1.text = "Garoto";
				Dialog.text = "D-desculpe...";
			} else if (currentEvent == 16) {
				Name1.text = "Umi";
				Dialog.text = "Espere... Aquela ali é... SENGO!!";
			} else if (currentEvent == 17) {
				Char2Fade.fadeIn = true;
			} else if (currentEvent == 18) {
				Dialog.text = "...Você não é Sengo...";
			} else if (currentEvent == 19) {
				Char1NotTalking ();
				Char2Talking ();
				Dialog.text = "Lamento decepciona-la.";
			} else if (currentEvent == 20) {
				Char2NotTalking ();
				Char1Talking ();
				Dialog.text = "Argh... Maldita seja!! Quando eu pôr as mãos naquela garota...";
			} else if (currentEvent == 21) {
				Char1NotTalking ();
				Char2Talking ();
				Dialog.text = "Espere.";
			} else if (currentEvent == 22) {
				Char2NotTalking ();
				Char1Talking ();
				Dialog.text = "O que há!?";
			} else if (currentEvent == 23) {
				Dialog.text = "...O que? Você... Você também é uma garota mágica!!";
			} else if (currentEvent == 24) {
				Char1NotTalking ();
				Char2Talking ();
				Dialog.text = "Se você busca um combate, vou lhe dar um.";
			} else if (currentEvent == 25) {
				Dialog.text = "Mostre o que sabe fazer.";
			} else if (currentEvent == 26) {
				Char2NotTalking ();
				Char1Talking ();
				Dialog.text = "Hah...";
			}
			else if (currentEvent == 27) {
				Dialog.text = "Será um prazer acabar com você!!";
			}
			else if (currentEvent == 28) {
				Dialog.text = "";
				Flash.fadeIn = true;
			}
		}
		previousEvent = currentEvent;
		setTime = Time.time;
		if ((currentEvent == 28) && (FlashColor.color == new Color (1, 1, 1, 1))) {
			if (time < 0) {
				TitleCard.fadeIn = true;
				time = Time.time;
			}
		}
		if ((setTime > time+3)&&(time > 0)) {
			SceneManager.LoadScene("UmiStage1");
		}
	}
}
