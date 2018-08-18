using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CondicionDeVictoria : MonoBehaviour
{
    public int zombie;
    private bool victoria = false;
    //private int waitToReload= 5;
    //Para el mensaje de victoria:
    //public Text uiText;
    //public Image imagen;
    // Use this for initialization
    void Start()
    {
        zombie = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (zombie >= 5)
        {
            victoria = true;
        }
        if (victoria)
        {/*
            if (waitToReload == 5) // muestra en la cuenta atras una vez muertos un mensaje de no tener vida
            {
                imagen.enabled = true;
                uiText.enabled = true;
                uiText.text = "¡ HAS Ganado !";
            }

            //waitToReload -= Time.deltaTime;

            if (waitToReload < 0)
            {
                SceneManager.LoadScene(0); // nos lleva al menu cuando el contador sea 0
            }*/
			PlayerPrefs.SetInt("comprobacion", 1);
            SceneManager.LoadScene(0); // nos lleva al menu cuando el contador sea 0
        }
    }
}