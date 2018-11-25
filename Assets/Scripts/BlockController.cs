using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlockController : MonoBehaviour {

    public GameObject prefab;

	// Use this for initialization
	void Start () {
        InvokeRepeating("BlockSpawner", 0, 2);
    }

    // Update is called once per frame
    void Update () {
		
	}
	


    public void BlockSpawner()
    {
        Vector3 position = new Vector3(Random.Range(-80.0f, 80.0f), 60, 0);
        Instantiate(prefab, position, Quaternion.identity);
    }
}
