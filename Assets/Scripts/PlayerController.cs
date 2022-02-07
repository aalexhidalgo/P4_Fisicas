using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody PlayerRigidbody;
    [SerializeField]private float Speed = 10;

    public bool HasPowerUp;

    //Localizamos el GameObject
    private GameObject FocalPoint;
    // Start is called before the first frame update
    void Start()
    {
        PlayerRigidbody = GetComponent<Rigidbody>();
        //Accedemos a las componentes de la FocalPoint que controla la rotación de la cámara
        FocalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        //Si la cámara rota los ejes de la bola se posicionan respecto a los de la cámara (GameObject(FocalPoint).transform.dirección)
        float VerticalInput = Input.GetAxis("Vertical");
        PlayerRigidbody.AddForce(FocalPoint.transform.forward * Speed * VerticalInput);
        float HorizontalInput = Input.GetAxis("Horizontal");
        PlayerRigidbody.AddForce(FocalPoint.transform.right * Speed * HorizontalInput);
    }

    private void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Power Up"))
        {
            HasPowerUp = true;
            Destroy(otherCollider.gameObject);
        }
    }
}
