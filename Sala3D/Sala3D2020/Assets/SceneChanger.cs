using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
	public void ChangeScene(string Hall)
	{
		SceneManager.LoadScene(Hall);
	}

	public void Exit()
	{
		Application.Quit();
	}
}