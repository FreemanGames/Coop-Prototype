using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateTrigger : MonoBehaviour {

    public GameObject gate;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gate.SetActive(false);
        }
    }
}