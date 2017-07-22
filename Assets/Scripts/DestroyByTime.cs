using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour {

    public float lifeTime;

	void Update () {
        Destroy(gameObject, lifeTime);
	}
}
