﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScriptSoldier : MonoBehaviour
{
	// speed the camera will rotate on both axis
    public float speedH = 2.0f;
    public float speedV = 2.0f;
    private float yaw = 0.0f;
    private float pitch = 0.0f;



    // Use this for initialization
    void Start()
    {
		Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Input.GetAxis("R_XAxis_2"));

        yaw += (speedH * Input.GetAxis("Mouse X")) + (speedH * Input.GetAxis("R_XAxis_2"));
        pitch -= (speedV * Input.GetAxis("Mouse Y")) + (speedV * -Input.GetAxis("R_YAxis_2"));
        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
		// turn off mouselock and give access to the mouse
		if (Input.GetKeyDown ("escape"))
			Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;
    }
}
