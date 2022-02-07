using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucles : MonoBehaviour
{
    public int InitialNum = 30;

    public GameObject EnemyPrefab; 
    public GameObject[] EnemyPrefabs;
    public Vector3[] Positions;
    void Start()
    {
        //Cuenta regresiva
        /*for (int Time = InitialNum; Time >= 0; Time --)
        {
            Debug.Log(Time);
        }
        */

        //Se instancian los diferentes enemigos en el mismo orden que la ride de vectores (1 por cada vector)
        /*for (int i = 0; i < Positions.Length; i ++)
        {
            Instantiate(EnemyPrefabs[i], Positions[i], EnemyPrefabs[i].transform.rotation);
        }
        */

        //El enemigo se instancia en cada posición de nuestra colección
        /*foreach (Vector3 Pos in Positions)
        {
            Instantiate(EnemyPrefab, Pos, EnemyPrefab.transform.rotation);
        }
        */

        StartCoroutine(Fade());
    }

    void Update()
    {
        
    }
    //Degradado (Alpha)
    public IEnumerator Fade()
    {
        float AlphaValue = 0;
        MeshRenderer SphereMeshRenderer = GetComponent<MeshRenderer>();
        Color Color = SphereMeshRenderer.material.color;

        while (AlphaValue <= 1)
        {
            Color.a = AlphaValue;
            SphereMeshRenderer.material.color = Color;
            AlphaValue += 0.1f;
            yield return new WaitForSeconds(1);
        }
    }
}
