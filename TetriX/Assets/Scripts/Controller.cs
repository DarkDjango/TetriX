using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Controller : MonoBehaviour {
	public bool Right;
	public bool Left;
	public bool Up;
	public bool Down;


	public void onClickLeft () {
		Left = true;
	}
	public void onClickRight () {
		Right = true;
	}
	public void onClickUp () {
		Up = true;
	}
	public void onClickDown () {
		Down = true;
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}
}
