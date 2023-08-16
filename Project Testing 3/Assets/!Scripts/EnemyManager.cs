using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour
{
    private List<Enemy> enemies = new List<Enemy>();
    UIManager uIManager;
    private int enemiesDefeatedCount = 0;
    private int totalEnemiesCount = 0;

    public int EnemiesDefeatedCount => enemiesDefeatedCount;
    public int TotalEnemiesCount => totalEnemiesCount;

    private void Start()
    {
        uIManager = FindObjectOfType<UIManager>();
    }
    public void RegisterEnemy(Enemy enemy)
    {
        enemies.Add(enemy);
        totalEnemiesCount++;
    }

    public void EnemyDefeated(Enemy defeatedEnemy)
    {
        enemies.Remove(defeatedEnemy);
        enemiesDefeatedCount++;
        Debug.Log(totalEnemiesCount);
        Debug.Log(enemiesDefeatedCount);
        if (enemies.Count == 0)
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

    private void LoadNextScene()
    {
        Debug.Log("EnemyManager is triggering");
        SceneManager.LoadScene("MainMenu");
    }
    private void LoadMainMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
