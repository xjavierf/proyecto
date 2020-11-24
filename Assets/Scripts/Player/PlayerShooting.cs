using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public int calibreBala;
    public float alcanceArma;
    public float cadenciaArma;
    float ultimoDisparo;

    Ray rayoTiro = new Ray();
    RaycastHit hitTiro;
    int capaDisparable;


    ParticleSystem particulasPistola; //particulas bala
    LineRenderer tiroLinea; // linea que deja el disparo
    AudioSource SonidoTiro; //sonido de la bala
    Light luzTiro; // luz que provoca la bala
    public Light caraTiro; // fogonazo en la cara al disparar
    float duracionEfecto = 0.2f;

    private void Awake()
    {
        capaDisparable = LayerMask.GetMask("Shootable");
        particulasPistola = GetComponent<ParticleSystem>();
        tiroLinea = GetComponent<LineRenderer>();
        luzTiro = GetComponent<Light>();
        SonidoTiro = GetComponent<AudioSource>();
    }

    private void Update()
    {
        ultimoDisparo += Time.deltaTime;                                                //va sumando a ultimo disparo
        if (Input.GetButtonDown("Fire1") && ultimoDisparo >= cadenciaArma)               // es la cadencia del arma
        {
            Disparar();

        }

        if (ultimoDisparo >= duracionEfecto * cadenciaArma)
        {
            DesacativarEfectos();


        }

    }
    private void Disparar()
    {
        ultimoDisparo = 0;         //reseteamos la cadencia para que no pueda dispara todo el rato
        SonidoTiro.Play();

        luzTiro.enabled = true;
        caraTiro.enabled = true;

        particulasPistola.Stop();
        particulasPistola.Play();

        tiroLinea.enabled=true;
        tiroLinea.SetPosition(0, transform.position);

        rayoTiro.origin= transform.position;
        rayoTiro.direction = transform.forward;

        if (Physics.Raycast(rayoTiro, out hitTiro, alcanceArma, capaDisparable))
        {
            // if (hitTiro.collider.CompareTag("Enemy") {                                  //esta es otra forma de hacerlo 
            //    EnemyHealth vidaenemigo = hitTiro.collider.GetComponent<EnemyHealth>();


            // }



            EnemyHealth vidaenemigo = hitTiro.collider.GetComponent<EnemyHealth>();

            if (vidaenemigo != null)
            {
                vidaenemigo.MeDisparan(calibreBala, hitTiro.point);
               
            }

            tiroLinea.SetPosition(1, hitTiro.point);

            

        }
        else
            {
                tiroLinea.SetPosition(1, rayoTiro.origin + rayoTiro.direction * alcanceArma);

            }

    }

    public void DesacativarEfectos() {

        tiroLinea.enabled = false;
        luzTiro.enabled = false;
        caraTiro.enabled = false;

    }
}
