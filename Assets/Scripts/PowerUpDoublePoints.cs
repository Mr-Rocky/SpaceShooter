using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpDoublePoints : MonoBehaviour {

    public GameObject powerUpElement;

    private GameObject gameController;
    
	void Start () {
        gameController = GameObject.FindWithTag("GameController");
        if (gameController == null)
        {
            Debug.Log("Cannot find gameController!");
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            Instantiate(powerUpElement, gameController.transform);
        }
    }
}
