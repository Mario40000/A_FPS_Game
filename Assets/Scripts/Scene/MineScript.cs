using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineScript : MonoBehaviour {

    private GameObject sound;

    public GameObject explosion;
    public Transform instancier;

	// Use this for initialization
	void Start ()
    {
        sound = GameObject.Find("MineExplosion");
	}
	
    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            sound.GetComponent<AudioSource>().Play();
            Instantiate(explosion, instancier.position, Quaternion.identity);
            StaticData.life = 0;
            Destroy(gameObject);
        }
    }
	
}
