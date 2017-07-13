using UnityEngine;

public class AlertState : IEDroneState
{

    PatrolDroneAI myEnemy;
    float currentRotationTime = 0f;

    //Referencia de la IA de nuestro enemigo
    public AlertState(PatrolDroneAI enemy)
    {
        myEnemy = enemy;
    }

    //Funcionalidad del estado 
    public void UpdateState ()
    {
        myEnemy.light1.color = Color.yellow;
        currentRotationTime += Time.deltaTime;

        //Rotamos al enemigo una vuelta completa
        //segun rotationTime
        myEnemy.transform.rotation *= Quaternion.Euler(0f,
            Time.deltaTime * 360 * 1.0f / myEnemy.rotationTime,
            0f);

        //Si hemos dado la vuelta
        if(currentRotationTime > myEnemy.rotationTime)
        {
            currentRotationTime = 0;
            GoToPatrolState();
        }
        else
        {
            //Si seguimos dando la vuelta, lanzamos un rayo
            //desde una altura de o.5m desde la posicion del 
            //enemigo hacia donde mira
            RaycastHit hit;
            if (Physics.Raycast(
                new Ray (
                    new Vector3(myEnemy.transform.position.x,
                    0.5f,
                    myEnemy.transform.position.z),
                    myEnemy.transform.forward * 100f),
                out hit))
            {
                if(hit.collider.gameObject.tag == "Player")
                {
                    Debug.Log(hit.collider.name);
                    GoToAttackState();
                }
            }
        }
        currentRotationTime += Time.deltaTime;

    }

    //Si el player nos ha disparado
    public void Impact()
    {
        GoToAttackState();
    }

    //Como estamos en estado alerta no esntraremos nunca
    //en alert desde aqui
    public void GoToAlertState() { }

    public void GoToAttackState()
    {
        myEnemy.currentState = myEnemy.attackState;
    }

    public void GoToPatrolState()
    {
        //Volvemos a ponerlo en marcha
        myEnemy.navMeshAgent.Resume();
        myEnemy.currentState = myEnemy.patrolState;
    }

    //Al estar buscando no haremos caso del trigger
    public void OnTriggerEnter (Collider other) { }
    public void OnTriggerStay (Collider other) { }
    public void OnTriggerExit (Collider other) { }
}
