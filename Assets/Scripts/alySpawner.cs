using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class alySpawner : MonoBehaviour
{

    public GameObject unit1;
    public GameObject unit2;

    public GameObject instUnit1;
    public GameObject instUnit2;

    public Toggle toggle1;
    public Toggle toggle2;

    void Update()
    {
        if (toggle1.isOn)
        {
            RaycastHit hitInfo;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (!EventSystem.current.IsPointerOverGameObject())
            {
                if (Physics.Raycast(ray, out hitInfo))
                {
                    if (hitInfo.collider.tag == "cubePrefab")
                    {
                        if (Input.GetMouseButton(2))
                        {
                            Vector3 spawnLocation = hitInfo.collider.transform.position + hitInfo.normal + new Vector3(0, 0.5f, 0);
                            instUnit1 = (GameObject)Instantiate(unit1, spawnLocation, Quaternion.identity);
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
                if (Physics.Raycast(ray, out hitInfo))
                {
                    Debug.Log("kjfasdjfd");
                    if (hitInfo.collider.tag == "cubePrefab")
                    {
                        if (Input.GetMouseButton(2))
                        {
                            Vector3 spawnLocation = hitInfo.collider.transform.position + hitInfo.normal + new Vector3(0, 0.5f, 0);
                            instUnit2 = (GameObject)Instantiate(unit2, spawnLocation, Quaternion.identity);
                        }
                    }
                }
            }
        }
    }
}