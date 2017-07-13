using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleClipPick : MonoBehaviour {

    private GameObject sound;

    public int rotationSpeed;

    void Start ()
    {
        sound = GameObject.Find("CockRifle");
    }

    //Rotamos el objeto para haerlo mas vistoso
    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
    }
    //Si lo tocamos desaparece y aparece en el inventario
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            sound.GetComponent<AudioSource>().Play();
            StaticData.rifleClips++;
            Destroy(gameObject);
        }
    }
}
