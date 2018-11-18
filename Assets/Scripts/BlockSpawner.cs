using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour {

	private const int count = 5;
    public GameObject[] blockSpawns;

	// Use this for initialization
	void Start () {

		blockSpawns = GameObject.FindGameObjectsWithTag("BlockSpawn");
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
