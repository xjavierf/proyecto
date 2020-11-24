using UnityEngine;
using UnityEngine.AI; // Para el sistema de navegacion hace falta esta libreria
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    NavMeshAgent controladorMovivimento;



    private void Awake()
    {
        controladorMovivimento = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        if (!GetComponent<EnemyHealth>().muerte)    // para parar el movimiento cojo el componente de muerte enemyhealth y lo utilizo para comprobar si esta vivo o no y para el movimiento
        {                        //el primer if como esta negado se ejecuta si no esta muerto y luego el else se ejecuta si muerte es true y hay que volver la variable muerte publica para que pueda acceder a ella
            
            controladorMovivimento.SetDestination(GameManager.gameManager.jugador.position);


        }
        else // si esta muerto lo que hace es parar el navmesh 
        {
            controladorMovivimento.isStopped = true;
        }


    }



}

