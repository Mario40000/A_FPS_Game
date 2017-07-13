using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiflePick : MonoBehaviour {

    public GameObject sound;
    public int rotationSpeed;

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
            StaticData.rifle = 1;
            StaticData.rifleClips = 3;
            StaticData.rifleBullets = 30;
            Destroy(gameObject);
        }
    }
}
