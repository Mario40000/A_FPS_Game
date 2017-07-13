using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroSceneController : MonoBehaviour
{
    //Empezamos a jugar o salimos segun que boton pulsemos
	void Update ()
    {
	    if(Input.GetButtonDown("Jump"))
        {
            SceneManager.LoadScene("AirfieldScene");
        }

        if(Input.GetButtonDown("Cancel"))
        {
            Application.Quit();
        }
	}
}
