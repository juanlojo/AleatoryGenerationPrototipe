using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {

    public GameObject cubePrefab;
    public Vector2 mapSize;
    public Color startColor;
    public Color mouseClickColor;
    public float maxCubes;
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
                GameObject cube = (GameObject)Instantiate(cubePrefab, new Vector3(-mapSize.x / 2 + 0.5f + x, 0, -mapSize.y / 2 + 0.5f + y), Quaternion.identity); //instancia los cubos.
                cube.name = "Cube_" + x + y; //pone un nombre a las instancias del cubo, en función de su posicion en los ejes. De esta forma podemos diferenciarlos con mayor facilidad.
                cube.transform.SetParent(this.transform); //ordena todas las instancias del cubo dentro del mapa en la jerarquía
            }
        }
    }
}
