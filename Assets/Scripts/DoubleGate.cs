using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoubleGate : MonoBehaviour
{
    float[] Degerler = { 0.1f, 0.2f, 0.3f, -0.1f, -0.2f, -0.3f };
    public float KatSayi1;
    public float KatSayi2;

    public Material Yesil;
    public Material kirmizi;


    [SerializeField] GameObject Gate1;
    [SerializeField] TextMeshProUGUI SayiText1;

    [SerializeField] GameObject Gate2;
    [SerializeField] TextMeshProUGUI SayiText2;

    private Renderer renderer;

    private void Start()
    {

        Gate1Kontrol();
        Gate2Kontrol();
        YonBelirleme();
       
    }

    void YonBelirleme()
    {
        float Belirleme = Random.Range(0,1);
        if (Belirleme != 0)
        {
            Gate1.gameObject.tag = "SolWidht";
            Gate2.gameObject.tag = "SagHeight";
        }
        else
        {
            Gate1.gameObject.tag = "SolHeight";
            Gate2.gameObject.tag = "SagWidht";
        }

        
    }

    void Gate1Kontrol()
    {
        renderer = Gate1.GetComponent<Renderer>();

        KatSayi1 = Degerler[Random.Range(0, Degerler.Length)];


        if (KatSayi1 < 0)
        {
            renderer.material = kirmizi;
        }
        else
        {
            renderer.material = Yesil;
        }

        SayiText1.text = (KatSayi1 * 100).ToString();
    }

    void Gate2Kontrol()
    {
        renderer = Gate2.GetComponent<Renderer>();

        KatSayi2 = Degerler[Random.Range(0, Degerler.Length)];


        if (KatSayi2 < 0)
        {
            renderer.material = kirmizi;
        }
        else
        {
            renderer.material = Yesil;
        }

        SayiText2.text = (KatSayi2 * 100).ToString();
    }

    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}
