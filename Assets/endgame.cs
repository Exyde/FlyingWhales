using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class endgame : MonoBehaviour
{

    public Text texte1;
    public Text texte2;
    public Text texte3;
    public Text texte4;
    public Button rejouer;
    public Button quitter;
    IEnumerator AfficherTextes()
    {
        texte1.CrossFadeAlpha(1f, 1f, false);
        yield return new WaitForSeconds(0.75f);
        texte2.CrossFadeAlpha(1f, 1f, false);
        yield return new WaitForSeconds(0.75f);
        texte3.CrossFadeAlpha(1f, 1f, false);
        yield return new WaitForSeconds(0.75f);
        texte4.CrossFadeAlpha(1f, 1f, false);
        yield return new WaitForSeconds(0.75f);

        texte1.CrossFadeAlpha(0f, 1f, false);
        texte2.CrossFadeAlpha(0f, 1f, false);
        texte3.CrossFadeAlpha(0f, 1f, false);
        texte4.CrossFadeAlpha(0f, 1f, false);
        yield return new WaitForSeconds(1.5f);

        texte1.text = "Pourtant, les baleines apportent de formidables services écosystémiques. Véritables ingénieures des océans, elles séquestrent le carbonne dans le fond des océans et assurent ainsi la pérénité de la vie sauvage marine.";
        texte1.CrossFadeAlpha(1f, 1f, false);
        yield return new WaitForSeconds(0.75f);
        texte2.text = "Les protéger et assurer la croissance de leurs population devrait être adopté partout comme un élément d'une gestion carbonne responsable. Des propositions concrètes sont proposée par le programmes NUPES :";
        texte2.CrossFadeAlpha(1f, 1f, false);
        yield return new WaitForSeconds(0.75f);
        texte3.CrossFadeAlpha(1f, 1f, false);
        texte3.text = "Classer plus de 30% du territoire maritime français en aire maritime protégée, dont 10% en protection forte, pour en faire de véritables sanctuaires.";
        yield return new WaitForSeconds(0.75f);
        yield return new WaitForSeconds(0.75f);
        texte4.text = "Gérer durablement la ressource via la pêche artisanale et lutter contre les pratiques de pêche illégales ou destructrices.";
        texte4.CrossFadeAlpha(1f, 1f, false);

        yield return new WaitForSeconds(0.75f);
        texte1.CrossFadeAlpha(0f, 1f, false);
        texte2.CrossFadeAlpha(0f, 1f, false);
        texte3.CrossFadeAlpha(0f, 1f, false);
        texte4.CrossFadeAlpha(0f, 1f, false);

        quitter.gameObject.SetActive(true);
        rejouer.gameObject.SetActive(true);


    }
    // Start is called before the first frame update
    void Start()
    {
        texte1.color = Color.black;
        texte2.color = Color.black;
        texte3.color = Color.black;
        texte4.color = Color.black;


        rejouer.gameObject.SetActive(false);
        quitter.gameObject.SetActive(false);
        texte1.text = "À sa mort, votre baleine à récupérée 28 tonnes de CO2.";
        texte2.text = "En 1900, les baleines permettaient le stockage de plus de 10 millions de tonnes de carbonnes contre 2 millions seulement en 2020.";
        texte3.text = "Alors que le nombre de ces majestueux mamifères marins se stabilise enfin, offrant un espoir de croissance de leur population, elles se retrouvent à nouveau menacé par les activités humaines.";
        texte4.text = "Certaines nations continuent la chasse, d'autres jettent leurs innombrables déchets dans l'océan et toutes contribuent aux émissions de gaz à effet de serres.";
        StartCoroutine(AfficherTextes());
    }

    // Update is called once per frame
    void Update()
    {
        // rejouer.onClick(SceneManager.LoadScene(jeu));
        // quitter.onClick(quitter lol);
    }
}