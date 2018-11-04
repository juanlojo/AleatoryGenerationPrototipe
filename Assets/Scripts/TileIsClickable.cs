using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileIsClickable : MonoBehaviour
{
    public int posX;
    public int posY;

    public MapGenerator map;

    private void OnMouseDown()
    {
        Debug.Log("Click!");

        map.GeneratePath(posX, posY);
    }
}
