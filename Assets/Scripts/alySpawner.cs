using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class alySpawner : MonoBehaviour {

    public GameObject unit1;
    public GameObject unit2;

    public Toggle toggle1;
    public Toggle toggle2;

    //Combat system stats
    //public float HP = 100;
    //public float def = Random.Range(3, 6);
    //public float atk = Random.Range(10, 13);

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
                if (Physics.Raycast(ray, out hitInfo))
                {
                    Debug.Log("kjfasdjfd");
                    if (hitInfo.collider.tag == "cubePrefab")
                    {
                        if (Input.GetMouseButton(2))
                        {
                            Vector3 spawnLocation = hitInfo.collider.transform.position + hitInfo.normal + new Vector3(0, 0.5f, 0);
                            Instantiate(unit2, spawnLocation, Quaternion.identity);
                        }
                    }
                }
            }
        }
    }
}
