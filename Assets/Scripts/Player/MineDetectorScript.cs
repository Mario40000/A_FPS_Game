using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineDetectorScript : MonoBehaviour
{

    //Hacemos las minas visibles e invisibles con el detector
    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == "Mine")
        {
            other.GetComponent<MeshRenderer>().enabled = true;
        }
    }

    void OnTriggerExit (Collider other)
    {
        if (other.gameObject.tag == "Mine")
        {
            other.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
