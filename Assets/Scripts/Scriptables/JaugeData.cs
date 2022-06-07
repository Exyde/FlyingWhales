using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu (fileName = "Jauge Data", menuName = "SO/Jauge Data")]
public class JaugeData : ScriptableObject
{
    #region Jauge Data, System...
    //Valeur a retrancher periodiquement

    [Header("VALEUR PERIODIQUE")]

    public int Faim;

    public int Apnee;

    public int Respiration;

    public int Pollution;

    //Valeur a retrancher sur evenement

    [Header("VALEUR SUR TRIGGER")]

    public int PoissonImpactNourriture;

    public int DechetImpactNourriture;

    public int DechetImpactRespiration;

    public int DechetImpactPollution;

    //Jauge

    [Header("Jauge")]
    public int JaugeNourriture = 800;

    public int JaugeRespiration = 1000;

    public int JaugePollution = 0;
    #endregion
}
