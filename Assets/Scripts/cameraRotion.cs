using UnityEngine;

public class cameraRotion : MonoBehaviour {

    public float rotationSpeed;
	
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
	}
}
