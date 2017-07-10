using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour {

    public GameObject shield;
    public float blinkSpeed;

    private Material shieldMaterial;
    private int allowedHits;
    private bool blink;
    private bool fullOn;
    private float timePass;
	
	void Start () {
        shieldMaterial = shield.GetComponent<Renderer>().material;

        allowedHits = 3;
        blink = false;
        fullOn = true;
        timePass = 0.0f;
	}
	
	
	void Update () {
        if (blink)
        {
            if (allowedHits < 1)
            {
                Destroy(shield);
            }
            else
            {
                timePass += Time.deltaTime;
                if (timePass > blinkSpeed)
                {
                    if (fullOn)
                    {
                        fullOn = false;
                        shieldMaterial.SetFloat("_Strength", 1.0f);
                        timePass = 0.0f;
                    }
                    else
                    {
                        fullOn = true;
                        shieldMaterial.SetFloat("_Strength", 1.5f);
                        timePass = 0.0f;
                    }
                }
            }
        }
	}

    public void increaseShield(int value)
    {
        allowedHits += value;
        blink = false;
    }

    public void gotHitted()
    {
        allowedHits--;
        if (allowedHits == 1)
            blink = true;
    }

}
