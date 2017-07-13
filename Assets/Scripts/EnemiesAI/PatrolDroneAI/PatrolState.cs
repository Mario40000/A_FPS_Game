using UnityEngine;

public class PatrolState : IEDroneState
{

    PatrolDroneAI myEnemy;
    private int nextWaypoint = 0;

    //Cuando llamamos al constructor guardamos una 
    //referencia a la IA de nuestro enemigo
    public PatrolState (PatrolDroneAI enemy)
    {
        myEnemy = enemy;
    }

    //Funcionalidad del enemigo en patrolstate
    public void UpdateState()
    {
        myEnemy.light1.color = Color.green;

        //Le decimos al navMeshAgent cual es el siguiente punto
        myEnemy.navMeshAgent.destination =
            myEnemy.wayPoints[nextWaypoint].position;

        //Cuando lleguemos cambiamos el destino
        if (myEnemy.navMeshAgent.remainingDistance <= 
            myEnemy.navMeshAgent.stoppingDistance)
        {
            nextWaypoint = (nextWaypoint + 1) %
                myEnemy.wayPoints.Length;
        }
    }

    //Si el player nos ha disparado
    public void Impact()
    {
        GoToAlertState();
    }
	
    public void GoToAlertState()
    {
        //Paramos el movimiento
        myEnemy.navMeshAgent.Stop();
        myEnemy.currentState = myEnemy.alertState;
    }

    public void GoToAttackState ()
    {
        //Paramos el movimiento
        myEnemy.navMeshAgent.Stop();
        myEnemy.currentState = myEnemy.attackState;
    }

    //Como ya estamos en patrol no llamaremos
    //nunca a este estado desde aqui
    public void GoToPatrolState() { }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            GoToAlertState();
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GoToAlertState();
        }
    }

    public void OnTriggerExit(Collider other) { }
}
