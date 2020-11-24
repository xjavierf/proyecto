using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    public float CadeniciaAtaque;
    public int DanoAtaque;
    bool RangoAtaque;
    float TiempoDesdeUltimoAtaque;


    

    

    private void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject == GameManager.gameManager.jugador.gameObject) // comparo que se choque con el jugador, que lo llamo desde el gamemanager que lo tengo 
        //{               con el comparetag se puede hacer igual pero para proyectos en los que hay muchas tag es mejor usar el gamemanager

        //}
        if (other.CompareTag("Player"))
        {
            RangoAtaque = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            RangoAtaque = false;

        }
    }

    private void Update()
    {
        TiempoDesdeUltimoAtaque += Time.deltaTime;

        if (RangoAtaque == true && !GetComponent<EnemyHealth>().muerte && TiempoDesdeUltimoAtaque >= CadeniciaAtaque)
        {
            
            GameManager.gameManager.jugador.GetComponent<PlayerHealth>().MeMaltratan(DanoAtaque); // si he hecho el codigo de el trigger por collider no es necesario poner el gamemanager por que ya lo he nombrado antes en el script
            TiempoDesdeUltimoAtaque = 0;
        }
    }
}
