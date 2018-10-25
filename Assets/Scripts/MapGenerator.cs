using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.AI;

public class MapGenerator : MonoBehaviour {

    public GameObject cubePrefab;
    public Vector2 mapSize;
    private GameObject navMeshPrefabHolder;

	// Use this for initialization
	void Start () {
        MapGeneration();
    }
	
	// Update is called once per frame
	void Update () {

    }

    public void MapGeneration()
    {
        navMeshPrefabHolder = Instantiate(new GameObject("navMeshPrefabHolder"), new Vector3(0,0,0), Quaternion.identity);
        for (int x = 0; x < mapSize.x; x++)
        {
            for (int y = 0; y < mapSize.y; y++)
            {
                GameObject cube = Instantiate(cubePrefab, new Vector3(-mapSize.x / 2 + 0.5f + x, 0, -mapSize.y / 2 + 0.5f + y), Quaternion.identity); //instancia los cubos.
                cube.transform.parent = navMeshPrefabHolder.transform;
                cube.name = "Cube_" + x + y; //pone un nombre a las instancias del cubo, en función de su posicion en los ejes. De esta forma podemos diferenciarlos con mayor facilidad.
                cube.transform.SetParent(this.transform); //ordena todas los clones del cubo dentro del mapa en la jerarquía
            }
        }
        navMeshPrefabHolder.AddComponent<NavMeshSurface>();
        navMeshPrefabHolder.GetComponent<NavMeshSurface>().collectObjects = CollectObjects.Children;
        GenerateNavMesh();
    }

    public void GenerateNavMesh()
    {
        navMeshPrefabHolder.GetComponent<NavMeshSurface>().BuildNavMesh();
    }
}
