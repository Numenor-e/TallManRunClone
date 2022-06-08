using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Gates : MonoBehaviour
{
    float[] Degerler = { 0.1f, 0.2f, 0.3f, -0.1f, -0.2f, -0.3f };
    public float KatSayi;

    [SerializeField] GameObject Gate;
    [SerializeField] TextMeshProUGUI SayiText;

    private Renderer renderer;

    public Material Yesil;
    public Material Kirmizi;
    private void Start()
    {
        renderer = Gate.GetComponent<Renderer>();

        KatSayi = Degerler[UnityEngine.Random.Range(0, Degerler.Length)];


        if (KatSayi < 0)
        {
            renderer.material = Kirmizi;
        }
        else
        {
            renderer.material = Yesil;
        }

        SayiText.text = (KatSayi * 100).ToString();


        float Belirleme = Random.Range(-1,2);
        if (Belirleme != 0)
        {
            gameObject.tag = "Widht";
            if(KatSayi > 0)
            {
                SayiText.text ="9"+ (KatSayi * 100).ToString();
            }
            else
            {
                SayiText.text ="8"+(KatSayi*100).ToString();
            }
        }
        else
        {
            gameObject.tag = "Height";
            if (KatSayi > 0)
            {
                SayiText.text = "7" + (KatSayi * 100).ToString();
            }
            else
            {
                SayiText.text = "6" + (KatSayi * 100).ToString();
            }
        }
    }
}
