using UnityEngine;
using System.Collections;
//activa/desactiva alternativamente las 2 camaras 
//si clickeo en el boton
public class Interfaz : MonoBehaviour {
	public Camera camara1;
	public Camera camara2;
    public MovimientoCoche control1;
    public CharacterController control2;
    public MovimientoMecanim script;

	Rect rectangulo= new Rect (850,700,150,50); 
	void OnGUI(){
		GUI2.ScaleGUI ();
		if(GUI2.Button (rectangulo, "Cambio de camara")){
			if(camara1.enabled==true)
			{
                //cuando le damos al boton, se desactiva la camara y 
                //el script/characterController para que no se muevan
                //los dos personajes a la vez
				camara1.enabled=false;
				camara2.enabled=true;
                control1.enabled = false;
                control2.enabled = true;
                script.enabled = true;
            }
			else{
				camara1.enabled=true;
				camara2.enabled=false;
                control1.enabled = true;
                control2.enabled = false;
                script.enabled = false;
            }
		}
		GUI2.ResetGUI ();
	}
}
