using UnityEngine;
using System.Collections;

public class MovimientoCampeon : MonoBehaviour {
	
	public float velocidad = 6.0f;
	public float giro = 90.0f;
	public float salto = 8.0f;
	public float gravedad = 20.0f;
	private Vector3 movimiento = Vector3.zero;
	public CharacterController controladorMovimiento;
	
	// Update is called once per frame
	void Update () {
		//si esta en el suelo
		if (controladorMovimiento.isGrounded) {
			
			float vertical = Input.GetAxis ("Vertical");
			
			movimiento = new Vector3 (0, 0, vertical);
			
			
			
			movimiento = transform.TransformDirection (movimiento);
			
			movimiento *= velocidad;
			/* Lo quito porque se me bugea con la animacion de saltar
			if(Input.GetButton ("Jump")){
				movimiento.y=salto;
			}
			*/
		} 
		else {
			//simula gravedad (no tener el componente rigidbody)
			movimiento.y -= gravedad + Time.deltaTime;
		}
		
		transform.Rotate (Input.GetAxis ("Horizontal") * Vector3.up * giro * Time.deltaTime);
		//mueve el objeto y en segundos
		controladorMovimiento.Move(movimiento * Time.deltaTime);
		
	}
}