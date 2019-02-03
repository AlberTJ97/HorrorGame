using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BubbleController : MonoBehaviour
{
    string[] phrases = { "¿Que ha pasado?", "Te noto nervioso", "Perdona.. ¿Quién era el tío?", "Lo siento, he estado ocupado", "¿Como sabes eso?", "¿A que se dedicaba?",
        "¿Y qué tenemos por ahora?", "¿Sabes algo de cómo fue?", "Creo que puedo seguir las pistas", "Trataré de ayudarte" };

    string[] response = { "Te he estado llamando, ha sido una mañana movidita", "No hay problema, nos lo encontramos a primera hora del dia, creemos que fue un pez gordo",
    "Creemos que es testigo de un juicio y se lo han cargado", "Saliendo de su casa, llegaron unos tios y le dispararon , hay dos testigos", "Vale, tu te encargas de eso, y yo seguire con el papeleo"};
    string DEFAULT_PHRASE = "Todavía no sabemos nada más del caso, sal a la ciudad para ayudarme a investigarlo";
    int lastPairPhrase;
    int lastRPhrase;
    public GameObject LButton;
    public GameObject RButton;
    public GameObject Response;
    //private ApiAiModule dialogFlow;

    private void Start()
    {
        lastPairPhrase = -2;
        //this.dialogFlow = GetComponent<ApiAiModule>();
        Response.GetComponent<Text>().text = "";

        setToNextBubble();
        GameController.leftDialogBubble += sendLeftBubbleText;
        GameController.rightDialogBubble += sendRightDialogText;

    }

    private void setToNextBubble()
    {
        lastPairPhrase += 2;
        if (lastPairPhrase >= phrases.GetLength(0))
        {
            LButton.SetActive(false);
            RButton.SetActive(false);
        }
        else
        {
            LButton.GetComponentInChildren<Text>().text = phrases[lastPairPhrase];
            RButton.GetComponentInChildren<Text>().text = phrases[lastPairPhrase + 1];
        }
    }

    private void sendLeftBubbleText()
    {
        if (lastPairPhrase < phrases.GetLength(0))
        {
            Response.GetComponent<Text>().text = response[lastPairPhrase/2];
            setToNextBubble();
        } else
        {
            Response.GetComponent<Text>().text = DEFAULT_PHRASE;
            SceneManager.LoadScene("Landscape");
        }
    }

    public void sendRightDialogText()
    {
        if (lastPairPhrase < phrases.GetLength(0))
        {
            Response.GetComponent<Text>().text = response[lastPairPhrase/2];
            setToNextBubble();
        } else
        {
            Response.GetComponent<Text>().text = DEFAULT_PHRASE;
            SceneManager.LoadScene("Landscape");
        }
    }
}


