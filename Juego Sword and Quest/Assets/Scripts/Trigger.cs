using UnityEngine;
using System.Collections;

public class Clonar : MonoBehaviour {
    public int nivel = 0;
    public Vector3 prueba;
    public GameObject gameobject;
    void OnTriggerEnter(Collider infoAcceso)
    {
        if(infoAcceso.tag == "Player") //probando para transportar al personaje a otro nivel
        {

            //GetComponent<Transform>().position = prueba; //mueve el teletransportador (donde este el script)
            //infoAcceso.GetComponent<Transform>().position = prueba; //mueve el player
            Destroy(gameobject);

        }
       
    }
    /* esto me va con objetos con rigidbody con el trigger desactivado que chocan con otros iguales
    void OnCollisionEnter()
    {
        nivel++;
    }
    */
}

