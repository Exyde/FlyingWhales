using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JaugeSystem : MonoBehaviour
{
    //Valeur � retrancher periodiquement

    [Header("VALEUR PERIODIQUE")]

    public int Faim;

    public int Apnee;

    public int Respiration;

    public int Pollution;

    //Valeur � retrancher sur evenement

    [Header("VALEUR SUR TRIGGER")]

    public int PoissonImpactNourriture;

    public int DechetImpactNourriture;

    public int DechetImpactRespiration;

    public int DechetImpactPollution;

    //Jauge

    int JaugeNourriture = 800;

    int JaugeRespiration = 1000;

    int JaugePollution = 0;

    //Bool�en Etat du Jeu

    bool ALaSurface;


    void MangerPoisson()
    {
        //IMPACT JAUGE

        JaugeNourriture += PoissonImpactNourriture;

        //CLAMPING TIME

        JaugeNourriture = Mathf.Clamp(JaugeNourriture, -1000, 1000);
    }

    void MangerDechet()
    {
        //IMPACT JAUGE 

        JaugeNourriture += DechetImpactNourriture;
        JaugeRespiration -= DechetImpactRespiration;
        JaugePollution += DechetImpactPollution;

        //CLAMPING TIME

        JaugeNourriture = Mathf.Clamp(JaugeNourriture, -1000, 1000);
        JaugeRespiration = Mathf.Clamp(JaugeRespiration, -1000, 1000);

    }

    public void ActualisationJauge()
    {
        //NOURRITURE

        JaugeNourriture -= Faim;

        //RESPIRATION 

        if (transform.position.y >= 50)
        {
            JaugeRespiration -= Apnee;
        }
        else
        {
            JaugeRespiration += Respiration;
        }

        //POLLUTION

        JaugePollution -= Pollution;

        //CLAMPING TIME

        JaugeNourriture = Mathf.Clamp(JaugeNourriture, -1000, 1000);

        JaugeRespiration = Mathf.Clamp(JaugeRespiration, -1000, 1000);

        //GAME OVER

        if (JaugeRespiration <= 0 || JaugeNourriture <= 0)
        {
            GameManager._instance.EndGame();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Garbage")
        {
            MangerDechet();
            Destroy(other.gameObject);
            Debug.Log("Destroying Trash");
        }

        if (other.tag == "Fish")
        {
            MangerPoisson();
            Destroy(other.gameObject);
            Debug.Log("Destroying Fish");

        }

    }

}
