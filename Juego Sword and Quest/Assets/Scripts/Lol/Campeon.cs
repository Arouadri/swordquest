using UnityEngine;
using System.Collections;

public class Campeon : MonoBehaviour {

	public GameObject autoataque;
	public GameObject direccion;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Input.mousePresent()
		if (Input.GetButtonDown ("Fire1")) {
			//Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			//Camera camara = GetComponent<Camera>();
			//Vector3 p = camara.ScreenToWorldPoint (new Vector2(100, 100, camara.nearClipPlane));
			//if(Physics.Raycast (ray)) Physics. 
			//{
				Instantiate (autoataque, direccion.transform.position ,direccion.transform.rotation);
			//}

		}
	
	}
}
