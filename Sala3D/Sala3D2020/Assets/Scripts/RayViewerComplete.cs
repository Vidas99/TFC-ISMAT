using UnityEngine;
using System.Collections;
/// <summary>
/// Edita o comprimento do laser de debug(Debug.DrawRay); Associa a camara principal para ser instanciada.
/// </summary>
public class RayViewerComplete : MonoBehaviour {

    public float weaponRange = 50f;                       

    private Camera fpsCam;                                

    /// <summary>
    /// Vai referenciar a camara procurando o gameobject e os seus parents
    /// </summary>
	void Start () 
    {
        // Get and store a reference to our Camera by searching this GameObject and its parents
        fpsCam = GetComponentInParent<Camera>();
	}

	/// <summary>
    /// Vetor - Posicionar a camara no centro do ecra.Canto inferior do ecra é o ponto (0f,0f,0f).
    /// DrawRay foi um laser que me ajudou no debug para coincidir a linha de visão da camara com o apontador.
    /// </summary>
	void Update () 
    {
        // Create a vector at the center of our camera's viewport
        Vector3 lineOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));

        // Draw a line in the Scene View  from the point lineOrigin in the direction of fpsCam.transform.forward * weaponRange, using the color green
        Debug.DrawRay(lineOrigin, fpsCam.transform.forward * weaponRange, Color.green);
	}
}
