using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
	// how fast the play will turn
	public float speedH = 2.0f;
	// bool used so the player cant jump infinitely
	public bool grounded = true;
	// speed the player walks forward
	public float speed = 0.2f;
	// speed the player sprints at
	public float sprintSpeed = 0.15f;
	// speed the player strafes
	public float strafeSpeed = 0.075f;
	// speed the player walks backwards
	public float backUpSpeed = -0.05f;
	// second variable in the player turn speed
	private float xRotate = 0.0f;


	// Use this for initialization
	void Start () {
	}
	// Update is called once per frame
	void Update () {
		// movement
		if (Input.GetKey (KeyCode.W)) {
			transform.position += transform.forward * speed;
		}
		if (Input.GetKey (KeyCode.S)) {
			transform.position += transform.forward * backUpSpeed;
		}
		if (Input.GetKey (KeyCode.A)) {
			transform.position += transform.right * -strafeSpeed;
		}
		if (Input.GetKey (KeyCode.D)) {
			transform.position += transform.right * strafeSpeed;
		}
		if (Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.LeftShift)) {
			transform.position += transform.forward * sprintSpeed;
		}
		if (Input.GetKeyDown (KeyCode.Space) && grounded == true) {
			gameObject.GetComponent<Rigidbody> ().AddForce (Vector3.up * 200);
			grounded = false;
		}
		{
			//mouselook
			xRotate += speedH * Input.GetAxis("Mouse X");
			transform.eulerAngles = new Vector3(0.0f, xRotate, 0.0f);

			if (Input.GetKeyDown ("escape"))
				Cursor.lockState = CursorLockMode.None;
		}
	}
	void OnCollisionEnter(){
		// will change grounded back to true when the player collides with an object
		grounded = true;
	}
}