using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour
{
    private List<Enemy> enemies = new List<Enemy>();
    UIManager uIManager;

    private void Start()
    {
        uIManager = FindObjectOfType<UIManager>();
    }
    public void RegisterEnemy(Enemy enemy)
    {
        enemies.Add(enemy);
    }

    public void EnemyDefeated(Enemy defeatedEnemy)
    {
        enemies.Remove(defeatedEnemy);

        if (enemies.Count == 0)
        {
            MoneyManager moneyManager = FindObjectOfType<MoneyManager>();
            if (moneyManager != null)
            {
                moneyManager.SaveMoney();
            }
            uIManager.ShowCompletePanel();
        }
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
