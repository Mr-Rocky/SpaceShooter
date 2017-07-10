using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    public GameObject powerUpBox;
    public GameObject powerUpElement;
    public GameObject player;

	void Start () {
		player = GameObject.FindWithTag("Player");
        if (player == null)
            Debug.Log("Cannot find player!");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(powerUpBox);
            // TODO: chec if alredy exists (remove duplicating power ups)
            Instantiate(powerUpElement, player.transform);
        }
    }
}
