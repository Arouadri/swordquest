using UnityEngine;
using System.Collections;

public class MovimientoPersonaje : MonoBehaviour {
    float vertical;
    float horizontal;
    public float velocidad = 6.0f;
    public float velocidadLateral = 3.0f;
    public float sprint = 7.0f;
    public float giro = 90.0f;
	public float salto = 8.0f;
	public float gravedad = 20.0f;
	private Vector3 movimiento = Vector3.zero;
    private Vector3 movimientoHorizontal = Vector3.zero;
    public CharacterController controladorMovimiento;
    float prueba;
	
	// Update is called once per frame
	void Update () {
		//si esta en el suelo
		if (controladorMovimiento.isGrounded) {
            vertical = Input.GetAxis ("Vertical");
            horizontal = Input.GetAxis("Horizontal");
			movimiento = new Vector3 (0, 0, vertical);
            movimientoHorizontal = new Vector3(horizontal, 0, 0);

            if (Input.GetKey(KeyCode.LeftShift) == false)
            {
                movimiento *= velocidad;
            }
            else
            {
                movimiento *= sprint;// si esta corriendo, incremento su velocidad
            }

            movimiento = transform.TransformDirection(movimiento);
            movimientoHorizontal = transform.TransformDirection(movimiento);

            if (vertical != 0) //si se mueve hacia delante o hacia atras
            {
                transform.Rotate(Input.GetAxis("Horizontal") * Vector3.up * giro * Time.deltaTime);
                //mueve el objeto y en segundos
                controladorMovimiento.Move(movimiento * Time.deltaTime);

            }
            else
            {
               
                if (Input.GetKey("q"))
                {
                    movimientoHorizontal *= velocidadLateral;
                    transform.Translate(movimientoHorizontal * Time.deltaTime) ;
                }
                else
                {
                    //controladorMovimiento.Move(movimiento * Time.deltaTime);
                    if (Input.GetKey("e"))
                    {
                        movimientoHorizontal *= velocidadLateral;
                        transform.Translate(movimientoHorizontal * Time.deltaTime);
                    }
                }
            }
        } 
		else {
			//simula gravedad (no tener el componente rigidbody)
			movimiento.y -= gravedad + Time.deltaTime;
		}
       
		
	}
}