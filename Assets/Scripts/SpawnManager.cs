using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float YLimit = 0.5f;
    private float ZLimit = 9f;
    private float XLimit = 9f;

    public GameObject Enemy;
    public GameObject PowerUp;

    private int EnemiesPerWave = 1;
    private int EnemiesLeft;
    void Start()
    {
        Instantiate(PowerUp, RandomSpawnPosition(), PowerUp.transform.rotation);
        SpawnEnemyWave(EnemiesPerWave);
    }

    // Update is called once per frame
    void Update()
    {
        EnemiesLeft = FindObjectsOfType<Enemy>().Length;
        if (EnemiesLeft <= 0)
        {
            EnemiesPerWave++;
            SpawnEnemyWave(EnemiesPerWave);
            Instantiate(PowerUp, RandomSpawnPosition(), PowerUp.transform.rotation);
        }
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

    private void SpawnEnemyWave (int TotalEnemies)
    {
        for (int i = 0; i < TotalEnemies; i++)
        {
            SpawnEnemy();
        }
    }
}
