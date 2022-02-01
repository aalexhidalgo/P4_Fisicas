using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float YLimit = 0.5f;
    private float ZLimit = 9f;
    private float XLimit = 9f;

    public GameObject Enemy;

    void Start()
    {
        RandomSpawnPosition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 RandomSpawnPosition()
    {
        float XRandom = Random.Range(-XLimit, XLimit);
        float ZRandom = Random.Range(-ZLimit, ZLimit);
        return new Vector3 (XRandom, YLimit, ZRandom);
    }
    private void SpawnEnemy()
    {
        Instantiate(Enemy, RandomSpawnPosition(), Enemy.transform.rotation);
    }
}
