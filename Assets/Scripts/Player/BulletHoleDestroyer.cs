using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHoleDestroyer : MonoBehaviour {

    public float delay = 0.0f;
	//Hacemos que los agujeros desaparezcan pasado un tiempo
	void Start ()
    {
        Destroy(gameObject, delay);
	}
	
	
}
