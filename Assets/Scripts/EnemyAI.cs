using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    Transform target;
    float movSpeed = 4.0f;
    public float maxDistance = 0.5f;
    public float minDistance = 2.0f;
    public int damage = 4;

	// Use this for initialization
	void Start () {
        target = GameObject.FindGameObjectWithTag("Building").transform;
        int randomizer = Random.Range(1, 6);
        movSpeed = randomizer;
	}

    // Update is called once per frame
    void Update() {


        if (Vector3.Distance(transform.position, target.position) > 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, movSpeed * Time.deltaTime);
        }

    }
}
