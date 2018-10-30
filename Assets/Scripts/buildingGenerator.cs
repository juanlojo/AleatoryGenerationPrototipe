using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildingGenerator : MonoBehaviour {

    public GameObject building;

	// Use this for initialization
	void Start () {
        GenerateBuilds();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GenerateBuilds()
    {
        Vector3 position = new Vector3(Random.Range(0,10), 0.5f, Random.Range(0,10));
        Instantiate(building, position, Quaternion.identity);
    }
}
