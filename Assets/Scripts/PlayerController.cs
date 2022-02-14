using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject[] PowerUpIndicators;

    private Rigidbody PlayerRigidbody;
    [SerializeField]private float Speed = 10;

    public bool HasPowerUp;
    public float PowerUpForce = 150f;

    //Localizamos el GameObject
    private GameObject FocalPoint;
    // Start is called before the first frame update
    void Start()
    {
        PlayerRigidbody = GetComponent<Rigidbody>();
        //Accedemos a las componentes de la FocalPoint que controla la rotaci�n de la c�mara
        FocalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        //Si la c�mara rota los ejes de la bola se posicionan respecto a los de la c�mara (GameObject(FocalPoint).transform.direcci�n)
        float VerticalInput = Input.GetAxis("Vertical");
        PlayerRigidbody.AddForce(FocalPoint.transform.forward * Speed * VerticalInput);
        float HorizontalInput = Input.GetAxis("Horizontal");
        PlayerRigidbody.AddForce(FocalPoint.transform.right * Speed * HorizontalInput);
    }

    //Recoge el Power Up
    private void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Power Up"))
        {
            HasPowerUp = true;
            StartCoroutine(PowerUpCountDown());
            Destroy(otherCollider.gameObject);
        }
    }

    //Si tengo el PowerUp, disparamos al enemigo en la direcci�n contraria a la que viene
    private void OnCollisionEnter(Collision otherCollider)
    {
        if(HasPowerUp && otherCollider.gameObject.CompareTag("Enemy"))
        {
            Rigidbody EnemyRigidbody = otherCollider.gameObject.GetComponent<Rigidbody>();
            Vector3 AwayFromPlayer = (otherCollider.gameObject.transform.position - transform.position).normalized;
            EnemyRigidbody.AddForce(AwayFromPlayer * PowerUpForce, ForceMode.Impulse);
        }
    }

    //Si coge el PowerUp va mostrando alrededor del Player diferentes anillos que indican la cantidad de tiempo restante antes de que se agote el PoweruP
    private IEnumerator PowerUpCountDown()
    {
        for (int i = 1; i < PowerUpIndicators.Length; i++)
        {
            //GameObject en escena
            PowerUpIndicators[i].SetActive(true);
            yield return new WaitForSeconds(2);
            PowerUpIndicators[i].SetActive(false);
        }
        HasPowerUp = false;
    }
}
