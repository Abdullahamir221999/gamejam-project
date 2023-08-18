using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiggerEnemy : MonoBehaviour
{
    public int maxHealth = 300; // Adjust as needed
    public int moneyAmount = 10; // Adjust as needed
    private int currentHealth;
    private EnemyManager enemyManager;

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
        }
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
