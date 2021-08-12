using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecondarySceneChanger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetMouseButtonDown(0)) && (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Hall")))
        {
            RoomSceneChanger();
        }
        if ((Input.GetMouseButtonDown(1)) && (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Sala")))
        {
            HallSceneChanger();
        }
    }

    public void RoomSceneChanger()
    {
        SceneManager.LoadScene("Sala");
    }
    
    public void HallSceneChanger()
    {
        SceneManager.LoadScene("Hall");
    }



    public void Exit()
    {
        Application.Quit();
    }


}


