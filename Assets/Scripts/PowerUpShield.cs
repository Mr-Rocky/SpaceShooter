﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpShield : MonoBehaviour {
    
    public GameObject powerUpElement;
    public int increaseValue;

    private GameObject player;

    void Start () {
		player = GameObject.FindWithTag("Player");
        if (player == null)
            Debug.Log("Can not find player!");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            Transform shield = player.transform.Find("Shield(Clone)");
            if (shield != null)
                shield.gameObject.GetComponent<ShieldController>().increaseShield(increaseValue);
            else
                Instantiate(powerUpElement, player.transform);
        }
    }
}
