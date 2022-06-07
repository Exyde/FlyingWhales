using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class endgame : MonoBehaviour
{
    public string _menuScene = "MenuPrincipal";
    public float _delayBtwTxt = 3f;

    public Text texte1;
    public Text texte2;
    public Text texte3;
    public Text texte4;
    public Button rejouer;
    public Button quitter;
    IEnumerator AfficherTextes()
    {
        texte1.gameObject.SetActive(true);
        yield return new WaitForSeconds(_delayBtwTxt);

        texte2.gameObject.SetActive(true);
        yield return new WaitForSeconds(_delayBtwTxt);

        texte3.gameObject.SetActive(true);
        yield return new WaitForSeconds(_delayBtwTxt);

        texte4.gameObject.SetActive(true);
        yield return new WaitForSeconds(_delayBtwTxt);

        texte1.text = "Pourtant, les baleines apportent de formidables services écosystémiques. Véritables ingénieures des océans, elles séquestrent le carbonne dans le fond des océans et assurent ainsi la pérénité de la vie sauvage marine.";
        yield return new WaitForSeconds(_delayBtwTxt);

        texte2.text = "Les protéger et assurer la croissance de leurs population devrait être adopté partout comme un élément d'une gestion carbonne responsable. Des propositions concrètes sont proposée par le programmes NUPES :";
        yield return new WaitForSeconds(_delayBtwTxt);

        texte3.text = "Classer plus de 30% du territoire maritime français en aire maritime protégée, dont 10% en protection forte, pour en faire de véritables sanctuaires.";
        yield return new WaitForSeconds(_delayBtwTxt);

        texte4.text = "Gérer durablement la ressource via la peche artisanale et lutter contre les pratiques de peche illegales ou destructrices.";
        yield return new WaitForSeconds(_delayBtwTxt);


        quitter.gameObject.SetActive(true);
        rejouer.gameObject.SetActive(true);

        yield return null;
    }


    void Start()
    {
        texte1.gameObject.SetActive(false);
        texte2.gameObject.SetActive(false);
        texte3.gameObject.SetActive(false);
        texte4.gameObject.SetActive(false);

        rejouer.gameObject.SetActive(false);
        quitter.gameObject.SetActive(false);

        texte1.text = "A sa mort, votre baleine a récupéré 28 tonnes de CO2.";
        texte2.text = "En 1900, les baleines permettaient le stockage de plus de 10 millions de tonnes de carbonnes contre 2 millions seulement en 2020.";
        texte3.text = "Alors que le nombre de ces majestueux mamifères marins se stabilise enfin, offrant un espoir de croissance de leur population, elles se retrouvent  à nouveau menacée par les activités humaines.";
        texte4.text = "Certaines nations continuent la chasse, d'autres jettent leurs innombrables déchets dans l'océan et toutes contribuent aux émissions de gaz à effet de serres.";

        StartCoroutine(AfficherTextes());
    }

    public void ReloadGame() => SceneManager.LoadScene(0);
    public void QuitGame() => Application.Quit();
}