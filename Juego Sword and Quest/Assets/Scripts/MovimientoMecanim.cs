using UnityEngine;
using System.Collections;
//activa la variable del animator cuando ocurra lo pertinente
//(si da al boton de saltar, o si se mueve, etc)
public class MovimientoMecanim : MonoBehaviour {

	public Animator animator;
	public bool avanzar;
	public bool saltar;
	public bool correr;
	public bool despIzq;
	public bool despDer;
    public bool atacar;
    public bool giroIzq;
    public bool giroDer;
    public bool bailar;

    void Update () {
		avanzar = (Input.GetAxis ("Vertical") != 0);
		animator.SetBool ("Avanzar", avanzar);
		saltar = (Input.GetButton ("Jump") == true);
		animator.SetBool ("Saltar", saltar);
		correr = (Input.GetKey(KeyCode.LeftShift)== true);
		animator.SetBool ("Correr", correr); 
		despIzq = (Input.GetKey ("q"));
		animator.SetBool ("Despizquierda", despIzq);
		despDer = (Input.GetKey ("e"));
		animator.SetBool ("Despderecha", despDer);
        bailar = (Input.GetKey("1"));
        animator.SetBool("Bailar", bailar);
        atacar = (Input.GetButton("Fire2")== true);
        animator.SetBool("Atacar", atacar);
        giroIzq = (Input.GetAxis("Horizontal") < 0);
        animator.SetBool("GiroIzq", giroIzq);
        giroDer = (Input.GetAxis("Horizontal") > 0);
        animator.SetBool("GiroDer", giroDer);
    }
}
