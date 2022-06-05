using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource source1;
    public AudioSource source2;
    public AudioSource source3;
    public AudioSource source4;
    public AudioSource source5;

    public AudioClip music1;
    public AudioClip music2;
    public AudioClip music3;
    public AudioClip music4;
    public AudioClip music5;
    JaugeSystem _jaugeSystem;

    IEnumerator volumeTransition(AudioSource track1, AudioSource track2)
    {
        for (float i = 0; i == 10; i += 1)
        {
            track1.volume -= 1;
            track2.volume += 1;
            yield return new WaitForSeconds(0.2f);
        }
    }

    void Start()
    {
        source1 = GetComponent<AudioSource>();
        source2 = GetComponent<AudioSource>();
        source3 = GetComponent<AudioSource>();
        source4 = GetComponent<AudioSource>();
        source5 = GetComponent<AudioSource>();

        _jaugeSystem = GameObject.FindObjectOfType<JaugeSystem>();
        source2.volume = 0;
        source3.volume = 0;
        source4.volume = 0;
        source5.volume = 0;
        source1.Play();
        source2.Play();
        source3.Play();
        source4.Play();
        source5.Play();
        
    }

    void Update()
    { 

        if (_jaugeSystem.Pollution >= 30)
        {
            StartCoroutine(volumeTransition(source1, source2));
        }

        if (_jaugeSystem.Pollution >= 50)
        {
            StartCoroutine(volumeTransition(source2, source3));
        }

        if (_jaugeSystem.Pollution >= 70)
        {
            StartCoroutine(volumeTransition(source3, source4));
        }

        if (_jaugeSystem.Pollution >= 90)
        {
            StartCoroutine(volumeTransition(source4, source5));
        }
    }


}
