using UnityEngine;
using System.Collections;

public class Zombie : MonoBehaviour
{ 
    //private GameObject sword;
    public float vidaZombie = 100;
    public float puntosExp=0;
    private GuardarPartida expPlayer;
    private CondicionDeVictoria contadorVictoria;
	private Chase script;
    //public GameObject zombie;
    private AudioSource m_AudioSource;
    //private AudioClip ataqueZombie; 
    //private AudioClip muerteZombie;
    private Sonidos sound; 

    // Use this for initialization
    void Start()
    {
        vidaZombie = 100;
        puntosExp = PlayerPrefs.GetInt("experiencia");
        expPlayer = FindObjectOfType<GuardarPartida>();
        //sword = GameObject.FindWithTag("EspadaPlayer");
        contadorVictoria=FindObjectOfType<CondicionDeVictoria>();
		script = GetComponent<Chase>();
        m_AudioSource = GetComponent<AudioSource>();
        sound = FindObjectOfType<Sonidos>();
    }

    void OnTriggerEnter(Collider other)
    {
		
        if (other.tag == "EspadaCaballero" && other.GetComponent<BoxCollider>().enabled == true)
        {
            vidaZombie -= (20f + expPlayer.puntosExp * 10);

            if (vidaZombie <= 0f) //si muere el zombie
            {
                if(PlayerPrefs.GetInt("escenario")==3)
                { 
                    contadorVictoria.zombie = contadorVictoria.zombie + 1;
                }
				if (this.tag == "EnemyZombie2") {
					Animator anim;
					anim = GetComponent<Animator>();
					anim.SetBool("Muerto", true);
                    if (anim.GetBool("Muerto") == true)
                    {
                        m_AudioSource.clip = sound.muerteZombie;
                        m_AudioSource.Play();
                    }

                    script.enabled = false;
				} else {
					Destroy (this.gameObject);
				}
                expPlayer.puntosExp = expPlayer.puntosExp + 1;

            }
            //sword.GetComponentInChildren<BoxCollider>().enabled = false;
			other.GetComponent<BoxCollider>().enabled = false;
        }
    }

    void Update()
    {
        /*
        if (anim.GetBool("Muerto")==true)
        m_AudioSource.clip = m_JumpSound;
        m_AudioSource.Play();*/
    }

}
