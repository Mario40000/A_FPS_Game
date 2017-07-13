using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinefieldEntranceController : MonoBehaviour
{

	void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (StaticData.respawn < 2)
            {
                StaticData.respawn = 2;
            }
        }
    }
}
