using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowNextPiece : MonoBehaviour {
	public GameObject[] groups;
	private SpawnBlock m_Spawn;
	public int CurrentPiece;
	GameObject go;
	// Use this for initialization
	void Start () {
		m_Spawn = GameObject.Find ("Spawner").GetComponent<SpawnBlock> ();
		CurrentPiece = m_Spawn.nextPiece;
		go = Instantiate(groups[m_Spawn.nextPiece],transform.position,Quaternion.identity) as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if (CurrentPiece != m_Spawn.nextPiece)
		{
			Object.Destroy (go, 0);
			go = Instantiate(groups[m_Spawn.nextPiece],transform.position,Quaternion.identity) as GameObject;
			CurrentPiece = m_Spawn.nextPiece;
		}
	}
}
