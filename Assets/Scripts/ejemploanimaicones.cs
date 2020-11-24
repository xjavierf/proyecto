using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ejemploanimaicones : MonoBehaviour
{
    public Animator anim;


    private AudioClip sonido;
    private int numero;

    private void Awake()
    {
        anim.SetInteger("int", 10);
        anim.SetFloat("float", 15.2f);
        anim.SetBool("bool", true);
        anim.SetTrigger("trigger");


    }


    private void Update()
    {
        if (Input.GetAxis("Vertical") != 0)
        {
            anim.SetBool("bool", true);
        }
        else
        {
            anim.SetBool("bool", false);
        }
    }

    public void ReproducirSonido(AudioClip sonidoAnim) {

        sonido = sonidoAnim;



    }

    public void ReproducirSonidoNumero(int numAnim)
    {
        numero = numAnim;
    }

    public void ReproducirSonidoFinal()
    {

        //GetComponent<AudioSource>().clip = sonido;
        //GetComponent<AudioSource>().Play;
        //print(numero);


    }
}

