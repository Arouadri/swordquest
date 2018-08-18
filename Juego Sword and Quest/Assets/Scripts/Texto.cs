using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Texto : MonoBehaviour
{
    public float vida;
    public int escenario;
    public int puntosExp;
    public Slider barraVida;

    public Text uiText;
    public Image imagen;
    public string[] setText;
    public int contador;
    bool pausa;

    public GuardarPartida cofrePlayer;

    // Use this for initialization
    void Start()
    {
        setText = new string[10];
        uiText.text = "Me llamo Rurik, estoy escapando de la esclavitud que sufre mi pueblo.";
        setText[0] = "Me llamo Rurik, estoy escapando de la esclavitud que sufre mi pueblo.";
        setText[1] = "Necesito salvar a mi familia, a mis amigos... Tengo que volver, prometo volver...";
        setText[2] = "...con 10.000 doblones de oro sería suficiente...Agh, tengo que centrarme, acaba de posarse el Sol, buscaré un refugio.";
        //conversacion al llegar al cofre
        setText[3] = "*Rurik abre el cofre*";
        setText[4] = "¡Oro! Esto valdrá... ¡más de 20.000 doblones!";
        setText[5] = "*Rurik descubre una cueva y algo siniestro la seduce con la experanza de encontrar más riquezas*";
        //setText[6] = "";
        contador = 0;
        pausa = true;
        Time.timeScale = 0;//para empezar despausado
        cofrePlayer = FindObjectOfType<GuardarPartida>();

        escenario = PlayerPrefs.GetInt("escenario");
    }


    // Update is called once per frame
    void Update()
    {
        vida = barraVida.value;

        //Texto inicial de los 3 primeros strings (0 al 2)
        if (contador < 3 && pausa==true)
        { 
        if (Input.GetKeyDown("p") && pausa == false) //Pausa el juego si no esta pausado
            {
                pausa = true;
                Time.timeScale = 0; //pausa el juego

            }
            else if (Input.GetKeyDown("p") && pausa == true && contador <= 2) //Se encarga de la conversacion inicial del juego
            {
                contador++;
                uiText.text = setText[contador];
                if (contador == 3)
                {
                    imagen.enabled = false;
                    uiText.enabled = false;
                    Time.timeScale = 1; //reanuda el juego
                    pausa = false;
                }
            }
        }
        
         //texto al llegar al cofre
         if (cofrePlayer.cofre == true) //probando el trigger del cofre para ir a otro nivel/escena
         {
            if (Input.GetKeyDown("p") && contador == 6)
            {
                escenario++;
                PlayerPrefs.SetInt("escenario", escenario);
               // PlayerPrefs.SetInt("comprobacion", 1);//1= true = hay partida guardada. 0 es lo contrario.
                                                      //futuramente hacer una comprobacion para cuando no haya mas escenarios...sea escenario=0 y borrar los datos guardados;
                                                      //if(escenario==numMaxEscenario){PlayerPrefs.SetInt("escenario", 0); PlayerPrefs.SetInt("comprobacion", 1);}
                Application.LoadLevel(PlayerPrefs.GetInt("escenario"));
                //SceneManager.LoadScene(PlayerPrefs.GetInt("escenario"));

            }

            if (contador == 3 )
            {
                pausa = true;
                imagen.enabled = true;
                uiText.enabled = true;
                uiText.text = setText[contador];
                Time.timeScale = 0;
                contador++;

            }
            

            
            if (contador <= 5 && contador >= 4 && pausa == true)
             {
                 
                 if (Input.GetKeyDown("p") && pausa == false) //Pausa el juego si no esta pausado
                 {
                     //pausa = true;
                     Time.timeScale = 0; //pausa el juego
                     

                 }
                 else if (Input.GetKeyDown("p") && pausa == true && contador <= 5) //Se encarga de la conversacion del cofre
                 {
                     
                     if (imagen.enabled == false)
                     {
                         imagen.enabled = true;
                         uiText.enabled = true;
                         Time.timeScale = 0;
                         
                     }
                     /*
                    if (contador == 6)
                    {
                        imagen.enabled = false;
                        uiText.enabled = false;
                        //Time.timeScale = 1; //no es necesario quitar el pause
                        //pausa = false;

                    }*/

                    uiText.text = setText[contador];
                    contador++;
                    
                 }

                //if (contador == 6 && pausa==true)
                //{
                    //imagen.enabled = false;
                    //uiText.enabled = false;
                    //Time.timeScale = 1; //no es necesario quitar el pause
                    //pausa = false;

                //}
            }
             
           
         }

    }//end Update()

}