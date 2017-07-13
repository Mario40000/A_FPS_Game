using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalController : MonoBehaviour
{

	void OnTriggerEnter (Collider other)
    {
        SceneManager.LoadScene("FinalScene");
    }
}
