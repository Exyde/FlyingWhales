using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Small component for applying multiple materials on a Sprite Renderer, since it's not exposed by default.
///</summary>
[RequireComponent (typeof(SpriteRenderer))]
public class CustomSpriteRendererMaterials : MonoBehaviour
{
    [SerializeField] bool _overrideRendererMaterials;
    [SerializeField] bool _enableShadows;
    [SerializeField] Material[] _materials;
    

    void OnValidate(){
       ProcessUserSettings();
    }
    

    void Awake(){
       ProcessUserSettings();
    }

    void ProcessUserSettings(){

      SpriteRenderer _renderer = GetComponent<SpriteRenderer>();
       if(_overrideRendererMaterials) _renderer.materials = _materials;
       _renderer.shadowCastingMode = _enableShadows ? UnityEngine.Rendering.ShadowCastingMode.On : UnityEngine.Rendering.ShadowCastingMode.Off;

    }
}
