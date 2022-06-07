using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;



public class PostProcessingManager : MonoBehaviour
{
    public static PostProcessingManager _instance;

    [SerializeField] JaugeData _jaugeData;

    [SerializeField] Camera _cam;

    [SerializeField] Volume _volume;

    [SerializeField] VolumeProfile _profile;

    [Header("Post Processing Components")]
    [SerializeField] Bloom _bloom;
    [SerializeField] Vignette _vignette;
    //[SerializeField] Bloom _bloom;


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        _instance = this;
    }

    private void Start()
    {
        _volume = _cam.GetComponent<Volume>();
        _profile = _volume.profile;

        _profile.TryGet(out _bloom);
        _profile.TryGet(out _vignette);
        //_profile.TryGet(out _bloom);

    }

    private void Update()
    {
        
    }

    public void UpdateWaterColor()
    {

    }



}
