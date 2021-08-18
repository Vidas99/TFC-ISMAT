using UnityEngine;
using System.Collections;
using UnityEngine.Video;

public class ClickableBox : MonoBehaviour {

	public string videoURL { get; set; }
	
	//The box's current health point total
	public int currentHealth = 3;


    public string SetVideoPlayerURL(string boxName)
	{
		return videoURL = $"Assets/{boxName}.avi";
	}


	public void ClickDetection(int hitDetection)
	{
		//subtract damage amount when Damage function is called
		currentHealth -= hitDetection*3;

		//Check if health has fallen below zero
		if (currentHealth <= 0) 
		{
			//if health has fallen below zero, deactivate it 
			//gameObject.SetActive (false);

			
				

		}
	}
}
//TODO: Quando o objeto perder as vidas, carregar o video no botão play.
//após disparar ao botao o video começar a reproduzir.
//no shootablebox.cs perde as vidas e carrega o video
//no rayCastShootComplete.cs é que inicia/pausa/para o video