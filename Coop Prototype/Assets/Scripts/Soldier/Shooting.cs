﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{

    // magazine stars with zero rounds
    public int ammoCount = 5;
    // magazine can hold a maximum of 7 rounds
    public int clipSize = 5;
    // ammunition starts at 7
    public int clipCount = 50;
    //gameobject and transform for the noisemaker that is created with each shot taken
    //public GameObject noise;
    //public Transform noiseMaker;
    // boolean to be used in the reload function
    public bool reloaded = true;
    // delay in reload so its not instantanious
    private float reloadDelay = 3.0f;
    private float baseFOV = 60f;
    private bool toggle = false;
    //text to display the ammocount
    public Text ammoText;
    public Text clipText;
    public Text weapon;
    public string whichWeapon;

    // delay between gunshots
    public float timeBetweenBullets = 1.0f;
    private float timer;

    //damage value of the weapon
    public int damage = 1;

    //audioclips for the gun
    public AudioClip shootSound;
    public AudioClip reloadSound;
    public AudioClip dryFireSound;
    private AudioSource source;

    //volume range for the audio
    private float volLowRange = 1.0f;
    private float volhighRange = 1.0f;

    public GameObject impactEffect;
    public GameObject camera;
    public Camera cam;

    void Start()
    {
        UpdateText();
        timer = Time.time;
        weapon.text = whichWeapon.ToString();
        //baseFOV = Camera.main.fieldOfView;
        //cam = GetComponent<Camera>();
    }
    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    private void Reload()
    {
        ammoCount += clipCount;
        if (ammoCount > clipSize)
        {
            clipCount = clipSize;
            ammoCount -= clipSize;
        }
        else
        {
            clipCount = ammoCount;
            ammoCount = 0;
        }
        UpdateText();
    }

    public void UpdateText()
    {
        // changes text to whatever value the the ammo and clip count are
        ammoText.text = ammoCount.ToString();
        clipText.text = clipCount.ToString();
    }

    public void addAmmo(int addAmmo)
    {
        //adds ammo from the clipcount top the ammocount
        ammoCount = ammoCount + addAmmo;
        UpdateText();
    }

    private void DryFire()
    {
        float vol = Random.Range(volLowRange, volhighRange);
        source.PlayOneShot(dryFireSound, vol);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && reloaded == true)
        {
            float vol = Random.Range(volLowRange, volhighRange);
            source.PlayOneShot(reloadSound, vol);
            reloaded = false;
            Invoke("Reload", 3);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            UpdateText();

        }

        // if the mouse button is presses and reloaded is true activate the firedelay timer and check the clipcount value
        if (Input.GetMouseButton(0) && reloaded == true)
        {
            if (Time.time - timer > timeBetweenBullets)
            {
                timer = Time.time;
                // if the player has ammunition fire and play the shootsound audio clip
                if (clipCount > 0)
                {
                    float vol = Random.Range(volLowRange, volhighRange);
                    source.PlayOneShot(shootSound, vol);

                    clipCount--;
                    //will create the noisemaker oject that will attract enemies above where the player was when they fired and send out a raycast
                    UpdateText();
                    //GameObject Go = Instantiate(noise, noiseMaker.position, Quaternion.identity) as GameObject;

                    Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
                    RaycastHit hit;
                    // if the raycast hits a collider with the component EnemyHealth deal 1 damage to the health value
                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.collider.gameObject.tag == "Enemy")
                        {
                            //hit.collider.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
                        }
                        else if (hit.collider.gameObject.tag == "Ground")
                        {
                            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                            Destroy(impactGO, 50f);
                        }
                    }
                }
            }
        }
        if (Input.GetMouseButtonDown(0) && reloaded == true)
        {
            if (clipCount == 0)
            {
                Invoke("DryFire", 0);
            }
        }
        // makes it so the you cant keep pressing the reload button making the audio overlap
        if (reloaded == false)
        {
            if (Time.time - timer > reloadDelay)
            {
                timer = Time.time;

                reloaded = true;
            }
        }
    }
}