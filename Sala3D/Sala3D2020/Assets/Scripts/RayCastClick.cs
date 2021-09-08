using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class RayCastClick : MonoBehaviour
{
    
    // Determina o valor de cada laser.
    public int laserClick = 1;
    // Delay entre lasers (em tempo)
    public float clickRate = 0.25f;
    // Distância(comprimento) do laser.
    public float clickRange = 50f;
 
    // Simboliza onde o cano do apontador "aponta"
    public Transform gunEnd;                                            
    // Referencia a camara principal
    private Camera fpsCam;
    // WaitForSeconds é o objeto utilizado no ShotEffect (determina se o laser é visivel ou nao) e quanto tempo o laser fica visivel.
    private WaitForSeconds laserDuration = new WaitForSeconds(0.07f);    
    
    private AudioSource videoLoadedSound;
    
    private AudioClip clip;
    
    public float clipVolume = 0.5f;
    // Referencia ao componente LineRenderer que determina se o laser vai ser visivel ou não.
    private LineRenderer laserLine;                                     
    //Tempo(float) até que o jogador possa enviar outro laser (após já ter lançado um)
    private float nextFire;
    //Videoplayer que irá ser associado para a reprodução de media
    private VideoPlayer vp { get; set; }
   



    void Start()
    {
        // Inicia o componente LineRenderer
        laserLine = GetComponent<LineRenderer>();

        vp = GameObject.Find("ScreenPlayer").GetComponent<VideoPlayer>();
        // Associa o som ao projetor
        videoLoadedSound = GameObject.Find("projector").GetComponent<AudioSource>();
        // diretoria do ficheiro de som
        clip = Resources.Load<AudioClip>("Assets/Sounds/VideoLoaded");
        // Atualiza a posição da camara ao associar o componente.
        fpsCam = GetComponentInParent<Camera>();
    }


    void Update()
    {
        // Verifica se o jogador disparou um laser e se passou tempo suficiente desde que o lançou. 
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            // Atualiza o tempo quando o jogador puder enviar outro laser.
            nextFire = Time.time + clickRate;

            // Inicia a rotina de tornar o laser on e off
            StartCoroutine(ShotEffect());

            // Cria o vetor para centrar no centro do ecra (campo de visão)(canto inferior esquerdo é (0f,0f,0f), 0,5f simboliza o centro do ecra).
            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));

            // Declara quando o laser "acerta" para guardar a informação
            RaycastHit hit;

            // Marca a posição inicial do laser, começa no gunEnd
            laserLine.SetPosition(0, gunEnd.position);

            // Verifica se o laser atingiu um objecto válido
            if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, clickRange))
            {
                // Determina o "fim" do laser (quando embate em algo) 
                laserLine.SetPosition(1, hit.point);

                // Cria a referência de guardar a informação quando "é atingido" pelo laser. (o script ClickableBox tem de ser
                // associado aos objetos que queremos despoletar acções após ser atingido)
                ClickableBox box = hit.collider.GetComponent<ClickableBox>();

                // Caso o scrip esteja associado, quando o quadro da UC recebe um laser, associa o video pretendido á tela(screenplayer) de forma a
                //ser possível reproduzir o video e ativa os botões para controlar a reprodução do video.
                if (box != null)
                {
                    // carregar video no video player
                    //hit.transform.gameObject.name

                    //Se o laser ñ atingir a tela, ou botao de play,pause ou stop, carregar o URL do video ao VideoPlayer
                    //verifica se o nome do objeto atingido é diferente da tela ou botões de media. Caso seja true ele carrega o URL com o nome do quadro da UC.
                    if ((hit.transform.gameObject.name != "ScreenPlayer") && (hit.transform.gameObject.name != "PlayVideo")
                            && (hit.transform.gameObject.name != "PauseVideo") && (hit.transform.gameObject.name != "StopVideo"))
                    {
                        box.SetVideoPlayerURL(hit.transform.gameObject.name.ToString());
                        vp.url = box.videoURL;
                        videoLoadedSound.Play();
                    }
                    else if (hit.transform.gameObject.name.Equals("PlayVideo")) // verifica se o nome do objeto atingido é o botao de play, se for, inicia o video
                    {
                        vp.Play();
                    }
                    else if (hit.transform.gameObject.name.Equals("PauseVideo")) // verifica se o nome do objeto atingido é o botao de pause, se for, pausa o video
                    {
                        vp.Pause();
                    }
                    else if (hit.transform.gameObject.name.Equals("StopVideo")) // verifica se o nome do objeto atingido é o botao de stop, se for, pára o video
                    {
                        vp.Stop();
                    }

                }
            }
            else
            {
                // Se o laser não atinja nada acima, calcula-se o range maximo que este pode atingir
                laserLine.SetPosition(1, rayOrigin + (fpsCam.transform.forward * clickRange));
            }
        }
    }


    private IEnumerator ShotEffect()
    {

        // Turn on our line renderer
        laserLine.enabled = true;

        //Espera .07 seconds
        yield return laserDuration;

        // Deactivate our line renderer after waiting
        laserLine.enabled = false;
    }
}