using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cutscene1 : MonoBehaviour {
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
		if (currentEvent < 26)
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
		Name1.text = "Sengo";
	}

	private void Char2Talking () {
		Char2.color = new Color (1, 1, 1, 1);	
		Dialog2.color = new Color (1, 1, 1, 1);
		Back2.color = new Color (1, 1, 1, 1);
		Name2.text = "Umi";
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
				Name1.text = "Sengo";
				Dialog.text = "Caramba... Eu tenho tanta sorte de ser uma garota mágica!";
			} else if (currentEvent == 1) {
				Dialog.text = "Poder voar significa nunca chegar atrasada pra prova... Mesmo acordando super tarde ~";
			} else if (currentEvent == 2) {
				Name1.text = "Pai";
				Dialog.text = "(Sengo... Sengo, está me ouvindo?)";
			} else if (currentEvent == 3) {
				Name1.text = "Sengo";
				Dialog.text = "Papai? O senhor me chamando através de telepatia essa hora da manhã...?";
			} else if (currentEvent == 4) {
				Dialog.text = "Aconteceu alguma coisa?";
			} else if (currentEvent == 5) {
				Name1.text = "Pai";
				Dialog.text = "(Sengo! Na praça da cidade... Estamos recebendo altos sinais de energia!)";
			} else if (currentEvent == 6) {
				Dialog.text = "(Além disso, foram recebidas várias ligaçẽos de emergência de lá!!)";
			} else if (currentEvent == 7) {
				Dialog.text = "(Parece que alguém está mantendo as pessoas como reféns!!)";
			} else if (currentEvent == 8) {
				Name1.text = "Sengo";
				Dialog.text = "Mas... Mas eu tenho prova de matemática... Eu preciso de nota...";
			} else if (currentEvent == 9) {
				Name1.text = "Pai";
				Dialog.text = "(Não seja infantil... Isso é um assunto importante.)";
			} else if (currentEvent == 10) {
				Name1.text = "Sengo";
				Dialog.text = "Está bem... As pessoas estão em perigo... Eu estou indo!!";
			} else if (currentEvent == 11) {
				Dialog.text = "...Senhor Tanaka vai ficar bravo comigo...";
			} else if (currentEvent == 12) {
				Char1NotTalking ();
				Background1.fadeOut = true;
				Dialog.text = "";
			} else if (currentEvent == 13) {
				Char1Talking ();
				Dialog.text = "O que está acontecendo aqui...?";
			} else if (currentEvent == 14) {
				Dialog.text = "As pessoas estão presas em...";
			} else if (currentEvent == 15) {
				Dialog.text = "Bolhas gigantes...?";
			} else if (currentEvent == 16) {
				Dialog.text = "...Eu sei quem está por trás disto.";
			} else if (currentEvent == 17) {
				Dialog.text = "Umi!! Estou aqui; APAREÇA!!";
			} else if (currentEvent == 18) {
				Dialog.text = "";
				Char1NotTalking ();
				Char2Fade.fadeIn = true;
			} else if (currentEvent == 19) {
				Char2Talking ();
				Dialog.text = "Hah! Você finalmente apareceu, Sengo!!";
			} else if (currentEvent == 20) {
				Char2NotTalking ();
				Char1Talking ();
				Dialog.text = "Você não tem mais nada pra fazer da vida!? Eu estudo, sabia!?";
			} else if (currentEvent == 21) {
				Dialog.text = "Eu tenho prova de matemática!! Agora!! Podemos resolver isso rápido!?";
			} else if (currentEvent == 22) {
				Char1NotTalking ();
				Char2Talking ();
				Dialog.text = "Hah! É exatamente o que desejo, fio-solto!";
			} else if (currentEvent == 23) {
				Dialog.text = "Desta vez, vou te deixar amassada no chão!";
			} else if (currentEvent == 24) {
				Dialog.text = "E sem fazer prova alguma!!";
			} else if (currentEvent == 25) {
				Char2NotTalking ();
				Char1Talking ();
				Dialog.text = "É o que vamos ver!!";
			} else if (currentEvent == 26) {
				Dialog.text = "";
				Flash.fadeIn = true;
			}
		}
		previousEvent = currentEvent;
		setTime = Time.time;
		if ((currentEvent == 26) && (FlashColor.color == new Color (1, 1, 1, 1))) {
			if (time < 0) {
				TitleCard.fadeIn = true;
				time = Time.time;
			}
		}
		if ((setTime > time+3)&&(time > 0)) {
			SceneManager.LoadScene("TetriX");
		}
	}
}
