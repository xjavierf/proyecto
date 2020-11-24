using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{
    public int vidaJugador = 100;
    public int vidaActual;
    public Slider barraVida;
    

    public Animator anim_muerto;

    public void Awake()
    {
        vidaActual = vidaJugador;
        barraVida.maxValue = vidaJugador;
        barraVida.value = vidaJugador;

        anim_muerto.SetBool("estoy_muerto", false);

    }

    public void MeMaltratan(int Dolor) { 

        vidaActual -= Dolor;
        barraVida.value = vidaActual;
        
        if (vidaActual <= 0 ) 
        {

            GetComponent<PlayerMovement>().enabled = false;
           
            anim_muerto.SetBool("estoy_muerto", true);
            Invoke("muerto", 4.16f);
            
            
        }

    }

    

    public void muerto()
    {
        
        GameManager.gameManager.GameOver();

    }

}


