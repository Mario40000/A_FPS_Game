using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioTowerEntranceController : MonoBehaviour
{
    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (StaticData.respawn < 1)
            {
                StaticData.respawn = 1;
            }
        }
    }
	
}
