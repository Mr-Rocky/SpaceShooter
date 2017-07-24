using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDown : MonoBehaviour {

    public float enemySpeed;
    public float countDown;

    private GameObject gameController;
    private GUIText timeText;

    void Start () {
        timeText = gameObject.GetComponent<GUIText>();
        gameController = GameObject.FindGameObjectWithTag("GameController");
        if (gameController == null)
            Debug.Log("Can't find GameController!");

        GameController gameControllerScript = gameController.GetComponent<GameController>();
        gameControllerScript.pauseSpawnTime = countDown;
        gameControllerScript.pauseSpawn = true;
	}
	
	void Update () {
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");

        foreach(GameObject enemy in enemys)
        {
            enemy.GetComponent<Rigidbody>().velocity *= (1 - Time.deltaTime);
            EvasiveManeuver evasive = enemy.GetComponent<EvasiveManeuver>();
            if (evasive != null)
            {
                evasive.enabled = false;
                enemy.GetComponent<WeaponController>().enabled = false;
            }
        }

        countDown -= Time.deltaTime;
        timeText.text = ((int)countDown).ToString();
    }

    void OnDestroy () {
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemys)
        {
            enemy.GetComponent<Rigidbody>().velocity = Vector3.forward * enemySpeed;
            EvasiveManeuver evasive = enemy.GetComponent<EvasiveManeuver>();
            if (evasive != null)
            {
                evasive.enabled = true;
                enemy.GetComponent<WeaponController>().enabled = true;
            }
        }
    }
}
