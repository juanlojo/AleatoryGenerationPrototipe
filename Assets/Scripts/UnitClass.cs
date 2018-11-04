using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitClass : MonoBehaviour
{
    public int tileX;
    public int tileY; //Tile actual en el que está situada la unidad.
    public MapGenerator map;
    int movSpeed = 2;
    float quantityOfMovement = 2;

    public AudioSource walking;

    public List<NodesClass> actualPath = null;

    void Start()
    {
        walking = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (actualPath != null)
        {
            int currNode = 0;

            while (currNode <   actualPath.Count - 1)
            {

                Vector3 start = map.ConvertToWorldCoordinates(actualPath[currNode].x, actualPath[currNode].y) +
                    new Vector3(0, 0, -0.5f);
                Vector3 end = map.ConvertToWorldCoordinates(actualPath[currNode + 1].x, actualPath[currNode + 1].y) +
                    new Vector3(0, 0, -0.5f);

                Debug.DrawLine(start, end, Color.red);

                currNode++;
            }
        }

        if (Vector3.Distance(transform.position, map.ConvertToWorldCoordinates(tileX, tileY)) < 0.1f)
            AdvancePathing();

        transform.position = Vector3.Lerp(transform.position, map.ConvertToWorldCoordinates(tileX, tileY), 15f * Time.deltaTime);
    }

    void AdvancePathing()
    {
        if (actualPath == null)
            return;

        if (quantityOfMovement <= 0)
            return;

        transform.position = map.ConvertToWorldCoordinates(tileX, tileY);
        walking.Play();

        quantityOfMovement -= map.TileCost(actualPath[0].x, actualPath[0].y, actualPath[1].x, actualPath[1].y);

        tileX = actualPath[1].x;
        tileY = actualPath[1].y;

        actualPath.RemoveAt(0);

        if (actualPath.Count == 1)
        {
            actualPath = null;
        }
    }

    public void NextTurn()
    {
        while (actualPath != null && quantityOfMovement > 0)
        {
            AdvancePathing();
        }
        quantityOfMovement = movSpeed;
    }
}