using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour {

    public float rotationSpeed;

    void Update()
    {
        if (Input.GetKey("a"))
        {
            transform.Rotate(Vector3.up * -rotationSpeed);
        }
        else if (Input.GetKey("d"))
        {
            transform.Rotate(Vector3.up * rotationSpeed);
        }
    }
}
