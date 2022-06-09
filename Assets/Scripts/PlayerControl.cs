using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TallManRun
{
    public class PlayerControl : MonoBehaviour
    {
        public bool isDead;
        bool isFinish;

        [SerializeField] private GameObject m_Head;
        [SerializeField] private GameObject m_Body;


        void FixedUpdate()
        {
            Kontrol();
        }

        private void Kontrol()
        {
            if (isDead == false)
            {
                if (isFinish == false)
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
                        if (gameObject.transform.position.x < 4)
                        {
                            gameObject.transform.Translate(0.1f, 0, 0.1f);
                        }
                        else
                        {
                            gameObject.transform.Translate(0, 0, 0.1f);

                        }
                    }
                }
                else
                {
                    gameObject.transform.Translate(0, 0, 0.1f);
                }

            }

            gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
            if (isDead == false)
            {
                m_Head.transform.localPosition = new Vector3(m_Body.transform.localPosition.x, (m_Body.transform.localScale.y * 2f), m_Body.transform.localPosition.x);
            }
            if (isDead == false)
            {
                if (m_Body.transform.localScale.x <= 0.1f || m_Body.transform.localScale.y <= 0.3f)
                {
                    StartCoroutine(Dead());

                    isDead = true;
                    Destroy(m_Body.gameObject);
                    m_Head.GetComponent<Rigidbody>().useGravity = true;
                    m_Head.GetComponent<Collider>().isTrigger = false;
                    gameObject.GetComponent<Collider>().isTrigger = false;


                }
            }

            if (isDead == false && m_Body.transform.position.y < -3)
            {
                StartCoroutine(Dead());
                isDead = true;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (isDead == false)
            {

                if (other.gameObject.tag == "Widht")
                {
                    Gates gate = other.GetComponentInParent<Gates>();

                    m_Body.transform.localScale += new Vector3(gate.kSayi, 0, gate.kSayi);
                    Destroy(other.gameObject);
                }
                else if (other.gameObject.tag == "Height")
                {
                    Gates gate = other.GetComponentInParent<Gates>();

                    m_Body.transform.localScale += new Vector3(0, gate.kSayi, 0);
                    m_Body.transform.localPosition += new Vector3(0, gate.kSayi, 0);
                    m_Head.transform.localPosition += new Vector3(0, gate.kSayi + gate.kSayi, 0);
                    Destroy(other.gameObject);
                }

                else if (other.gameObject.tag == "SolWidht")
                {
                    DoubleGate doubleGate = other.GetComponentInParent<DoubleGate>();

                    m_Body.transform.localScale += new Vector3(doubleGate.kSayi1, 0, doubleGate.kSayi1);
                    other.GetComponentInParent<DoubleGate>().Destroy();
                }
                else if (other.gameObject.tag == "SagWidht")
                {
                    DoubleGate doubleGate = other.GetComponentInParent<DoubleGate>();

                    m_Body.transform.localScale += new Vector3(doubleGate.kSayi2, 0, doubleGate.kSayi2);
                    other.GetComponentInParent<DoubleGate>().Destroy();
                }
                else if (other.gameObject.tag == "SolHeight")
                {
                    DoubleGate doubleGate = other.GetComponentInParent<DoubleGate>();

                    m_Body.transform.localScale += new Vector3(0, doubleGate.kSayi1, 0);
                    m_Body.transform.localPosition += new Vector3(0, doubleGate.kSayi1, 0);
                    m_Head.transform.localPosition += new Vector3(0, doubleGate.kSayi1 + doubleGate.kSayi1, 0);
                    other.GetComponentInParent<DoubleGate>().Destroy();
                }
                else if (other.gameObject.tag == "SagHeight")
                {
                    DoubleGate doubleGate = other.GetComponentInParent<DoubleGate>();

                    m_Body.transform.localScale += new Vector3(0, doubleGate.kSayi2, 0);
                    m_Body.transform.localPosition += new Vector3(0, doubleGate.kSayi2, 0);
                    m_Head.transform.localPosition += new Vector3(0, doubleGate.kSayi2 + doubleGate.kSayi2, 0);
                    other.GetComponentInParent<DoubleGate>().Destroy();
                }
                else if (other.gameObject.tag == "Bariyer")
                {
                    BariyerEnter();
                }

                else if (other.gameObject.tag == "Plaka")
                {
                    isFinish = true;
                }





            }


        }
        void BariyerEnter()
        {
            if (m_Body.gameObject.transform.localScale.y > 0.8f)
            {
                m_Body.gameObject.transform.localScale -= new Vector3(0, 0.1f, 0);
                m_Body.gameObject.transform.localPosition -= new Vector3(0, 0.1f, 0);
            }
            else
            {
                m_Body.gameObject.transform.localScale -= new Vector3(0.1f, 0, 0.1f);
            }
        }

        IEnumerator Dead()
        {
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene(0);


        }




    }
}