using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    Rigidbody rb;
    Vector3 movimiento;

    public Animator anim;

    int floorMask;
    float camRayLenght = 1000f;
   

    private void Awake()
    {
        floorMask = LayerMask.GetMask ( "Floor"); // le asignas un valor de una capa a una variable;
        rb = GetComponent<Rigidbody>();

        anim.SetBool("moverse", false);
    }

    private void FixedUpdate()
    {

        move();
        turning();

        
    }


    private void move()
    {
        float movH = Input.GetAxis("Horizontal");
        float movV = Input.GetAxis("Vertical");

        movimiento = new Vector3(movH, 0, movV);

        movimiento = movimiento.normalized * speed * Time.deltaTime;

        rb.MovePosition(transform.position + movimiento);

        if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
        {
            anim.SetBool("moverse", true);
        }
        else
        {
            anim.SetBool("moverse", false);
        }


    }

    void turning() 
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit floorHit;


        if (Physics.Raycast(camRay, out floorHit, camRayLenght, floorMask))
        {
            Vector3 direccion = floorHit.point - transform.position;//point marca el punto del suelo en el que marca en puntero, si se usa transform.position usa la posicion del objeto que señale en vez del puntero

            direccion.y = 0f; //se pone 0 en la y para que el personaje no mira hacia arriba o hacia abajo

            Quaternion newRotation = Quaternion.LookRotation(direccion);


            rb.MoveRotation(newRotation); 
        }

    }
}
