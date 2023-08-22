using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour
{
    private List<Enemy> enemies = new List<Enemy>();
    private List<BiggerEnemy> bigEnemies = new List<BiggerEnemy>(); // Add this list for big enemies.
    UIManager uIManager;
    private int enemiesDefeatedCount = 0;
    private int bigEnemiesDefeatedCount = 0; // Add a count for defeated big enemies.
    private int totalEnemiesCount = 0;
    private int totalBigEnemiesCount = 0; // Add a count for total big enemies.

    public int EnemiesDefeatedCount => enemiesDefeatedCount;
    public int BigEnemiesDefeatedCount => bigEnemiesDefeatedCount; // Add a property for defeated big enemies.
    public int TotalEnemiesCount => totalEnemiesCount;
    public int TotalBigEnemiesCount => totalBigEnemiesCount; // Add a property for total big enemies.

    private void Start()
    {
        uIManager = FindObjectOfType<UIManager>();
    }

    public void RegisterEnemy(Enemy enemy)
    {
        enemies.Add(enemy);
        totalEnemiesCount++;
    }

    public void RegisterBigEnemy(BiggerEnemy bigEnemy) // Add a method to register big enemies.
    {
        bigEnemies.Add(bigEnemy);
        totalBigEnemiesCount++;
    }

    public void EnemyDefeated(Enemy defeatedEnemy)
    {
        enemies.Remove(defeatedEnemy);
        enemiesDefeatedCount++;
        //Debug.Log(totalEnemiesCount);
        //Debug.Log(enemiesDefeatedCount);
        CheckAllEnemiesDefeated();
    }

    public void BigEnemyDefeated(BiggerEnemy defeatedBigEnemy) // Add a method for defeated big enemies.
    {
        bigEnemies.Remove(defeatedBigEnemy);
        bigEnemiesDefeatedCount++;
        CheckAllEnemiesDefeated();
    }

    private void CheckAllEnemiesDefeated()
    {
        if (enemies.Count == 0 && bigEnemies.Count == 0) // Check both lists.
        {
            MoneyManager moneyManager = FindObjectOfType<MoneyManager>();
            if (moneyManager != null)
            {
                moneyManager.SaveMoney();
            }
            uIManager.ShowCompletePanel();
        }
        uIManager.UpdateUIBar();
    }
}
