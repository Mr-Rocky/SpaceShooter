using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBullets : MonoBehaviour {

    public GameObject shotSpawnCenter;
    public GameObject shotSpawnLeft;
    public GameObject shotSpawnRight;
    public GameObject player;
    public int increaseTime;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        if (player == null)
            Debug.Log("Cannot find player!");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);

            Transform centerGun = player.transform.Find("ShotSpawn_Center");
            Transform leftGun = player.transform.Find("ShotSpawn_Left");
            Transform rightGun = player.transform.Find("ShotSpawn_Right");

            if (leftGun != null)
                leftGun.GetComponent<ShotSpawnController>().increaseLifeTime(increaseTime);
            else
            {
                GameObject leftSpawn = Instantiate(shotSpawnLeft, player.transform);
                leftSpawn.name = leftSpawn.name.Substring(0, leftSpawn.name.Length - 7);
            }

            if (rightGun != null)
                rightGun.GetComponent<ShotSpawnController>().increaseLifeTime(increaseTime);
            else
            {
                GameObject rightSpawn = Instantiate(shotSpawnRight, player.transform);
                rightSpawn.name = rightSpawn.name.Substring(0, rightSpawn.name.Length - 7);
            }

            if (leftGun != null && rightGun != null)
            {
                if (centerGun == null)
                {
                    GameObject centerSpawn = Instantiate(shotSpawnCenter, player.transform);
                    centerSpawn.name = centerSpawn.name.Substring(0, centerSpawn.name.Length - 7);
                    player.GetComponent<PlayerControler>().AddSpawnLocation(centerSpawn.transform);
                }
            }
            else
            {
                player.GetComponent<PlayerControler>().RemoveSpawnLocation(centerGun);
                Destroy(centerGun.gameObject);
            }
        }
    }
}
