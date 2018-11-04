using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TileClass
{
    public string name;
    public GameObject cubePrefab;

    public float movCost = 1;

    public bool isaBuilding = true;

    public static implicit operator TileClass(MapGenerator v)
    {
        throw new NotImplementedException();
    }

    internal void MoveUnit(int posX, int posY)
    {
        throw new NotImplementedException();
    }
}
