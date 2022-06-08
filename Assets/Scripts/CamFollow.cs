using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform Player;

    GameObject playerControl;

    private void Start()
    {
        playerControl = GameObject.Find("Player");
        
    }
    private void LateUpdate()
    {
        Follow();
    }

    private void Follow()
    {
        if(playerControl.GetComponent<PlayerControl>().isDead==false)
        transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + 5, Player.transform.position.z - 10);
    }
}
