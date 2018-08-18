using UnityEngine;
using System.Collections;

public class CargarPartidaGeneral : MonoBehaviour {
    public string nombreVariable;

    public bool cargaFloat;
    public bool cargaInt;
    public bool cargaString;

    public float valorFloat;
    public int valorInt;
    public string valorString;

    // Use this for initialization
    void Start () {
        if (cargaFloat)
        {
            PlayerPrefs.GetFloat(nombreVariable);
        }
        if (cargaInt)
        {
            PlayerPrefs.GetInt(nombreVariable);
        }
        if (cargaString)
        {
            PlayerPrefs.GetString(nombreVariable);
        }

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
