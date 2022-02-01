using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody EnemyRigidbody;
    private GameObject Player;

    [SerializeField] private float Speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        EnemyRigidbody = GetComponent<Rigidbody>();
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Direction = (Player.transform.position - this.transform.position).normalized;
        EnemyRigidbody.AddForce(Direction * Speed);
    }
}
