using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundry
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerControler : MonoBehaviour {

    public Rigidbody rigidBody;
    public float speed;
    public float tilt;
    public Boundry boundry;
    public GameObject shot;
    public List<Transform> shotSpawn;
    public float fireRate;
    public AudioSource fireSound; 

    private float nextFire;

    void Start ()
    {
        nextFire = 0.0f;
    }

    void Update ()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            foreach (Transform spawn in shotSpawn)
            {
                Instantiate(shot, spawn.position, spawn.rotation);
            }
            fireSound.Play();
        }
    }

	void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rigidBody.velocity = movement * speed;

        rigidBody.position = new Vector3(Mathf.Clamp(rigidBody.position.x, boundry.xMin, boundry.xMax), 0.0f, Mathf.Clamp(rigidBody.position.z, boundry.zMin, boundry.zMax));

        rigidBody.rotation = Quaternion.Euler(0.0f, 0.0f, rigidBody.velocity.x * -tilt);
    }

    public void AddSpawnLocation(Transform newSpawn)
    {
        shotSpawn.Add(newSpawn);
    }

    public void RemoveSpawnLocation(Transform oldSpawn)
    {
        shotSpawn.Remove(oldSpawn);
    }
}
