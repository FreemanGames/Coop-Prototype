using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateChassis : MonoBehaviour {

    private float xRotate = 0.0f;
    public float speedH = 2.0f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        xRotate += speedH * Input.GetAxis("R_XAxis_1");
        transform.eulerAngles = new Vector3(0.0f, xRotate, 0.0f);
    }
}
