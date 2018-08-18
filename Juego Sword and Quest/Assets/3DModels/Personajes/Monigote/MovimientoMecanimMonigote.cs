using UnityEngine;
using System.Collections;
//activa la variable del animator cuando ocurra lo pertinente
//(si da al boton de saltar, o si se mueve, etc)
public class MovimientoMecanimMonigote : MonoBehaviour
{

    public Animator animator;
    public bool accion;
    public bool atacar;

    void Update()
    {
        accion = (Input.GetButton("Fire2") == true);
        animator.SetBool("Accion", accion);
        atacar = (Input.GetButton("Fire1") == true);
        animator.SetBool("Atacar", atacar);
        /*
        avanzar = (Input.GetAxis("Vertical") != 0);
        animator.SetBool("Avanzar", avanzar);
        saltar = (Input.GetButton("Jump") == true);
        animator.SetBool("Saltar", saltar);
        correr = (Input.GetKey(KeyCode.LeftShift) == true);
        animator.SetBool("Correr", correr);
        girarIzq = (Input.GetAxis("Horizontal") < 0);
        animator.SetBool("Girarizquierda", girarIzq);
        girarDer = (Input.GetAxis("Horizontal") > 0);
        animator.SetBool("Girarderecha", girarDer);
        atacar = (Input.GetButton("Fire2") == true);
        animator.SetBool("Atacar", atacar);
        */
    }
}