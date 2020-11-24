using UnityEngine;
//using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    public int VidaInicial = 100;
    public int VidaActual;
    public float Tmuerte = 2.5f;
    public int puntosEnemigo;
    public AudioClip muerteSonido;

    Animator anim;
    AudioSource enemigoAudio;
    ParticleSystem particulasHit;
    public bool muerte;
    bool meHundo;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemigoAudio = GetComponent<AudioSource>();
        particulasHit = GetComponentInChildren<ParticleSystem>(); // como el componente esta en el hijo para que pueda seleccionarlo se le pone el getcomponentinchildren
        //particulasHit = transform.GetChild(1).GetComponent<ParticleSystem>(); // de esta manera no hace falta poner el getComponentInChildren si no que pones en que hijo hace el getcomponent

        VidaActual =  VidaInicial;



    }
    private void Update()
    {
        //if (meHundo)
        //{
        //    transform.Translate(-Vector3.up * Tmuerte * Time.deltaTime);  //hunde al personaje para que no se acumulen en la pantalla
        //}
    }
    public void MeDisparan(int danoRecibido, Vector3 puntoImpacto)
    {

        if (muerte)
        {
            return;     // sale del codigo y no continua hacia abajo

        }
        enemigoAudio.Play();

        VidaActual -= danoRecibido;
        particulasHit.transform.position = puntoImpacto;  // se le asigna a las particulas la posicion del punto de impacto del raycast
        particulasHit.Play();

        if (VidaActual<=0)
        {
            Muero();
        }

    }

    public void Muero()
    {
        muerte = true;

        GetComponent<CapsuleCollider>().isTrigger = true; // para que no colisione cogemos el component y lo convertimos en trigger 

        enemigoAudio.clip = muerteSonido; //le asignamos al audio sorce el clip de muerte sonido que le hemos metido para que haga cuando muere
        enemigoAudio.Play();

        GameManager.gameManager.actualizarPuntuacion(puntosEnemigo); // esto coge los puntos que se le asignen al enemigo y los manda al game manager donde actualiza la puntuacion;

        //GetComponent<NavMeshAgent>().enabled = false; // para parar el personaje una vez haya muerto y deje de seguirnos. es necesario la libreria unity.AI para poder coger el navmesh
        //se puede hacer tambien de otra forma directamente en el script del movimiento pero se puede usar, es menos eficiente por que carga la libreria AI otra vez entera
        Destroy(this.gameObject, 1.5f);

    }
}