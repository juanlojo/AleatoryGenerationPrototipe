using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.AI;

public class MapGenerator : MonoBehaviour {

    public TileClass[] tileTypes;
    int[,] tiles;

    //public GameObject cubePrefab;
    public int mapSizeX;
    public int mapSizeY;

    public NavMeshSurface navMeshSurface;

	// Use this for initialization
	void Start () {
        //MapGeneration();
        int randomizer = Random.Range(0, 100);

        tiles = new int[mapSizeX, mapSizeY];

        for(int x = 0; x < mapSizeX; x++)
        {
            for(int y = 0; y < mapSizeY; y++)
            {
                if(randomizer % 20 == 0)
                {
                    tiles[x, y] = 0;
                }
                else if(randomizer % 30 == 0)
                {
                    tiles[x, y] = 1;
                }
                else if(randomizer % 40 == 0)
                {
                    tiles[x, y] = 2;
                }
                else
                {
                    tiles[x, y] = 3;
                }
            }
        }
        GenerateMap();


        //UPDATE DYNAMIC NAVMESH
        navMeshSurface.BuildNavMesh();
    }
	
	// Update is called once per frame
	void Update () {

    }

    //public void MapGeneration()
    //{
    //    for (int x = 0; x < mapSize.x; x++)
    //    {
    //        for (int y = 0; y < mapSize.y; y++)
    //        {
    //            GameObject cube = Instantiate(cubePrefab, new Vector3(-mapSize.x / 2 + 0.5f + x, 0, -mapSize.y / 2 + 0.5f + y), Quaternion.identity); //instancia los cubos.
    //            cube.name = "Cube_" + x + y; //pone un nombre a las instancias del cubo, en función de su posicion en los ejes. De esta forma podemos diferenciarlos con mayor facilidad.
    //            cube.transform.SetParent(this.transform); //ordena todas los clones del cubo dentro del mapa en la jerarquía
    //        }
    //    }
    //}

    public void GenerateMap()
    {
        for (int x = 0; x < mapSizeX; x++)
        {
            for (int y = 0; y < mapSizeY; y++)
            {
                TileClass tile = tileTypes[tiles[x, y]];
                GameObject cube = Instantiate(tile.cubePrefab, new Vector3(-mapSizeX / 2 + 0.5f + x, 0, -mapSizeY / 2 + 0.5f + y), Quaternion.identity);
                cube.name = "Cube_" + x + y;
                cube.transform.SetParent(this.transform);
            }
        }
    }
}
