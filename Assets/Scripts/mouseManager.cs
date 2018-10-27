using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class mouseManager : MonoBehaviour {

    public bool selectInfoTile = false;
    public GameObject infoUI;

	// Use this for initialization
	void Start () {
        infoUI.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hitInfo;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hitInfo))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                GameObject outHitObject = hitInfo.collider.transform.gameObject;

                if (hitInfo.collider.tag == "cubePrefab") //el cubo ha sido o no pulsado, para diferenciar de si pulsamos un cubo u otro objeto.
                {
                    Debug.Log("mousemanager");
                    selectInfoTile = true;
                    if (selectInfoTile == true)
                    {
                        if (Input.GetMouseButtonDown(1)) //hace que el mapa sea expandible generando instancias (clones) del prefab del cubo .
                        {
                            MeshRenderer mr = outHitObject.GetComponentInChildren<MeshRenderer>();
                            Vector3 spawnLocation = hitInfo.collider.transform.position + hitInfo.normal;
                            mr.material.color = Color.white;
                            Debug.Log("You hit: " + hitInfo.collider.gameObject);
                            Instantiate(outHitObject, spawnLocation, Quaternion.identity);
                        }
                    }
                }
                if (Input.GetMouseButtonDown(0)) //cambia el color del cubo en funcion de si está o no seleccionado.
                {
                    MeshRenderer mr = outHitObject.GetComponentInChildren<MeshRenderer>();
                    if (mr.material.color == Color.blue)
                    {
                        mr.material.color = Color.white;
                        infoUI.SetActive(false);
                    }
                    else
                    {
                        mr.material.color = Color.blue;
                        infoUI.SetActive(true);
                    }
                }
            }
        }
    }
}
