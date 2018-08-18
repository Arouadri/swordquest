using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    //posicion mas a la izquierda mientras menor es el numero
    //posicion mas arriba mientras menor es el numero
    Rect jugar = new Rect(400, 325, 250, 50);//(horizontal,vertical,anchura,largo )
    Rect cargarPartida = new Rect(400, 400, 250, 50);
    Rect salir = new Rect(400, 475, 250, 50);
	void Update()
	{
		if (Input.GetKey (KeyCode.Escape)) {
			Application.Quit ();
		}
	}

    void OnGUI()
    {
        GUI2.ScaleGUI();
        if (GUI2.Button(jugar, "Empezar nueva partida")) //cambiar para borrar datos guardados
            //o asignarle unos valores iniciales que ya se modificaran la proxima vez que guardemos
        {
            PlayerPrefs.SetInt("experiencia", 1);
            PlayerPrefs.SetFloat("vida", 100);
            PlayerPrefs.SetInt("escenario", 1);
            PlayerPrefs.SetInt("comprobacion", 1);
            //Application.LoadLevel(PlayerPrefs.GetInt("escenario"));
            SceneManager.LoadScene(PlayerPrefs.GetInt("escenario"));
        }
        if (GUI2.Button(cargarPartida, "Cargar Partida")) //aqui podrias ampliar la condicion para que si no se cumple...
        {                                                  //entonces no deja clickear

			if (PlayerPrefs.GetInt ("comprobacion") == 1) {
				//Application.LoadLevel(PlayerPrefs.GetInt("escenario"));
				SceneManager.LoadScene (PlayerPrefs.GetInt ("escenario"));
			} 

        }
        if (GUI2.Button(salir, "Salir"))
        {
            Application.Quit();
            //SceneManager.
        }
        GUI2.ResetGUI();
    }
}

