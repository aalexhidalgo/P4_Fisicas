using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    [SerializeField]private float RotationSpeed = 500f;

    void Update()
    {
        /*Rota con las teclas izquierda y derecha
        float HorizontalInput = Input.GetAxis("Horizontal");
        //Rota de manera anti-horaria
        transform.Rotate(Vector3.up, RotationSpeed * Time.deltaTime * HorizontalInput);
        */

        //Rotar con el Mouse
        float HorizontalInputMouse = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up, RotationSpeed * Time.deltaTime * HorizontalInputMouse);


    }
}
