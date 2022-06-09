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
                if (gameObject.transform.position.x > -4)
                {
                    gameObject.transform.Translate(-0.1f, 0, 0.1f);
                }
                else
                {
                    gameObject.transform.Translate(0, 0, 0.1f);

                }
            }
            if (Input.GetKey(KeyCode.D))
            {
                if (gameObject.transform.position.x <4)
                {
                    gameObject.transform.Translate(0.1f, 0, 0.1f);
                }
                else
                {
                    gameObject.transform.Translate(0, 0, 0.1f);

                }
            }

        }

        gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
        if (isDead == false)
        {
            Head.transform.localPosition = new Vector3(Body.transform.localPosition.x, (Body.transform.localScale.y * 2f), Body.transform.localPosition.x);
        }
        if (isDead == false)
        {
            if (Body.transform.localScale.x <= 0.1f|| Body.transform.localScale.y <= 0.3f)
            {
                isDead = true;
                Destroy(Body.gameObject);
                Head.GetComponent<Rigidbody>().useGravity = true;
                Head.GetComponent<Collider>().isTrigger = false;
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

            ÝkiliGecit();

            if(other.gameObject.tag == "Bariyer")
            {
                BariyerEnter();
            }

            
            
        }

        void BariyerEnter()
        {
            if (Body.gameObject.transform.localScale.y > 0.8f)
            {
                Body.gameObject.transform.localScale -= new Vector3(0, 0.1f, 0);
                //Head.gameObject.transform.localPosition -= new Vector3(0, 0.2f, 0);
                Body.gameObject.transform.localPosition -= new Vector3(0,0.1f, 0);
            }
            else
            {
                Body.gameObject.transform.localScale -= new Vector3(0.1f, 0, 0.1f);
            }
        }

        void ÝkiliGecit()
        {
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
