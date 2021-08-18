using UnityEngine;
using System.Collections;
using UnityEngine.Video;

public class ClickableBox : MonoBehaviour {

	public string videoURL { get; set; }
	
	
    public string SetVideoPlayerURL(string boxName)
	{
		return videoURL = $"Assets/Courses/EngInformatica/{boxName}.avi";
	}
	
}
//TODO: Quando o objeto perder as vidas, carregar o video no botão play.
//após disparar ao botao o video começar a reproduzir.
//no shootablebox.cs perde as vidas e carrega o video
//no rayCastShootComplete.cs é que inicia/pausa/para o video