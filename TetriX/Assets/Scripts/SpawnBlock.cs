using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlock : MonoBehaviour {
	public GameObject[] groups;
	// Use this for initialization
	public void spawnNext() {
		// Random Index
		int i = Random.Range(0, groups.Length);

		// Spawn Group at current Position
		print (transform.position);
		Instantiate(groups[i],transform.position,Quaternion.identity);
	}
	void Start () {
		spawnNext();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
