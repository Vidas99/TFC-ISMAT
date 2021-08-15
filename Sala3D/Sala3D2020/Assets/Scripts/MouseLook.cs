using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseLook : MonoBehaviour
{


    public float mouseSensitivity = 100f;
    public Transform playerBody;
    float xRotation = 0f;
    int x = 0;
    //float yRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //para o cursor n sair do ecra e ficar invis.
   
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY; //tem de ser negativo para não aparecer invertido
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //yRotation -= mouseX;
        //yRotation = Mathf.Clamp(yRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseX);

        //if (x == 0)
        //{
        //    SceneManager.LoadScene("Hall");
        //    x = 1;
        //}
    }
}



//nao consigo bloquear a camara 180º no eixo Y(esq/dir)

//transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);


