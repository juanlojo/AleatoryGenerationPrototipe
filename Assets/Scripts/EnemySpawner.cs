using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemy;
    public float spawnTime;
    public float spawnDelay;
    public bool stopSpawning = false;
    public Transform[] spawnPoints;

	// Use this for initialization
	void Start () {
        InvokeRepeating("Spawn", spawnTime, spawnDelay);
	}

    void Spawn()
    {
        //Instantiate(enemy, new Vector3(Random.Range(3, 9), 0.5f, Random.Range(3, 9)), Quaternion.identity);
        //if (stopSpawning)
        //{
        //    CancelInvoke("Spawn");
        //}
        int spawnPointsRandomizer = Random.Range(0, spawnPoints.Length);
        Instantiate(enemy, spawnPoints[spawnPointsRandomizer].position, spawnPoints[spawnPointsRandomizer].rotation);
    }
}
