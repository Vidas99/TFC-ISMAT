using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoLoader : MonoBehaviour
{

	private Camera fpsCam;                                              // Holds a reference to the first person camera
	private WaitForSeconds shotDuration = new WaitForSeconds(0.07f);    // WaitForSeconds object used by our ShotEffect coroutine, determines time laser line will remain visible
	private AudioSource gunAudio;                                       // Reference to the audio source which will play our shooting sound effect
	private LineRenderer laserLine;
	public VideoPlayer boxVideoPlayer { get; set; }


    // Start is called before the first frame update
    void Start()
    {
		// Get and store a reference to our LineRenderer component
		laserLine = GetComponent<LineRenderer>();

		// Get and store a reference to our AudioSource component
		gunAudio = GetComponent<AudioSource>();

		// Get and store a reference to our Camera by searching this GameObject and its parents
		fpsCam = GetComponentInParent<Camera>();
	}

    // Update is called once per frame
    void Update()
    {
        
    }

   


}
