using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DetectarGolpe : MonoBehaviour
{

    public Slider barraVida;

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "EnemyZombie")
        {
            barraVida.value -= 20;
        }

        if (other.tag == "Spider")
        {
            barraVida.value -= 10;
        }
        if (other.tag == "Cura" && barraVida.value>0 && barraVida.value<=80)
        {
            barraVida.value += 20;
            Destroy(other.gameObject);
        }
    }

}
