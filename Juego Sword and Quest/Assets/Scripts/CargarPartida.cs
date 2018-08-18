using UnityEngine;
using System.Collections;

public class CargarPartida : MonoBehaviour {

    void start()
    {
        if (PlayerPrefs.GetInt("comprobacion") == 1)
        {

            //PlayerPrefs.GetInt("experiencia");
            //GuardarPartida.GetComponent<GuardarPartida>().vida= PlayerPrefs.GetInt("vida");
            //Application.LoadLevel(PlayerPrefs.GetInt("escenario"));

        }
    }


     
}
