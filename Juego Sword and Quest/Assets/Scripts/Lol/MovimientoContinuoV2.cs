using UnityEngine;
using System.Collections;

public class MovimientoContinuoV2 : MonoBehaviour {
    public static Vector3 posicion;
    public float velocidad = 7f;
	
	// Update is called once per frame
	void Update () {
        float step = velocidad * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, posicion, step);
	}
}
