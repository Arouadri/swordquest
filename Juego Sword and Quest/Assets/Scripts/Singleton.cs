//using UnityEngine;
//using System.Collections;
// Script: Singleton.cs
// Descripción: Simula el patrón Singleton para objetos de juego, opcionalmente permite que el objeto persista entre escenas.
// Autor: Guillermo Calvo
// Fecha: 05.11.12
// Licencia: Dominio público

using UnityEngine;

public class Singleton : MonoBehaviour
{

    public bool persistirEntreEscenas = true;
    private bool estaInicializado = false;

    virtual public void Awake()
    {

        this.MakeSingleton();
    }

    virtual public void Start()
    {

        this.MakeSingleton();
    }

    protected bool MakeSingleton()
    {

        if (this.estaInicializado)
        {

            return (false);
        }

        this.estaInicializado = true;

        // Obtiene el nombre de singleton correspondiente al objeto de juego
        string singletonName = this.name + "Singleton";

        // Comprueba que no exista ya un objeto con el mismo nombre de singleton
        if (GameObject.Find(singletonName) != null)
        {

            // Destruye el objeto actual porque ya existía un objeto con el mismo nombre de singleton
            this.gameObject.tag = "Untagged";
            Object.Destroy(this.gameObject);

            return (false);
        }

        // Cambia el nombre actual del objeto por su nombre de singleton
        this.gameObject.name = singletonName;

        // Comprueba  si el objeto tiene que persistir entre escenas distintas
        if (this.persistirEntreEscenas)
        {

            // Evita que el objeto sea destruido al cambiar de escena
            DontDestroyOnLoad(this.gameObject);
        }

        return (true);
    }

}