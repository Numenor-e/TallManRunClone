using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trambolin : MonoBehaviour
{
    public float Zmesafe;
    public float Ymesafe;

     Rigidbody Player;

    private void Start()
    {
        Player=GameObject.FindWithTag("Player").GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Player.AddForce(Vector3.up * Ymesafe);
            Player.AddForce(Vector3.forward * Zmesafe);
        }
    }
}
