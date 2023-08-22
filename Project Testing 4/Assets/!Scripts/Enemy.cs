using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemyManager enemyManager;
    public int maxHealth = 100;
    public int moneyAmount = 3;
    private int currentHealth;
    public ParticleSystem splat;
    void Start()
    {
        currentHealth = maxHealth;
        enemyManager = FindObjectOfType<EnemyManager>();
        enemyManager.RegisterEnemy(this);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            fx();
            Die();
        }
    }
    void fx()
    {
       ParticleSystem f = Instantiate(splat, transform.position, Quaternion.identity);
         f.Play();
    }
    private void Die()
    {
        enemyManager.EnemyDefeated(this);
        MoneyManager moneyManager = FindObjectOfType<MoneyManager>();

        if(moneyManager != null)
        {
            moneyManager.AddMoney(moneyAmount);
        }
        Destroy(gameObject);
    }
}
