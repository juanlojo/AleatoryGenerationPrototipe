﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class alySpawner : MonoBehaviour {

    public GameObject unit1;
    public GameObject unit2;

    CapsuleCollider capsuleCollider;

    public Toggle toggle1;
    public Toggle toggle2;

    void Update()
    {
        if (toggle1.isOn)
        {
            Debug.Log("broncano");
            RaycastHit hitInfo;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (!EventSystem.current.IsPointerOverGameObject())
            {
                Debug.Log("nepe");
                if (Physics.Raycast(ray, out hitInfo))
                {
                    Debug.Log("sordo");
                    if (hitInfo.collider.tag == "cubePrefab")
                    {
                        Debug.Log("niñoo");
                        if (Input.GetKey("q") && Input.GetMouseButton(0))
                        {
                            Debug.Log("miguel");
                            Vector3 spawnLocation = hitInfo.collider.transform.position + hitInfo.normal + new Vector3(0, 0.5f, 0);
                            Instantiate(unit1, spawnLocation, Quaternion.identity);
                        }
                    }
                }
            }
        }
        else if (toggle2.isOn)
        {
            Debug.Log("quepasa");
            RaycastHit hitInfo;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (!EventSystem.current.IsPointerOverGameObject())
            {
                Debug.Log("cr");
                if (Physics.Raycast(ray, out hitInfo))
                {
                    Debug.Log("kjfasdjfd");
                    if (hitInfo.collider.tag == "cubePrefab")
                    {
                        Debug.Log("Hola2");
                        if (Input.GetKey("q") && Input.GetMouseButton(0))
                        {
                            Vector3 spawnLocation = hitInfo.collider.transform.position + hitInfo.normal + new Vector3(0, 0.5f, 0);
                            Instantiate(unit2, spawnLocation, Quaternion.identity);
                            Debug.Log("Hola3");
                        }
                    }
                }
            }
        }
    }
}
