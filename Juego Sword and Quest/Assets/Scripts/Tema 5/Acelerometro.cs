using UnityEngine;
using System.Collections;

public class Acelerometro : MonoBehaviour {
    public float velocidad = 10.0F;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 dir = Vector3.zero;
        dir.x = -Input.acceleration.y;
        dir.y = Input.acceleration.x;
        if (dir.sqrMagnitude > 1)
        {
            dir.Normalize();
        }
        dir *= Time.deltaTime;
        transform.Translate(dir * velocidad);
	}
}
