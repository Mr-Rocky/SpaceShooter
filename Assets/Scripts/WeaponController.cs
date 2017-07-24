using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

    public AudioSource audioSorce;
    public Transform shotSpawn;
    public GameObject shot;
    public float fireRate;
    public float delay;

    private float timePassed;
    private float fireLimit;

	void Start () {
        //InvokeRepeating("Fire", delay, fireRate);
        timePassed = 0.0f;
        fireLimit = delay + fireRate;
    }

    void Update()
    {
        timePassed += Time.deltaTime;
        if (timePassed > fireLimit)
        {
            Fire();
            timePassed = delay;
        }
    }

    void Fire ()
    {
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        audioSorce.Play();
    }
}
