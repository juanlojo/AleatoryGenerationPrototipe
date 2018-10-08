using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("Mouse Position: " + Input.mousePosition);

        //Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //Debug.Log("World Point: " + worldPoint);
        RaycastHit hitInfo;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hitInfo))
        {
            GameObject outHitObject = hitInfo.collider.transform.gameObject;

            Debug.Log("You hit something!" + hitInfo.collider.gameObject.name);

            if (Input.GetMouseButtonDown(1))
            {
                MeshRenderer mr = outHitObject.GetComponentInChildren<MeshRenderer>();
                mr.material.color = Color.blue;
                Vector3 spawnLocation = hitInfo.collider.transform.position + hitInfo.normal;
                Debug.Log("You we hit: " + hitInfo.collider.gameObject);
                Instantiate(outHitObject, spawnLocation, Quaternion.identity);
                if (mr.material.color == Color.blue)
                {
                    mr.material.color = Color.white;
                }
                else
                {
                    mr.material.color = Color.blue;
                }
            }
        }
	}
}
