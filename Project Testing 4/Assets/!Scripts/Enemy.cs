using System;
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
    public GameObject splash;
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
        Quaternion rot = Quaternion.Euler(90, 0, 0);
       ParticleSystem f = Instantiate(splat, transform.position, Quaternion.identity);
        GameObject s = Instantiate(splash,new Vector3(transform.position.x,0.32F,transform.position.z), rot);
         f.Play();
      //  Vector3 c= new Vector3(transform.position.x,-5.22F,transform.position.z);
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
