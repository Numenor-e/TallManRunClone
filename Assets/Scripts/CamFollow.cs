using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TallManRun;


public class CamFollow : MonoBehaviour
{
    public Transform Player;

    private GameObject _pControl;

    private void Start()
    {
        _pControl = GameObject.Find("Player");

    }
    private void LateUpdate()
    {
        Follow();
    }

    private void Follow()
    {

        if (_pControl.GetComponent<PlayerControl>().isDead == false)
        {
            transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + 5, Player.transform.position.z - 10);
        }
    }
}
