using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public bool isDead;

    [SerializeField] GameObject Head;
    [SerializeField] GameObject Body;


    void FixedUpdate()
    {
        Kontrol();
    }

    private void Kontrol()
    {
        if (isDead==false)
        {
            if (Input.GetKey(KeyCode.W))
            {
                gameObject.transform.Translate(0, 0, 0.1f);
            }
            if (Input.GetKey(KeyCode.A))
            {
                gameObject.transform.Translate(-0.1f, 0, 0.1f);
            }
            if (Input.GetKey(KeyCode.D))
            {
                gameObject.transform.Translate(0.1f, 0, 0.1f);
            }

          
        }

        gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);

        if (isDead == false)
        {
            if (Body.transform.localScale.x <= 0 || Body.transform.localScale.y <= 0)
            {
                isDead = true;
                Destroy(Body.gameObject);
                Head.GetComponent<Rigidbody>().useGravity = true;
                gameObject.GetComponent<Collider>().isTrigger = false;
                
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isDead==false)
        {

            if (other.gameObject.tag == "Widht")
            {
                Gates gate = other.GetComponentInParent<Gates>();

                Body.transform.localScale += new Vector3(gate.KatSayi, 0, gate.KatSayi);
                Destroy(other.gameObject);
            }
            if (other.gameObject.tag == "Height")
            {
                Gates gate = other.GetComponentInParent<Gates>();

                Body.transform.localScale += new Vector3(0, gate.KatSayi, 0);
                Body.transform.localPosition += new Vector3(0, gate.KatSayi, 0);
                Head.transform.localPosition += new Vector3(0, gate.KatSayi + gate.KatSayi, 0);
                Destroy(other.gameObject);
            }

            if (other.gameObject.tag == "SolWidht")
            {
                DoubleGate doubleGate = other.GetComponentInParent<DoubleGate>();

                Body.transform.localScale += new Vector3(doubleGate.KatSayi1, 0, doubleGate.KatSayi1);
                other.GetComponentInParent<DoubleGate>().Destroy();
            }
            if (other.gameObject.tag == "SagWidht")
            {
                DoubleGate doubleGate = other.GetComponentInParent<DoubleGate>();

                Body.transform.localScale += new Vector3(doubleGate.KatSayi2, 0, doubleGate.KatSayi2);
                other.GetComponentInParent<DoubleGate>().Destroy();
            }
            if (other.gameObject.tag == "SolHeight")
            {
                DoubleGate doubleGate = other.GetComponentInParent<DoubleGate>();

                Body.transform.localScale += new Vector3(0, doubleGate.KatSayi1, 0);
                Body.transform.localPosition += new Vector3(0, doubleGate.KatSayi1, 0);
                Head.transform.localPosition += new Vector3(0, doubleGate.KatSayi1 + doubleGate.KatSayi1, 0);
                other.GetComponentInParent<DoubleGate>().Destroy();
            }
            if (other.gameObject.tag == "SagHeight")
            {
                DoubleGate doubleGate = other.GetComponentInParent<DoubleGate>();

                Body.transform.localScale += new Vector3(0, doubleGate.KatSayi2, 0);
                Body.transform.localPosition += new Vector3(0, doubleGate.KatSayi2, 0);
                Head.transform.localPosition += new Vector3(0, doubleGate.KatSayi2 + doubleGate.KatSayi2, 0);
                other.GetComponentInParent<DoubleGate>().Destroy();
            }
        }
    }
   
}
