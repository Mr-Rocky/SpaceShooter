using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

    public AudioSource audioSorce;
    public Transform shotSpawn;
    public GameObject shot;
    public float fireRate;
    public float delay;

	void Start () {
        InvokeRepeating("Fire", delay, fireRate);
	}

    void Fire ()
    {
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        audioSorce.Play();
    }
}
