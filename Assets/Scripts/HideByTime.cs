using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideByTime : MonoBehaviour {

    public float activeTime;

    private float timePassed;
    
	void OnEnable () {
        timePassed = 0;
	}
	
	void Update () {
        timePassed += Time.deltaTime;
        if (timePassed > activeTime)
            gameObject.SetActive(false);
	}
}
