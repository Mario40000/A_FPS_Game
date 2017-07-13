using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraGameOverController : MonoBehaviour {

	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetButtonDown("Jump"))
        {
            SceneManager.LoadScene("AirfieldScene");
        }

        if(Input.GetButtonDown("Cancel"))
        {
            SceneManager.LoadScene("MenuScene");
        }
	}
}
