using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSlowDown : MonoBehaviour {

    public GameObject powerUpElement;

    private GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        if (player == null)
            Debug.Log("Can not find player!");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            Instantiate(powerUpElement);
        }
    }
}
