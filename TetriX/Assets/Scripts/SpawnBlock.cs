using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlock : MonoBehaviour {

	public GameObject[] groups;
	public GameObject[] groups2;
	public Material[] materials;
	public Color[] colors;
	public int nextPiece;
	public void spawnNext() {

		Instantiate(groups2[nextPiece],transform.position,Quaternion.identity);
		nextPiece = Random.Range(0, groups.Length);
	}
	void Start () {

		nextPiece = Random.Range(0, groups.Length);
		for(int c=0;c<7;c++){
			materials [c].color = colors [c];
		}

		spawnNext();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
