using UnityEngine;

public class cameraRotion : MonoBehaviour {

    public float rotationSpeed;
    public float zoomSpeed = 20;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("a"))
        {
            transform.Rotate(Vector3.up * -rotationSpeed);
        }
        else if (Input.GetKey("d"))
        {
            transform.Rotate(Vector3.up * rotationSpeed);
        }

        //float scroll = Input.GetAxis("Mouse ScrollWheel");

        //transform.Translate(0, scroll * zoomSpeed, scroll * zoomSpeed);
	}
}
