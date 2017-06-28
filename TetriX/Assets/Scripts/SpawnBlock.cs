using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlock : MonoBehaviour {

	public GameObject[] groups;
	public GameObject[] groups2;
	public Material[] materials;
	public Color[] colors;

	public void spawnNext() {

		int i = Random.Range(0, groups.Length);

		Instantiate(groups2[i],transform.position,Quaternion.identity);
	}
	void Start () {

		for(int c=0;c<7;c++){
			materials [c].color = colors [c];
		}

		spawnNext();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
