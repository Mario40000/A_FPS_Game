using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealtPick : MonoBehaviour {

    private GameObject sound;

    public int life;
    public int rotationSpeed;

    void Start()
    {
        sound = GameObject.Find("Healt");
    }
    //Rotamos el objeto para haerlo mas vistoso
    void Update()
    {
        transform.Rotate(Vector3.right * Time.deltaTime * rotationSpeed);
    }
    //Si lo tocamos desaparece y aparece en el inventario
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            sound.GetComponent<AudioSource>().Play();
            StaticData.life += life;
            if(StaticData.life > 100)
            {
                StaticData.life = 100;
            }
            Destroy(gameObject);
        }
    }
}
