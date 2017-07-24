using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotSpawnController : MonoBehaviour {

    public GameObject shotSpawnCenter;

    private GameObject player;
    private PlayerControler playerController;
    private float lifeTime;
    private float maxLifeTime;
    
	void Start () {
        lifeTime = 5.0f;
        maxLifeTime = 15.0f;

        player = GameObject.FindWithTag("Player");
        if (player == null)
            Debug.Log("Can not find player!");
        else
        {
            playerController = player.GetComponent<PlayerControler>();
            playerController.AddSpawnLocation(gameObject.transform);
        }
    }
	
	void Update () {
        lifeTime -= Time.deltaTime;
        if (lifeTime < 0)
        {
            playerController.RemoveSpawnLocation(gameObject.transform);
            Destroy(gameObject);

            Transform centerGun = player.transform.Find("ShotSpawn_Center");
            if (centerGun == null)
            {
                GameObject centerSpawn = Instantiate(shotSpawnCenter, player.transform);
                centerSpawn.name = centerSpawn.name.Substring(0, centerSpawn.name.Length - 7);
                playerController.AddSpawnLocation(centerSpawn.transform);
            }
        }
	}

    public void increaseLifeTime(float value)
    {
        lifeTime = Mathf.Min(maxLifeTime, lifeTime + value);
    }
}
