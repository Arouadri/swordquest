
using UnityEngine;
using System.Collections;

public class MovimientoCoche : MonoBehaviour
{
    public float fuerza = 620f;
    public float fuerzaGiro = 85f;
    private float lecturaHorizontal;
    private float lecturaVertical;

    void Start() {
        GetComponent<Rigidbody>().mass = 0.9f;
        GetComponent<Rigidbody>().drag = 0.15f;
        GetComponent<Rigidbody>().angularDrag = 0.18f;
    }

    void Update()
    {
        lecturaVertical = Input.GetAxis("Vertical");
        lecturaHorizontal = Input.GetAxis("Horizontal");

        GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * lecturaVertical * fuerza * Time.deltaTime);
        GetComponent<Rigidbody>().AddRelativeTorque(Vector3.up * lecturaHorizontal * fuerzaGiro * Time.deltaTime);

    }
}