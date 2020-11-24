using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generador : MonoBehaviour
{

    public GameObject [] enemigos;

    public Transform[] puntosSpawn;

    public float tMin, tMax;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("generarEnemigo", Random.Range(tMin,tMax));
    }

    
    public void generarEnemigo()
    {
        Invoke("generarEnemigo", Random.Range(tMin, tMax));
        int numEnemigo = Random.Range(0, enemigos.Length);
        int numPosicionSpawn = Random.Range(0, puntosSpawn.Length);

        Instantiate(enemigos[numEnemigo], puntosSpawn[numPosicionSpawn].position, enemigos[numEnemigo].transform.rotation);


    }
}
