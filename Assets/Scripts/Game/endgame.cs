using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class endgame : MonoBehaviour
{
    public string _menuScene = "MenuPrincipal";


    public Text texte1;
    public Text texte2;
    public Text texte3;
    public Text texte4;
    public Button rejouer;
    public Button quitter;
    IEnumerator AfficherTextes()
    {
        // texte1.CrossFadeAlpha(1f, 1f, false);
        // yield return new WaitForSeconds(0.75f);
        // texte2.CrossFadeAlpha(1f, 1f, false);
        // yield return new WaitForSeconds(0.75f);
        // texte3.CrossFadeAlpha(1f, 1f, false);
        // yield return new WaitForSeconds(0.75f);
        // texte4.CrossFadeAlpha(1f, 1f, false);
        // yield return new WaitForSeconds(0.75f);

        // texte1.CrossFadeAlpha(0f, 1f, false);
        // texte2.CrossFadeAlpha(0f, 1f, false);
        // texte3.CrossFadeAlpha(0f, 1f, false);
        // texte4.CrossFadeAlpha(0f, 1f, false);
        // yield return new WaitForSeconds(1.5f);

        // texte1.text = "Pourtant, les baleines apportent de formidables services �cosyst�miques. V�ritables ing�nieures des oc�ans, elles s�questrent le carbonne dans le fond des oc�ans et assurent ainsi la p�r�nit� de la vie sauvage marine.";
        // texte1.CrossFadeAlpha(1f, 1f, false);
        // yield return new WaitForSeconds(0.75f);
        // texte2.text = "Les prot�ger et assurer la croissance de leurs population devrait �tre adopt� partout comme un �l�ment d'une gestion carbonne responsable. Des propositions concr�tes sont propos�e par le programmes NUPES :";
        // texte2.CrossFadeAlpha(1f, 1f, false);
        // yield return new WaitForSeconds(0.75f);
        // texte3.CrossFadeAlpha(1f, 1f, false);
        // texte3.text = "Classer plus de 30% du territoire maritime fran�ais en aire maritime prot�g�e, dont 10% en protection forte, pour en faire de v�ritables sanctuaires.";
        // yield return new WaitForSeconds(0.75f);
        // yield return new WaitForSeconds(0.75f);
        // texte4.text = "G�rer durablement la ressource via la p�che artisanale et lutter contre les pratiques de p�che ill�gales ou destructrices.";
        // texte4.CrossFadeAlpha(1f, 1f, false);

        // texte1.CrossFadeAlpha(0f, 1f, false);
        // texte2.CrossFadeAlpha(0f, 1f, false);
        // texte3.CrossFadeAlpha(0f, 1f, false);
        // texte4.CrossFadeAlpha(0f, 1f, false);

        float _delayBtwTxt = 3f;

        texte1.gameObject.SetActive(true);
        yield return new WaitForSeconds(_delayBtwTxt);

        texte2.gameObject.SetActive(true);
        yield return new WaitForSeconds(_delayBtwTxt);

        texte3.gameObject.SetActive(true);
        yield return new WaitForSeconds(_delayBtwTxt);

        texte4.gameObject.SetActive(true);
        yield return new WaitForSeconds(_delayBtwTxt);


        quitter.gameObject.SetActive(true);
        rejouer.gameObject.SetActive(true);

        yield return null;
    }


    void Start()
    {
        // texte1.color = Color.black;
        // texte2.color = Color.black;
        // texte3.color = Color.black;
        // texte4.color = Color.black;

        texte1.gameObject.SetActive(false);
        texte2.gameObject.SetActive(false);
        texte3.gameObject.SetActive(false);
        texte4.gameObject.SetActive(false);




        rejouer.gameObject.SetActive(false);
        quitter.gameObject.SetActive(false);

        texte1.text = "� sa mort, votre baleine � r�cup�r�e 28 tonnes de CO2.";
        texte2.text = "En 1900, les baleines permettaient le stockage de plus de 10 millions de tonnes de carbonnes contre 2 millions seulement en 2020.";
        texte3.text = "Alors que le nombre de ces majestueux mamif�res marins se stabilise enfin, offrant un espoir de croissance de leur population, elles se retrouvent � nouveau menac� par les activit�s humaines.";
        texte4.text = "Certaines nations continuent la chasse, d'autres jettent leurs innombrables d�chets dans l'oc�an et toutes contribuent aux �missions de gaz � effet de serres.";
        StartCoroutine(AfficherTextes());
    }

    void Update()
    {
        // rejouer.onClick(SceneManager.LoadScene(jeu));
        // quitter.onClick(quitter lol);
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame(){
        Application.Quit();
    }
}