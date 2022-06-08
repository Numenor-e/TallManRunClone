using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


    public class Height : MonoBehaviour
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

        }
    }