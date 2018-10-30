using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitClass : MonoBehaviour {
    public int tileX;
    public int tileY; //Tile actual en el que está situada la unidad.
    public MapGenerator map; 
    int movSpeed = 2;
    float quantityOfMovement = 2;

    public List<NodesClass> actualPath = null;

    void Update()
    {
        if (actualPath != null)
        {
            int actualNode = 0;
            while (actualNode < actualPath.Count - 1)
            {
                Vector3 initTile = map.ConvertToWorldCoordinates(actualPath[actualNode].x, actualPath[actualNode].y);
                Vector3 finalTile = map.ConvertToWorldCoordinates(actualPath[actualNode + 1].x, actualPath[actualNode + 1].y);

                Debug.DrawLine(initTile, finalTile, Color.black);

                actualNode++;
            }
        }

        //if(Vector3.Distance(transform.position, map.ConvertToWorldCoordinates(tileX, tileY)) < 0.5f)
        //{
        //    MoveCharacterToTile();
        //}

        //transform.position = Vector3.Lerp(transform.position, map.ConvertToWorldCoordinates(tileX, tileY), 5f * Time.deltaTime);
    }

    public void MoveCharacterToTile()
    {
        while (movSpeed > 0)
        {
            if (actualPath == null)
            {
                return;
            }

            quantityOfMovement -= map.TileCost(actualPath[0].y, actualPath[0].y ,actualPath[1].x, actualPath[1].y);

            tileX = actualPath[1].x; //actualiza la posición del tile en el que estamos, pues si no el inicial siempre seria (0,0).
            tileY = actualPath[1].y;
            transform.position = map.ConvertToWorldCoordinates(tileX, tileY);

            actualPath.RemoveAt(0);

            if (actualPath.Count == 1)
            {
                actualPath = null;
            }
        }
    }

    public void PassTurn()
    {
        while (actualPath != null && quantityOfMovement > 0)
        {
            MoveCharacterToTile();
        }

        quantityOfMovement = movSpeed;
    }
}
