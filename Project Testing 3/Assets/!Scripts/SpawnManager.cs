using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    private float spawnRangeX = 4;
    private float spawnPosZ = 60;
    private float startDelay = 1;
    private float spawnInterval = 0.5f;

    public LevelSpawnSettings levelSpawnSettings; // Reference to the LevelSpawnSettings asset
    private UIManager uIManager;
    private bool isSpawning = true;

    void Start()
    {
        uIManager = FindObjectOfType<UIManager>();
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
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0.5f, spawnPosZ);
            GameObject newEnemy = Instantiate(enemyPrefabs[enemyIndex], spawnPos, enemyPrefabs[enemyIndex].transform.rotation);

            // Attach MoveForward script to the spawned enemy.
            MoveForward moveForwardScript = newEnemy.GetComponent<MoveForward>();
            if (moveForwardScript != null)
            {
                moveForwardScript.enabled = true;
            }

            timer += spawnInterval;
            yield return new WaitForSeconds(spawnInterval);
        }

        // Timer has completed, spawning stops.
        isSpawning = false;
    }
}
