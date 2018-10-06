using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {

    public GameObject cube1;
    public Vector2 mapSize;
    //int randomizer = Random.Range(1, 10);

	// Use this for initialization
	void Start () {
        MapGeneration();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MapGeneration()
    {
        for (int x = 0; x < mapSize.x; x++)
        {
            for (int y = 0; y < mapSize.y; y++)
            {
                GameObject newcube1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                newcube1.transform.position = new Vector3(-mapSize.x / 2 + 0.5f + x, 0, -mapSize.y / 2 + 0.5f + y);
                newcube1.GetComponent<Renderer>().material.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
                newcube1.transform.SetParent(transform);
            }
        }
    }


}
