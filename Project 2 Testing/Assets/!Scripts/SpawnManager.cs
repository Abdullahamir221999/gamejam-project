using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    private float spawnRangeX = 5;
    private float spawnPosZ = 90;
    private float startDelay = 2;
    private float spawnInterval = 0.5f;

    public LevelSpawnSettings levelSpawnSettings; // Reference to the LevelSpawnSettings asset

    private bool isSpawning = true;

    void Start()
    {
        StartCoroutine(SpawnEnemiesWithTimer());
    }

    void Update()
    {

    }

    IEnumerator SpawnEnemiesWithTimer()
    {
        yield return new WaitForSeconds(startDelay);

        float timer = 0f;
        while (isSpawning && timer < levelSpawnSettings.spawnDuration)
        {
            int enemyIndex = Random.Range(0, enemyPrefabs.Length);
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 2.05f, spawnPosZ);
            Instantiate(enemyPrefabs[enemyIndex], spawnPos, enemyPrefabs[enemyIndex].transform.rotation);

            timer += spawnInterval;
            yield return new WaitForSeconds(spawnInterval);
        }

        // Timer has completed, spawning stops.
        isSpawning = false;
    }
}
