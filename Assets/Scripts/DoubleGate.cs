using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoubleGate : MonoBehaviour
{
    private float[] _Degerler = { 0.1f, 0.2f, 0.3f, -0.1f, -0.2f, -0.3f };

    public float kSayi1;
    public float kSayi2;

    public Material Yesil;
    public Material kirmizi;


    [SerializeField] private GameObject _Gate1;
    [SerializeField] private TextMeshProUGUI _SayiText1;

    [SerializeField] private GameObject _Gate2;
    [SerializeField] private TextMeshProUGUI _SayiText2;

    private Renderer _Renderer;

    private void Start()
    {

        _Gate1Kontrol();
        _Gate2Kontrol();
        YonBelirleme();

    }

    void YonBelirleme()
    {
        float Belirleme = Random.Range(0, 1);
        if (Belirleme != 0)
        {
            _Gate1.gameObject.tag = "SolWidht";
            _Gate2.gameObject.tag = "SagHeight";
        }
        else
        {
            _Gate1.gameObject.tag = "SolHeight";
            _Gate2.gameObject.tag = "SagWidht";
        }


    }

    void _Gate1Kontrol()
    {
        _Renderer = _Gate1.GetComponent<Renderer>();

        kSayi1 = _Degerler[Random.Range(0, _Degerler.Length)];


        if (kSayi1 < 0)
        {
            _Renderer.material = kirmizi;
        }
        else
        {
            _Renderer.material = Yesil;
        }

        _SayiText1.text = (kSayi1 * 100).ToString();
    }

    void _Gate2Kontrol()
    {
        _Renderer = _Gate2.GetComponent<Renderer>();

        kSayi2 = _Degerler[Random.Range(0, _Degerler.Length)];


        if (kSayi2 < 0)
        {
            _Renderer.material = kirmizi;
        }
        else
        {
            _Renderer.material = Yesil;
        }

        _SayiText2.text = (kSayi2 * 100).ToString();
    }

    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}