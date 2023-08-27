using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiggerEnemy : MonoBehaviour
{
    public int maxHealth = 300; // Adjust as needed
    public int moneyAmount = 10; // Adjust as needed
    private int currentHealth;
    private EnemyManager enemyManager;
    public ParticleSystem splat;
    public GameObject coinPrefab;
    public float coinSpawnHeight1 = 1.0f;
    public float coinSpawnHeight2 = 3.0f;

    void Start()
    {
        currentHealth = maxHealth;
        enemyManager = FindObjectOfType<EnemyManager>();
        enemyManager.RegisterBigEnemy(this);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
            fx();
            Vector3 spawnPos = new Vector3(transform.position.x, coinSpawnHeight1, transform.position.z);
            Instantiate(coinPrefab, spawnPos, Quaternion.identity);
            Vector3 spawnPos2 = new Vector3(transform.position.x, coinSpawnHeight2, transform.position.z);
            Instantiate(coinPrefab, spawnPos2, Quaternion.identity);
        }
    }

    void fx()
    {
        //if (gameObject.CompareTag("BigRedEnemy"))
        //{
        //    ParticleSystem f = Instantiate(splat[2], transform.position, Quaternion.identity);
        //    f.Play();
        //}
        //if (gameObject.CompareTag("BigBlueEnemy"))
        //{
        //    ParticleSystem f = Instantiate(splat[0], transform.position, Quaternion.identity);
        //    f.Play();
        //}
        //if (gameObject.CompareTag("BigGreenEnemy"))
        //{
        //    ParticleSystem f = Instantiate(splat[1], transform.position, Quaternion.identity);
        //    f.Play();
        //}
        ParticleSystem f = Instantiate(splat, transform.position, Quaternion.identity);
        f.Play();
        
    }

    private void Die()
    {
        enemyManager.BigEnemyDefeated(this);
        MoneyManager moneyManager = FindObjectOfType<MoneyManager>();
        if (moneyManager != null)
        {
            moneyManager.AddMoney(moneyAmount);
        }
        Destroy(gameObject);
    }
}
