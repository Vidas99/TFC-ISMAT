﻿using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class RayCastShootComplete : MonoBehaviour
{
    
    // Set the number of hitpoints that this gun will take away from shot objects with a health script
    public int laserClick = 1;
    // Number in seconds which controls how often the player can fire
    public float fireRate = 0.25f;
    // Distance in Unity units over which the player can fire
    public float weaponRange = 50f;
    // Amount of force which will be added to objects with a rigidbody shot by the player
    public float hitForce = 100f;
    // Holds a reference to the gun end object, marking the muzzle location of the gun
    public Transform gunEnd;                                            
    // Holds a reference to the first person camera
    private Camera fpsCam;
    // WaitForSeconds object used by our ShotEffect coroutine, determines time laser line will remain visible
    private WaitForSeconds shotDuration = new WaitForSeconds(0.07f);    
    
    private AudioSource videoLoadedSound;
    
    private AudioClip clip;
    
    public float clipVolume = 0.5f;
    // Reference to the LineRenderer component which will display our laserline
    private LineRenderer laserLine;                                     
    
    private float nextFire;
    
    private VideoPlayer vp { get; set; }
    // Float to store the time the player will be allowed to fire again, after firing



    void Start()
    {
        // Get and store a reference to our LineRenderer component
        laserLine = GetComponent<LineRenderer>();

        vp = GameObject.Find("ScreenPlayer").GetComponent<VideoPlayer>();
        // Get and store a reference to our AudioSource component
        videoLoadedSound = GameObject.Find("projector").GetComponent<AudioSource>();
        clip = Resources.Load<AudioClip>("Assets/Sounds/VideoLoaded");
        // Get and store a reference to our Camera by searching this GameObject and its parents
        fpsCam = GetComponentInParent<Camera>();
    }


    void Update()
    {
        // Check if the player has pressed the fire button and if enough time has elapsed since they last fired
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            // Update the time when our player can fire next
            nextFire = Time.time + fireRate;

            // Start our ShotEffect coroutine to turn our laser line on and off
            StartCoroutine(ShotEffect());

            // Create a vector at the center of our camera's viewport
            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));

            // Declare a raycast hit to store information about what our raycast has hit
            RaycastHit hit;

            // Set the start position for our visual effect for our laser to the position of gunEnd
            laserLine.SetPosition(0, gunEnd.position);

            // Check if our raycast has hit anything
            if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, weaponRange))
            {
                // Set the end position for our laser line 
                laserLine.SetPosition(1, hit.point);

                // Get a reference to a health script attached to the collider we hit
                ClickableBox box = hit.collider.GetComponent<ClickableBox>();

                // If there was a health script attached
                if (box != null)
                {
                    // Call the damage function of that script, passing in our gunDamage variable
                    box.ClickDetection(laserClick);
                    // carregar video no video player
                    //hit.transform.gameObject.name
                    if ((hit.transform.gameObject.name != "ScreenPlayer") && (hit.transform.gameObject.name != "PlayVideo")
                            && (hit.transform.gameObject.name != "PauseVideo") && (hit.transform.gameObject.name != "StopVideo"))
                    {
                        //get object name and set it to the Url value of the video player
                        box.SetVideoPlayerURL(hit.transform.gameObject.name.ToString());
                        vp.url = box.videoURL;
                        videoLoadedSound.Play();
                        //gunAudio.Play();

                    }
                    else if (hit.transform.gameObject.name.Equals("PlayVideo"))
                    {
                        vp.Play();
                    }
                    else if (hit.transform.gameObject.name.Equals("PauseVideo"))
                    {
                        vp.Pause();
                    }
                    else if (hit.transform.gameObject.name.Equals("StopVideo"))
                    {
                        vp.Stop();
                    }

                }



                // Check if the object we hit has a rigidbody attached
                if (hit.rigidbody != null)
                {
                    // Add force to the rigidbody we hit, in the direction from which it was hit
                    hit.rigidbody.AddForce(-hit.normal * hitForce);
                }
            }
            else
            {
                // If we did not hit anything, set the end of the line to a position directly in front of the camera at the distance of weaponRange
                laserLine.SetPosition(1, rayOrigin + (fpsCam.transform.forward * weaponRange));
            }
        }
    }


    private IEnumerator ShotEffect()
    {
        // Play the shooting sound effect
        //gunAudio.Play();

        // Turn on our line renderer
        laserLine.enabled = true;

        //Wait for .07 seconds
        yield return shotDuration;

        // Deactivate our line renderer after waiting
        laserLine.enabled = false;
    }
}