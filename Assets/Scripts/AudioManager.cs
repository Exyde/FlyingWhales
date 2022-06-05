using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    JaugeSystem _jaugeSystem;

    void Start()
    {
        _jaugeSystem = GameObject.FindObjectOfType<JaugeSystem>();
    }

}
