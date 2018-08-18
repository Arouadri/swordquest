using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

//este script gestiona la condicion de derrota, el guardado de partida y los ataques del pj
public class GuardarPartida : MonoBehaviour {
    public float vida;
    public bool cofre = false; // para saber si han llegado al cofre
    public int escenario;
    public int puntosExp;
    private int estado;
    private float waitToReload = 5; //tiempo de espera hasta la muerte
    private float tiempoGolpe = 2f;
    private bool atacando;
    public Slider barraVida;
    public GameObject sword; //sword
    private Animator anim;
    //Para el mensaje de muerte:
    public Text uiText;
    public Image imagen;
    //Para mostrar el nivel
    public Text nivel;
	private CharacterController characterController;

    void Start()
    {
        cofre = false;
        escenario = PlayerPrefs.GetInt("escenario");
        vida=PlayerPrefs.GetFloat("vida"); 
        barraVida.value=vida;
        puntosExp =PlayerPrefs.GetInt("experiencia"); 

        anim = GetComponentInChildren<Animator>();


        estado = 0;
        atacando = false;

        this.GetComponentInChildren<BoxCollider>().enabled = false;


    }

    //Teletransportador entre escenas
    void OnTriggerEnter(Collider infoAcceso)
    {
        if (infoAcceso.tag == "PrimerTeletransportador")
        {
            PlayerPrefs.SetInt("experiencia", puntosExp);
            PlayerPrefs.SetFloat("vida", vida);
            //escenario++;
            //PlayerPrefs.SetInt("escenario", escenario);
            //PlayerPrefs.SetInt("comprobacion", 1);//1= true = hay partida guardada. 0 es lo contrario.
                                                  //futuramente hacer una comprobacion para cuando no haya mas escenarios...sea escenario=0 y borrar los datos guardados;
                                                  //if(escenario==numMaxEscenario){PlayerPrefs.SetInt("escenario", 0); PlayerPrefs.SetInt("comprobacion", 1);}
            //Application.LoadLevel(PlayerPrefs.GetInt("escenario"));
            cofre = true;
           

        }
            if (infoAcceso.tag == "Teletransportador") //probando para transportar al personaje a otro nivel
        {

            PlayerPrefs.SetInt("experiencia", puntosExp);
            PlayerPrefs.SetFloat("vida", vida);
            escenario++;
            PlayerPrefs.SetInt("escenario", escenario);
            PlayerPrefs.SetInt("comprobacion", 1);//1= true = hay partida guardada. 0 es lo contrario.
            //futuramente hacer una comprobacion para cuando no haya mas escenarios...sea escenario=0 y borrar los datos guardados;
            //if(escenario==numMaxEscenario){PlayerPrefs.SetInt("escenario", 0); PlayerPrefs.SetInt("comprobacion", 1);}
            Application.LoadLevel(PlayerPrefs.GetInt("escenario"));
        }
      
    }
    void FixedUpdate()
    {
		
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        vida =barraVida.value;
        nivel.text = "Nivel: " + puntosExp;

        if(estado==7 || vida<=0) // a los 5 segundos muertos nos mandara al menu (condicion de derrota)
        {
            GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;
            
            if (waitToReload==5) // muestra en la cuenta atras una vez muertos un mensaje de no tener vida
            {
                imagen.enabled = true;
                uiText.enabled = true;
                uiText.text = "¡ HAS MUERTO !";
				estado = 7;
				anim.SetInteger("Estado", estado);
            }

            waitToReload -= Time.deltaTime;

            if (waitToReload < 0)
            {
                SceneManager.LoadScene(0); // nos lleva al menu cuando el contador sea 0
            }
        }
        else
        { 
			characterController = GetComponent<CharacterController>();
			float horizontal=CrossPlatformInputManager.GetAxis ("Horizontal");
			float vertical=CrossPlatformInputManager.GetAxis("Vertical");
			if (horizontal != 0f || vertical != 0f )
            { ////&& characterController.isGrounded
                estado = 1;//andando;
			}

            if (tiempoGolpe <= 0f)
            {
                sword.GetComponent<BoxCollider>().enabled = false;
                estado = 0;
                atacando = false;
                tiempoGolpe = 1f;
            }

            if (Input.GetButton("Fire2") == true && tiempoGolpe == 2f) // muestra en la cuenta atras una vez muertos un mensaje de no tener vida
            {
                sword.GetComponent<BoxCollider>().enabled = true;
                atacando = true; //si pongo estado = 6; solo se animaria durante un frame por el Input.GetButton del condicional
            }
            if (atacando == true) //solo en este frame
            {
                estado=6;
            }

            if (tiempoGolpe > 0f && estado == 6)
            { 
            tiempoGolpe -= (Time.deltaTime)*1.5f;
            }

            if (tiempoGolpe <= 0f || sword.GetComponentInChildren<BoxCollider>().enabled == false) //si ha terminado la animacion o la espada ha impactado en un enemigo(vease en scripts de enemigos (Zombie,Spider))
            {
                sword.GetComponent<BoxCollider>().enabled = false;
				if (horizontal != 0f || vertical != 0f && characterController.isGrounded)
                {
                    estado = 1;//andando;
				} 
				else {
					if(characterController.isGrounded)
					estado = 0;
				}
                
                atacando = false;
                tiempoGolpe = 2f;
            }
            /*
			if (tiempoGolpe <= 0f || sword.GetComponentInChildren<BoxCollider>().enabled == false) //si ha terminado la animacion o la espada ha impactado en un enemigo(vease en scripts de enemigos (Zombie,Spider))
			{
				sword.GetComponent<BoxCollider>().enabled = false;
				if (horizontal != 0f || vertical != 0f) {
					estado = 1;//andando;
				} 
				else {
					estado = 0;
				}
				atacando = false;
				tiempoGolpe = 2f;
			}
			*/	

			if (Input.GetKey (KeyCode.LeftShift) && estado!=6 && estado!=7 && (horizontal != 0f || vertical != 0f && characterController.isGrounded)  )
            {      //no hace falta tanta condicion por las transiciones del animator && characterController.isGrounded
                estado = 2; //correr 
			}

			if (Input.GetKey (KeyCode.Space) && estado!=6 && estado!=7 && characterController.isGrounded) {

                estado = 3; //saltar
			}

            anim.SetInteger("Estado", estado);
        }
        
    }

}
