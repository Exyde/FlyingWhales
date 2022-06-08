using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TemporairCalquePolution : MonoBehaviour
{

    [SerializeField] public JaugeData _jaugeData;

    Image Filtre;
    int Opacity;

    Color FiltreDepart;
    Color FiltreArrivee;


    // Start is called before the first frame update
    void Start()
    {
        FiltreDepart = new Color32(93, 135, 108, 0);
        FiltreArrivee = new Color32(93, 135, 108, 90);

        Filtre = GetComponent<Image>();

        Filtre.color = FiltreDepart;
    }

    // Update is called once per frame
    void Update()
    {
        Filtre.color = Color.Lerp(FiltreDepart, FiltreArrivee, Mathf.InverseLerp(500, 2500, _jaugeData.JaugePollution));
    }
}
