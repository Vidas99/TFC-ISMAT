using UnityEngine;
using System.Collections;
using UnityEngine.Video;

public class ClickableBox : MonoBehaviour {

	public string videoURL { get; set; }
	
	/// <summary>
	/// Associar o URL do video com base no nome do quadro da UC
	/// </summary>
	/// <param name="boxName"> Serve para dar um nome ao quadro da UC e associar o URL no script RayCastClick.cs </param>
	/// <returns>Retorna string com o caminho para o video correspondente</returns>
    public string SetVideoPlayerURL(string boxName)
	{
		return videoURL = $"Assets/Courses/EngInformatica/{boxName}.mp4";
	}
	
}
