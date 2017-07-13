using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolDroneAI : MonoBehaviour {

    [HideInInspector]
    public PatrolState patrolState;
    [HideInInspector]
    public AlertState alertState;
    [HideInInspector]
    public AttackState attackState;
    [HideInInspector]
    public IEDroneState currentState;

    [HideInInspector]
    public NavMeshAgent navMeshAgent;

    public Light light1;
    public Transform flash;
    public GameObject bulletDecal;
    public float life = 100;
    public float timeBetweenShoots = 1.0f;
    public int damageForce = 10;
    public float rotationTime = 3.0f;
    public float shootHeight = 0.5f;
    public GameObject[] prices;
    public Transform[] wayPoints;
    public Transform instancier;
    public GameObject fireSound;
    public GameObject explosionSound;
    public GameObject explosion;
    public GameObject flashObject;


    // Use this for initialization
    void Start ()
    {
        //Estados de la IA
        patrolState = new PatrolState(this);
        alertState = new AlertState(this);
        attackState = new AttackState(this);

        //Estado inicial
        currentState = patrolState;

        //Guardamos la referencia de nuestro NavMeshAgent
        navMeshAgent = GetComponent<NavMeshAgent>();

	}
	
	// Update is called once per frame
	void Update ()
    {
        //LLamamos a los updates de nuestros estados
        //en cada frame
        currentState.UpdateState();
        if (life < 0)
        {
            KillDrone();
        } 
	}

    //Cuando nos disparan, quitamos vida y
    //avisamos de ello
    public void Hit(float damage)
    {
        life -= damage;
        currentState.Impact();
        Debug.Log("Enemy hitted: " + life);
    }

    //Como nuestros states no heredan de monobe, los
    //avisamos de cuando algo entra o sale del trigger
    void OnTriggerEnter(Collider other)
    {
        currentState.OnTriggerEnter(other);
    }
    void OnTriggerStay(Collider other)
    {
        currentState.OnTriggerStay(other);
    }
    void OntriggerExit(Collider other)
    {
        currentState.OnTriggerExit(other);
    }

    //Metodo para matar al drone
    void KillDrone ()
    {
        explosionSound.GetComponent<AudioSource>().Play();
        Instantiate(explosion, transform.position, Quaternion.identity);
        Instantiate(prices[Random.Range(0, prices.Length)],instancier.position,Quaternion.identity);
        Destroy(gameObject);
        
    }

    //Metodo para instanciar el flash del arma
    public void fireFlash()
    {
        Instantiate(flash, instancier.position, Quaternion.identity);
    }
}
