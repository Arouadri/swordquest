using UnityEngine;
using System.Collections;

public class GuardarPartidaGeneral: MonoBehaviour {

    public string nombreVariable;

    public bool cargaFloat;
    public bool cargaInt;
    public bool cargaString;

    public float valorFloat;
    public int valorInt;
    public string valorString;

    void Update()
    {
        valorInt++;
    }

    void OnDestroy()
    {
        if (cargaFloat)
        {
            PlayerPrefs.SetFloat(nombreVariable, valorFloat);
        }
        if (cargaInt)
        {
            PlayerPrefs.SetInt(nombreVariable, valorInt);
        }
        if (cargaString)
        {
            PlayerPrefs.SetString(nombreVariable, valorString);
        }
    }
}
