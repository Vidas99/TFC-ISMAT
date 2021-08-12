using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class EI_PlayVideo : MonoBehaviour
{

    public VideoClip videoClip;
    private AudioSource audioSource;
    private IEnumerator videoCoRoutine;
    private int counter = 1;
    private VideoPlayer videoPlayer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.F1)) && (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Sala")))
        {
            if (videoPlayer.isPlaying)
            {
                videoPlayer.Pause();
            }
            else
            {
                videoPlayer.Play();
            }
        }
        if ((Input.GetKeyDown(KeyCode.F2)) && (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Sala")))
        {
            if (counter % 2 == 0)
            {
                counter++;
                videoPlayer.Pause();
                videoPlayer.url = "file://C:/Users/Vidas/Desktop/Unity-Github/TFC-ISMAT/Sala3D/Sala3D2020/Assets/FlushedAwayViralPiece.avi";
            }
            else
            {
                counter++;
                videoPlayer.Pause();
                videoPlayer.url = "file://C:/Users/Vidas/Desktop/Unity-Github/TFC-ISMAT/Sala3D/Sala3D2020/Assets/GandalfVsBicha.avi";
            }
        }


    }

    void Awake()
    {
        videoPlayer = GetComponent<VideoPlayer>();
    }

}
