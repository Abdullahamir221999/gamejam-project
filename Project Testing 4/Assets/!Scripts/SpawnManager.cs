using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    private float spawnRangeX = 7.69f;
    private float spawnPosZ = 28;
    private float startDelay = 1;
    private float spawnInterval = 0.5f;

    public LevelSpawnSettings[] levelSpawnSettings; // Reference to the LevelSpawnSettings asset
    private UIManager uIManager;
    private bool isSpawning = true;
    public GameObject[] AllEnemies;
    public GameObject[] enemiesAtLevel()
    {
        int lvlNo = GameManager.Instance.LevelNo;
        List<GameObject> tempEnemies = new List<GameObject>();

        switch (lvlNo)
        {
            case 0:
                tempEnemies.Add(AllEnemies[1]);
                tempEnemies.Add(AllEnemies[1]);
                tempEnemies.Add(AllEnemies[1]);
                Debug.Log("Color Changed to Red all characters");
                break;
            case 1:
                tempEnemies.Add(AllEnemies[2]);
                tempEnemies.Add(AllEnemies[2]);
                tempEnemies.Add(AllEnemies[2]);
                Debug.Log("Color Changed to Green all characters");
                break;
            case 2:
                tempEnemies.Add(AllEnemies[0]);
                tempEnemies.Add(AllEnemies[0]);
                tempEnemies.Add(AllEnemies[0]);
                Debug.Log("Color Changed to Blue all characters");
                break;
            case 3:
                tempEnemies.Add(AllEnemies[1]);
                tempEnemies.Add(AllEnemies[2]);
                tempEnemies.Add(AllEnemies[0]);
                Debug.Log("Color Changed to Red,Green,Blue characters");
                break;
            case 4:
                tempEnemies.Add(AllEnemies[4]);
                tempEnemies.Add(AllEnemies[3]);
                tempEnemies.Add(AllEnemies[5]);
                Debug.Log("Color Changed to Turqoise,Purple,Orange characters");
                break;
            case 5:

                tempEnemies.Add(AllEnemies[4]);
                tempEnemies.Add(AllEnemies[1]);
                tempEnemies.Add(AllEnemies[8]);
                tempEnemies.Add(AllEnemies[3]);
                Debug.Log("Color Changed to Red,Purple,turqoise,Big red characters");
                break;
            case 6:
                tempEnemies.Add(AllEnemies[0]);
                tempEnemies.Add(AllEnemies[2]);
                tempEnemies.Add(AllEnemies[5]);
                tempEnemies.Add(AllEnemies[7]);
                Debug.Log("Color Changed to Big Blue,blue,Green,Orange,Big Green characters");
                break;
            default:
                break;
        }
        return tempEnemies.ToArray();
    }
    void Awake()
    {
        enemyPrefabs = enemiesAtLevel();       
    }
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
        while (isSpawning && timer < levelSpawnSettings[GameManager.Instance.LevelNo].spawnDuration)
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
