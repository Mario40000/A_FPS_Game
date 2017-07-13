using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAI : MonoBehaviour {
 

    public float life = 100;
    public float timeBetweenShoots = 0.5f;
    public int damageForce = 15;
    public float rotationTime = 3.0f;
    public float shootHeight = 0.5f;
    public GameObject fireSound;
    public GameObject explosionSound;
    public GameObject explosion;
    public GameObject fire;
    public Transform instancier;
    public GameObject turret;

    private float actualTimeBetweenShoots = 0;

    // Use this for initialization
    void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        actualTimeBetweenShoots += Time.deltaTime;
        if (life < 0)
        {
            killTurret();
        }
    }
    
    //Metodo para matar la torreta
    void killTurret ()
    {
        explosionSound.GetComponent<AudioSource>().Play();
        Instantiate(explosion, instancier.position, Quaternion.identity);
        Instantiate(fire, instancier.position, Quaternion.identity);
        Destroy(turret.gameObject);
        gameObject.GetComponent<TurretAI>().enabled = false;
        gameObject.GetComponent<SphereCollider>().enabled = false;
    }

    //Metodo para atacar y seguir al player
    void OnTriggerStay (Collider other)
    {
        // Lo miramos
         Vector3 lookDirection =
             other.transform.position - transform.position;

        //Rotando solo el eje y
        transform.rotation =
            Quaternion.FromToRotation(Vector3.forward,
            new Vector3(lookDirection.x, 0, lookDirection.z));

        //Le toca volver a disparar
        if (actualTimeBetweenShoots > timeBetweenShoots)
        {
            actualTimeBetweenShoots = 0;
            fireSound.GetComponent<AudioSource>().Play();
            RaycastHit hit;
            if (Physics.Raycast(
                new Ray(
                    new Vector3(transform.position.x,
                    0.5f,
                    transform.position.z),
                    transform.forward * 100f),
                out hit))
            {
                if (hit.collider.gameObject.tag == "Player")
                {
                    //Daño a los escudos y a la vida
                    if (StaticData.armor > 6)
                    {
                        StaticData.armor -= damageForce;
                        StaticData.life -= damageForce / 2;
                        Debug.Log("Player hitted: " + damageForce);
                    }
                    else
                    {
                        StaticData.armor -= damageForce;
                        StaticData.life -= damageForce;
                        Debug.Log("Player hitted: " + damageForce);
                    }


                }

            }

        }
    }

    //Metodo para dañar la torreta
    public void Hit(float damage)
    {
        life -= damage;
        Debug.Log("Turret hitted: " + life);
    }
}
