using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Gates : MonoBehaviour
{
    public float KatSayi;

    public SizeValues Boyut;
    public List<float> BoyutDegerleri =new List<float> {0.1f,0.2f,0.3f};

    [SerializeField] GameObject Gate;
    [SerializeField] TextMeshProUGUI SayiText;

    private Renderer renderer;

    public Material Yesil;
    public Material Kirmizi;
    private void Start()
    {
        renderer = Gate.GetComponent<Renderer>();

        KatSayi = BoyutDegerleri[UnityEngine.Random.Range(0, BoyutDegerleri.Count)];


       
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
            KatSayi = KatSayi * -1;
        }
        else if (Boyut == SizeValues.UZAT)
        {
            this.gameObject.tag = "Height";
        }
        else if (Boyut == SizeValues.KISALT)
        {
            this.gameObject.tag = "Height";
            KatSayi = KatSayi * -1;
        }

        SayiText.text = (KatSayi * 100).ToString();

        if (KatSayi < 0)
        {
            renderer.material = Kirmizi;
        }
        else
        {
            renderer.material = Yesil;
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
