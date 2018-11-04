using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Datos para el algoritmo de Dijkstra.
public class NodesClass
{
    public List<NodesClass> sideCubes; //Vecinos de cada tile del mapa.
    public int x;
    public int y;

    public NodesClass()
    {
        sideCubes = new List<NodesClass>(); //Constructor
    }

    public float DistanceTo(NodesClass nodeN)
    {
        return Vector2.Distance(new Vector2(x, y), new Vector2(nodeN.x, nodeN.y));
    }
}