using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Trambolin : MonoBehaviour
{
    public float zMesafe;
    public float yMesafe;


    private Rigidbody _Player;

    private void Start()
    {
        _Player = GameObject.FindWithTag("Player").GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _Player.AddForce(Vector3.up * yMesafe);
            _Player.AddForce(Vector3.forward * zMesafe);

        }
    }

}