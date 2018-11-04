using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour {

    bool isPaused = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("p"))
        {
            Time.timeScale = 0f;
            isPaused = true;
        }

        if(isPaused == true)
        {
            if (Input.GetKeyDown("p"))
            {
                Time.timeScale = 1.0f;
                isPaused = false;
            }
        }
    }
}
