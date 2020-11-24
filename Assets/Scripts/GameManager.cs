using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager gameManager;
    public Transform jugador;
    public int puntuacion;

    public Text textoPuntuacion;
    public Text TextoGameOverPuntos;
    public GameObject panelGameover;

    public bool estoymuerto = false;
    
  


    // Start is called before the first frame update
    private void Awake()
    {
        gameManager = this;

        

    }

    public void actualizarPuntuacion(int puntos)
    {
        puntuacion += puntos;
        textoPuntuacion.text = "Score : " + puntuacion;

    }

    public void GameOver()
    {
        
        Time.timeScale = 0; // esto sirve para detener el tiempo que pasa en el juego a ralentizarlo

        panelGameover.SetActive(true);
        TextoGameOverPuntos.text = "score: " + puntuacion;
        estoymuerto = true;

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && estoymuerto == true)
        {
            estoymuerto = false;
            Time.timeScale = 1;

            SceneManager.LoadScene(0);

        }
    }

}
