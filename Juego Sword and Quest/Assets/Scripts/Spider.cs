using UnityEngine;
using System.Collections;

public class Spider : MonoBehaviour {

    public Animator anim;
    //public GameObject player;
    public float vidaSpider = 80;
    private Chase script;
    private GuardarPartida expPlayer;

    private AudioSource m_AudioSource;
    private Sonidos sound;

    // Use this for initialization
    void Start()
    {
        vidaSpider = 80;
        script = GetComponent<Chase>();
        expPlayer = FindObjectOfType<GuardarPartida>();
    }

    void OnTriggerEnter(Collider other)
    {
		if ((other.tag == "EspadaCaballero") && (vidaSpider > 0f) && (other.GetComponent<BoxCollider>().enabled == true)) // vida>0f evita que al acercarnos al cadaver de la araña subamos niveles gratis
        {
            vidaSpider -= (20f + expPlayer.puntosExp*10);

            if (vidaSpider <= 0f) //si muere la araña
            {
                anim.SetBool("Muerto", true);
                script.enabled = false;
                //script.enabled = false;
                GetComponent<SphereCollider>().enabled=false;
                expPlayer.puntosExp = expPlayer.puntosExp + 1;

                if (anim.GetBool("Muerto") == true)
                {
                    m_AudioSource.clip = sound.muerteSpider;
                    m_AudioSource.Play();
                }

            }
            //other.GetComponentInChildren<BoxCollider>().enabled = false;
			other.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
