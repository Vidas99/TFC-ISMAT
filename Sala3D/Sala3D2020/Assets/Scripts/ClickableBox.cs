using UnityEngine;
using System.Collections;
using UnityEngine.Video;

public class ClickableBox : MonoBehaviour {

	public string videoURL { get; set; }
	
	
    public string SetVideoPlayerURL(string boxName)
	{
		return videoURL = $"Assets/Courses/EngInformatica/{boxName}.mp4";
	}
	
}
