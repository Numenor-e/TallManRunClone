using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Gates : MonoBehaviour
{
    public float kSayi;

    public SizeValues Boyut;
    public List<float> boyutDegerleri = new List<float> { 0.1f, 0.2f, 0.3f };

    [SerializeField] GameObject Gate;
    [SerializeField] TextMeshProUGUI SayiText;

    private Renderer _Renderer;

    public Material Yesil;
    public Material Kirmizi;
    private void Start()
    {
        _Renderer = Gate.GetComponent<Renderer>();

        kSayi = boyutDegerleri[UnityEngine.Random.Range(0, boyutDegerleri.Count)];
        Baslarken();



    }

    void Baslarken()
    {

        if (Boyut == SizeValues.GENISLET)
        {
            this.gameObject.tag = "Widht";

        }
        else if (Boyut == SizeValues.DARALT)
        {
            this.gameObject.tag = "Widht";
            kSayi = kSayi * -1;
        }
        else if (Boyut == SizeValues.UZAT)
        {
            this.gameObject.tag = "Height";
        }
        else if (Boyut == SizeValues.KISALT)
        {
            this.gameObject.tag = "Height";
            kSayi = kSayi * -1;
        }

        SayiText.text = (kSayi * 100).ToString();

        if (kSayi < 0)
        {
            _Renderer.material = Kirmizi;
        }
        else
        {
            _Renderer.material = Yesil;
        }
    }


    public enum SizeValues
    {
        GENISLET,
        DARALT,
        UZAT,
        KISALT
    }
}