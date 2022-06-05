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

    public int _transitionDuration;
    public int _localPollution;

    // public AudioClip music1;
    // public AudioClip music2;
    // public AudioClip music3;
    // public AudioClip music4;
    // public AudioClip music5;
    JaugeSystem _jaugeSystem;

    IEnumerator volumeTransition(AudioSource track1, AudioSource track2)
    {
        Debug.Log("Lerping sound");
        for (float i = 0; i <= 1; i += 0.1f)
        {
            Debug.Log("i : "  + i);
            track1.volume -= 0.1f;
            track2.volume += 0.1f;
            yield return new WaitForSeconds(_transitionDuration / 10);
        }
    }

    void Start()
    {
        // source1 = GetComponent<AudioSource>();
        // source2 = GetComponent<AudioSource>();
        // source3 = GetComponent<AudioSource>();
        // source4 = GetComponent<AudioSource>();
        // source5 = GetComponent<AudioSource>();

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

        _localPollution = _jaugeSystem.JaugePollution;

        if (_localPollution >= 300)
        {
            StartCoroutine(volumeTransition(source1, source2));
        }

        if (_localPollution >= 500)
        {
            StartCoroutine(volumeTransition(source2, source3));
        }

        if (_localPollution >= 700)
        {
            StartCoroutine(volumeTransition(source3, source4));
        }

        if (_localPollution >= 900)
        {
            StartCoroutine(volumeTransition(source4, source5));
        }
    }


}
