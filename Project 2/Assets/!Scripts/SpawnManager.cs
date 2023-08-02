using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] enemyPrefabs;
    private float spawnRangeX = 5;
    private float spawnPosZ = 50;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            SpawnRandomEnemy();
        }

    }
    void SpawnRandomEnemy()
    {
        int enemyIndex = Random.Range(0, enemyPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 2.05f, spawnPosZ);
        Instantiate(enemyPrefabs[enemyIndex], spawnPos, enemyPrefabs[enemyIndex].transform.rotation);
    }
}
