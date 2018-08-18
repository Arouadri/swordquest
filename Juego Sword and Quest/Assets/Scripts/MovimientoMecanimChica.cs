using UnityEngine;
using System.Collections;
//activa la variable del animator cuando ocurra lo pertinente
//(si da al boton de saltar, o si se mueve, etc)
public class MovimientoMecanimChica: MonoBehaviour {

	public Animator animator;
	public bool correr;
	public bool saltar;
    public bool atacar;
    public bool coger;
    public bool bailar;
    public bool andar;

    void Update () {

        /*
            andar = ((Input.GetAxis("Vertical") != 0) && (Input.GetKey(KeyCode.LeftShift) == false));
            animator.SetBool("Andar", andar);
            coger = (Input.GetKey("e"));
            animator.SetBool("Coger", coger);
            atacar = (Input.GetButton("Fire2") == true);
            animator.SetBool("Atacar", atacar);
            correr = (Input.GetKey(KeyCode.LeftShift) == true);
            animator.SetBool("Correr", correr);
       */
        /*despIzq = (Input.GetKey ("n"));
		animator.SetBool ("Despizquierda", despIzq);
		despDer = (Input.GetKey ("m"));
		animator.SetBool ("Despderecha", despDer);*/

        /*
        giroIzq = (Input.GetAxis("Horizontal") < 0);
        animator.SetBool("GiroIzq", giroIzq);
        giroDer = (Input.GetAxis("Horizontal") > 0);
        animator.SetBool("GiroDer", giroDer);
        */
    }
}
