using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Chase : MonoBehaviour {

    private Transform transformPlayer;
    private Animator anim;
    private GuardarPartida playerVida;
    float distanciaReaccion = 23f;
    float distanciaGolpe = 1.5f;
    float velocidadMov = 0.007f; //0.015f esta bien antes de compilarlo, pero despues de ello va muy rapido

    private AudioSource m_AudioSource;
    private Sonidos sound;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        transformPlayer = GameObject.FindGameObjectWithTag("Caballero").transform;
        //barraVida = GameObject.FindGameObjectWithTag("BarraVida");
        //sliderBarraVida = GetComponent<Slider>();
        playerVida = FindObjectOfType<GuardarPartida>();
        m_AudioSource = GetComponent<AudioSource>();
        sound = FindObjectOfType<Sonidos>();
    }
	
	// Update is called once per frame
	void Update () {
		transformPlayer = GameObject.FindGameObjectWithTag("Caballero").transform;
        //barraVida = GameObject.FindGameObjectWithTag("BarraVida");
        //sliderBarraVida = GetComponent<Slider>();

        //Si la barra del enemigo es igual o menor que 0, no continuamos con el codigo. (tambien podriamos destroy este componente)
        //if (barraVida.value <= 0) return; no funciona el return
        if (playerVida.vida <= 0)
        {
            anim.SetBool("Quieto", true);
        }
        else 
        { 
            //lo comentado es si queremos que el enemigo tenga un angulo de vision
            //Vector3 direction = player.position - this.transform.position;
            //float angulo = Vector3.Angle(direction, this.tranform.forward);
            if (Vector3.Distance(transformPlayer.position, this.transform.position) < distanciaReaccion) //&& angulo < 30
            {
                Vector3 direction = transformPlayer.position - this.transform.position;
                direction.y = 0;

                this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);

                anim.SetBool("Quieto", false);
                if (direction.magnitude > distanciaGolpe)
                {
                    this.transform.Translate(0, 0, velocidadMov);
                    anim.SetBool("Caminar", true);
                    anim.SetBool("Atacar", false);
                }
                else
                {
                
                    
                    anim.SetBool("Atacar", true);
                    anim.SetBool("Caminar", false);

                    if (this.tag == "EnemyZombie2" || this.tag == "EnemyZombie")
                    {
                       m_AudioSource.clip = sound.ataqueZombie;
                       m_AudioSource.Play();
                    }

                    if (this.tag == "Spider")
                    {
                        m_AudioSource.clip = sound.ataqueSpider;
                        m_AudioSource.Play();
                     }

                }

            }
            else
            {
                anim.SetBool("Quieto", true);
                anim.SetBool("Caminar", false);
                anim.SetBool("Atacar", false);
            }
            
        }


    }
}
