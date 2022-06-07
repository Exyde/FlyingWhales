using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JaugeSystem : MonoBehaviour
{
    //#region Jauge Data, System...
    ////Valeur � retrancher periodiquement

    //[Header("VALEUR PERIODIQUE")]

    //public int Faim;

    //public int Apnee;

    //public int Respiration;

    //public int Pollution;

    ////Valeur � retrancher sur evenement

    //[Header("VALEUR SUR TRIGGER")]

    //public int PoissonImpactNourriture;

    //public int DechetImpactNourriture;

    //public int DechetImpactRespiration;

    //public int DechetImpactPollution;

    ////Jauge

    //[Header ("Jauge Debug")]
    //public int JaugeNourriture = 1000;

    //public int JaugeRespiration = 1000;

    //public int JaugePollution = 0;
    //#endregion

    [SerializeField] public JaugeData _jaugeData;

    //Bool�en Etat du Jeu

    bool ALaSurface;

     
    /// UI
    [Header ("UI Elements")]
    [SerializeField] Image _imgOxygeneJauge;
    [SerializeField] Image _imgEatingJauge;


    private void Start()
    {
        _jaugeData.SetupJauge();
    }

    void MangerPoisson()
    {
        //IMPACT JAUGE

        _jaugeData.JaugeNourriture += _jaugeData.PoissonImpactNourriture;

        //CLAMPING TIME

        _jaugeData.JaugeNourriture = Mathf.Clamp(_jaugeData.JaugeNourriture, -1000, 1000);
    }

    void MangerDechet()
    {
        //IMPACT JAUGE 

       _jaugeData.JaugeNourriture += _jaugeData.DechetImpactNourriture;
       _jaugeData.JaugeRespiration -= _jaugeData.DechetImpactRespiration;
       _jaugeData.JaugePollution += _jaugeData.DechetImpactPollution;

        //CLAMPING TIME

        _jaugeData.JaugeNourriture = Mathf.Clamp(_jaugeData.JaugeNourriture, -1000, 1000);
        _jaugeData.JaugeRespiration = Mathf.Clamp(_jaugeData.JaugeRespiration, -1000, 1000);

    }

    public void ActualisationJauge()
    {
        //NOURRITURE

        _jaugeData.JaugeNourriture -= _jaugeData.Faim;

        //RESPIRATION 

        if (transform.position.y <= 55)
        {
            _jaugeData.JaugeRespiration -= _jaugeData.Apnee;
        }
        else
        {
            _jaugeData.JaugeRespiration += _jaugeData.Respiration;
        }

        //POLLUTION

        _jaugeData.JaugePollution += _jaugeData.Pollution;

        //CLAMPING TIME

        _jaugeData.JaugeNourriture = Mathf.Clamp(_jaugeData.JaugeNourriture, -1000, 1000);

        _jaugeData.JaugeRespiration = Mathf.Clamp(_jaugeData.JaugeRespiration, -1000, 1000);

        //UI

        float oxygeneFill = (float)_jaugeData.JaugeRespiration / 1000.0f;
        float eatingFill = (float)_jaugeData.JaugeNourriture / 1000.0f;
        _imgEatingJauge.fillAmount = eatingFill;
        _imgOxygeneJauge.fillAmount = oxygeneFill;

        // Debug.Log("Oxygene : " + oxygeneFill);
        // Debug.Log("Nourriture : " + eatingFill);

        //Post Process
        PostProcessingManager._instance.UpdateWaterColor();

        //GAME OVER

        if (_jaugeData.JaugeRespiration <= 0 || _jaugeData.JaugeNourriture <= 0)
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
            //Debug.Log("Destroying Trash");
        }

        if (other.tag == "Fish")
        {
            MangerPoisson();
            Destroy(other.gameObject);
            //Debug.Log("Destroying Fish");
        }
    }
}
