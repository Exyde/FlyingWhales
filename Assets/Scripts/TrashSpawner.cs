using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
    public List<GameObject> _trashPrefabs;

    public List<Transform> _trashSpawners;
    private JaugeSystem _jaugeSystem;
    int _pollutionPercent;


    private void Awake()
    {
        _jaugeSystem = FindObjectOfType<JaugeSystem>();
    }


    private void Update()
    {
        _pollutionPercent = _jaugeSystem.JaugePollution / 10;
    }
    
}
