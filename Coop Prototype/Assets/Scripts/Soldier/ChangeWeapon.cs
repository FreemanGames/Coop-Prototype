using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeWeapon : MonoBehaviour {

    private bool rifleOut = true;
    private bool pistolOut = false;


    // Use this for initialization
    void Start () {
        GetComponentInChildren<AssaultRifle>().UpdateText();
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Alpha1) && rifleOut == false)
        {
            GetComponentInChildren<AssaultRifle>().enabled = true;
            GetComponentInChildren<Pistol>().enabled = false;
            pistolOut = false;
            rifleOut = true;
            GetComponentInChildren<AssaultRifle>().UpdateText();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && pistolOut == false)
        {
            GetComponentInChildren<Pistol>().enabled = true;
            GetComponentInChildren<AssaultRifle>().enabled = false;
            rifleOut = false;
            pistolOut = true;
            GetComponentInChildren<Pistol>().UpdateText();
        }
    }
}
