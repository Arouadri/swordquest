using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Texto1 : MonoBehaviour {

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
    //bool cofre2;
    // Use this for initialization
    void Start()
    {
        setText = new string[10];
        uiText.text = "Otro cofre en la luz...";
        setText[0] = "Otro cofre en la luz...";
        setText[1] = "Necesito salvar a mi familia, a mis amigos... Tengo que volver, prometo volver...";
        setText[2] = "...con 10.000 doblones de oro sería suficiente...Agh, tengo que centrarme, acaba de posarse el Sol, buscaré un refugio.";
        //conversacion al llegar al cofre
        setText[3] = "*Rurik abre el cofre*";
        setText[4] = "¡Oro! Esto valdrá... ¡más de 20.000 doblones!";
        setText[5] = "*Rurik descubre una cueva y algo siniestro la seduce con la experanza de encontrar más riquezas";
        //setText[6] = "";
        contador = 0;
        pausa = true;
        Time.timeScale = 0;//para empezar despausado
        cofrePlayer = FindObjectOfType<GuardarPartida>(); // falta hacer una condicion en el update para usar un booleano de guardar partida para cuando se acerque al cofre

        escenario = PlayerPrefs.GetInt("escenario");
    }


    // Update is called once per frame
    void Update()
    {
        vida = barraVida.value;

        //Conversacion inicial de los 3 primeros strings (0 al 2)

            if (Input.GetKeyDown("p") && pausa == false) //Pausa el juego si no esta pausado
            {
                pausa = true;
                Time.timeScale = 0; //pausa el juego

            }
            else if (Input.GetKeyDown("p") && pausa == true && contador <= 1) //Se encarga de la conversacion inicial del juego
            {
                contador++;

                    imagen.enabled = false;
                    uiText.enabled = false;
                    Time.timeScale = 1; //reanuda el juego
                    pausa = false;
            }
        

    }//end Update()
    //Input.GetKeyDown("p")
}
