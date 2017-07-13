using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirfieldEntranceController : MonoBehaviour
{
    //Actualizamos el texto de ayuda
	void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(StaticData.adventurePath < 2)
            {
                StaticData.adventurePath = 2;
            }
            
            if(StaticData.respawn < 3)
            {
                StaticData.respawn = 3;
            }
        }
    }
}
