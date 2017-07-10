using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldUvAnimation : MonoBehaviour {

    public GameObject Shield;
    public float Speed;

    private Material mMaterial;
    private float mTime;

    // Use this for initialization
    void Start()
    {
        mMaterial = Shield.GetComponent<Renderer>().material;

        mTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        mTime += Time.deltaTime * Speed;

        mMaterial.SetFloat("_Offset", Mathf.Repeat(mTime, 1.0f));
    }
}
