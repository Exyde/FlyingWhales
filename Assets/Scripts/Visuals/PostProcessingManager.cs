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
    [SerializeField] DepthOfField _DoF;
    [SerializeField] ChromaticAberration _abberation;
    [SerializeField] Tonemapping _tonemapping;
    [SerializeField] LensDistortion _lensDistorsion;
    [SerializeField] ColorAdjustments _colorAdjustements;
    [SerializeField] ColorCurves _colorCurves;

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
        _profile.TryGet(out _DoF);
        _profile.TryGet(out _abberation);
        _profile.TryGet(out _tonemapping);
        _profile.TryGet(out _lensDistorsion);
        _profile.TryGet(out _colorAdjustements);
        _profile.TryGet(out _colorCurves);
    }

    private void Update()
    {
        
    }

    public void UpdateWaterColor()
    {
        float _pollutionPercent = _jaugeData.JaugePollution / 10.0f;
        float _pollution01 = _jaugeData.JaugePollution / 1000.0f;

        Debug.Log(_pollution01);
    }



}
