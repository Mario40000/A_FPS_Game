
using UnityEngine;

public class AttackState : IEDroneState
{

    PatrolDroneAI myEnemy;
    float actualTimeBetweenShoots = 0;

    //Referencia de nuestro enemigo
    public AttackState(PatrolDroneAI enemy)
    {
        myEnemy = enemy;
    }

    //Funcionalidad del estado attack
    public void UpdateState ()
    {
        myEnemy.light1.color = Color.red;
        actualTimeBetweenShoots += Time.deltaTime;
    }

    //Si el player nos ha disparado no haremos nada
    public void Impact() { }

    //Como ya estamos en attack no llamaremos al 
    //estado attack desde aqui
    public void GoToAttackState() { }
    public void GoToPatrolState() { }

    public void GoToAlertState ()
    {
        myEnemy.currentState = myEnemy.alertState;
    }

    //El player ya esta en nuestro trigger
    public void OnTriggerEnter(Collider other) { }

    //Orientamos al enemigo mirando al player siempre
    //que ataquemos
    public void OnTriggerStay(Collider other)
    {
        //Lo miramos
        Vector3 lookDirection = 
            other.transform.position - myEnemy.transform.position;

        //Rotando solo el eje y
        myEnemy.transform.rotation =
            Quaternion.FromToRotation(Vector3.forward,
            new Vector3(lookDirection.x, 0, lookDirection.z));

        //Le toca volver a disparar
        if(actualTimeBetweenShoots > myEnemy.timeBetweenShoots)
        {
            actualTimeBetweenShoots = 0;
            myEnemy.fireSound.GetComponent<AudioSource>().Play();
            myEnemy.fireFlash();
            RaycastHit hit;
            if (Physics.Raycast(
                new Ray(
                    new Vector3(myEnemy.transform.position.x,
                    0.5f,
                    myEnemy.transform.position.z),
                    myEnemy.transform.forward * 100f),
                out hit))
            {
                if (hit.collider.gameObject.tag == "Player")
                {
                    //Daño a los escudos y a la vida
                    if(StaticData.armor > 6)
                    {
                        StaticData.armor -= myEnemy.damageForce;
                        StaticData.life -= myEnemy.damageForce / 2;
                        Debug.Log("Player hitted: " + myEnemy.damageForce);
                    }
                    else
                    {
                        StaticData.armor -= myEnemy.damageForce;
                        StaticData.life -= myEnemy.damageForce;
                        Debug.Log("Player hitted: " + myEnemy.damageForce);
                    }
               
                    
                }
                
            }
           
        }
    }

    //Si el player sale del radio se pasa al modo alert
    public void OnTriggerExit (Collider other)
    {
        GoToAlertState();
    }
}
