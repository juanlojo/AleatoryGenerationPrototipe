using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.AI;
using System.Linq;

public class MapGenerator : MonoBehaviour
{
    NodesClass[,] pathGraph;

    //Posición de los tiles y datos para su generación
    public TileClass[] tileTypes;
    int[,] tiles;

    public GameObject unitSelected;

    public int mapSizeX;
    public int mapSizeY;

    void Start()
    {
        unitSelected.GetComponent<UnitClass>().tileX = (int)unitSelected.transform.position.x;
        unitSelected.GetComponent<UnitClass>().tileX = (int)unitSelected.transform.position.y;
        unitSelected.GetComponent<UnitClass>().map = this;

        MapData();
        GeneratePathGraph();
        GenerateMap();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MapData()
    {
        int randomizer = Random.Range(0, 4);

        tiles = new int[mapSizeX, mapSizeY];

        for (int x = 0; x < mapSizeX; x++)
        {
            for (int y = 0; y < mapSizeY; y++)
            {
                tiles[x, y] = 0;
            }
        }
        //pequeño cuadrado amarillo para probar pathfinding
        tiles[4, 4] = 3;
        tiles[4, 5] = 3;
        tiles[5, 4] = 3;
        tiles[5, 5] = 3;

        tiles[0, 6] = 3;
        tiles[0, 7] = 3;
        tiles[1, 6] = 3;
        tiles[1, 7] = 3;
        tiles[2, 6] = 3;
        tiles[2, 7] = 3;

        tiles[5, 1] = 3;
        tiles[6, 1] = 3;
        tiles[7, 1] = 3;
        tiles[8, 1] = 3;
        tiles[6, 2] = 3;
        tiles[7, 2] = 3;
        tiles[8, 2] = 3;
        tiles[8, 3] = 3;
        tiles[7, 3] = 3;

        tiles[7, 7] = 2;
        tiles[7, 8] = 2;
        tiles[8, 8] = 2;
        tiles[8, 7] = 2;
    }

    public void GenerateMap()
    {
        for (int x = 0; x < mapSizeX; x++)
        {
            for (int y = 0; y < mapSizeY; y++)
            {
                TileClass tile = tileTypes[tiles[x, y]];
                GameObject cube = (GameObject)Instantiate(tile.cubePrefab, new Vector3(0 + x, -1, 0 + y), Quaternion.identity);
                cube.name = "Cube_" + x + "_" + y;
                cube.transform.SetParent(this.transform);

                TileIsClickable tileClick = cube.GetComponent<TileIsClickable>();
                tileClick.posX = x;
                tileClick.posY = y;
                tileClick.map = this;
            }
        }
    }

    public Vector3 ConvertToWorldCoordinates(int x, int y)
    {
        return new Vector3(x, 0.5f, y);
    }

    public void GeneratePathGraph()
    {
        //Crea el array
        pathGraph = new NodesClass[mapSizeX, mapSizeY];
        //Rellena todo el array con nodos
        for (int x = 0; x < mapSizeX; x++)
        {
            for (int y = 0; y < mapSizeY; y++)
            {
                pathGraph[x, y] = new NodesClass
                {
                    x = x,
                    y = y
                };
            }
        }
        //Calcula los vecinos para cada nodo.
        for (int x = 0; x < mapSizeX; x++)
        {
            for (int y = 0; y < mapSizeY; y++)
            {
                //conexiones con unicamente 4 de los cubos de alrededor, es decir, sin diagonales.
                if (x > 0)
                {
                    pathGraph[x, y].sideCubes.Add(pathGraph[x - 1, y]); // Con estos IF controlamos que siempre exista un cubo vecino del otro, para no crear nodos en el final del mapa.
                }
                if (x < mapSizeX - 1)
                {
                    pathGraph[x, y].sideCubes.Add(pathGraph[x + 1, y]);
                }
                if (y > 0)
                {
                    pathGraph[x, y].sideCubes.Add(pathGraph[x, y - 1]);
                }
                if (y < mapSizeY - 1)
                {
                    pathGraph[x, y].sideCubes.Add(pathGraph[x, y + 1]);
                }
            }
        }
    }

    public float TileCost(int initialX, int initialY, int finalX, int finalY) //Donde x = xObjetivo e y = yObjetivo (es decir posicion del tile objetivo).
    {
        TileClass tileClass = tileTypes[tiles[finalX, finalY]];

        if (tileCanBeEntered(finalX, finalY) == false)
        {
            return Mathf.Infinity;
        }

        return tileClass.movCost;
    }

    public bool tileCanBeEntered(int x, int y)
    {
        return tileTypes[tiles[x, y]].isaBuilding;
    }

    public void GeneratePath(int x, int y)
    {
        //Borra el path viejo de la unidad.
        unitSelected.GetComponent<UnitClass>().actualPath = null;

        if (tileCanBeEntered(x, y) == false)
        {
            return;
        }

        Dictionary<NodesClass, float> distance = new Dictionary<NodesClass, float>();
        Dictionary<NodesClass, NodesClass> previousNode = new Dictionary<NodesClass, NodesClass>();
        //Lista de nodos que no hemos visitado.
        List<NodesClass> unvisitedNodes = new List<NodesClass>();

        NodesClass sourceNode = pathGraph[unitSelected.GetComponent<UnitClass>().tileX, unitSelected.GetComponent<UnitClass>().tileY];
        NodesClass targetNode = pathGraph[x, y];

        distance[sourceNode] = 0; //poblamos (rellenamos) el nodo inicial.
        previousNode[sourceNode] = null;

        //Inicialización

        foreach (NodesClass nodeV in pathGraph)
        {
            if (nodeV != sourceNode)
            {
                distance[nodeV] = Mathf.Infinity; //poblamos (rellenamos) el resto de nodos.
                previousNode[nodeV] = null;
            }
            unvisitedNodes.Add(nodeV);
        }

        while (unvisitedNodes.Count > 0)
        {
            //NodeU será el nodo con la distancia más corta.
            NodesClass nodeU = null;

            foreach (NodesClass posibleNodeU in unvisitedNodes)
            {
                if (nodeU == null || distance[posibleNodeU] < distance[nodeU])
                {
                    nodeU = posibleNodeU;
                }
            }

            if (nodeU == targetNode)
            {
                break; //Sale del loop while
            }

            unvisitedNodes.Remove(nodeU);

            foreach (NodesClass nodeZ in nodeU.sideCubes)
            {
                //float distanceBtwn = distance[nodeU] + nodeU.DistanceTo(nodeZ);
                float distanceBtwn = distance[nodeU] + TileCost(nodeU.x, nodeU.y, nodeZ.x, nodeZ.y);
                if (distanceBtwn < distance[nodeZ])
                {
                    distance[nodeZ] = distanceBtwn;
                    previousNode[nodeZ] = nodeU;
                }
            }
        }

        if (previousNode[targetNode] == null)
        {
            //No existe ruta entre el nodo inicial(source) y el nodo objetivo(target)
            return;
        }
        List<NodesClass> actualPath = new List<NodesClass>();

        NodesClass current = targetNode;

        //loop en la cadena previousNode y la añade a la lista actualPath.
        while (current != null)
        {
            actualPath.Add(current);
            current = previousNode[current];
        }
        actualPath.Reverse();

        unitSelected.GetComponent<UnitClass>().actualPath = actualPath;
    }
}
