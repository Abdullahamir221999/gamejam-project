using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour
{
    private List<Enemy> enemies = new List<Enemy>(); // List to keep track of all enemies.

    public void RegisterEnemy(Enemy enemy)
    {
        enemies.Add(enemy); // Register the enemy with the manager.
    }

    public void EnemyDefeated(Enemy defeatedEnemy)
    {
        enemies.Remove(defeatedEnemy); // Remove the defeated enemy from the list.

        if (enemies.Count == 0)
        {
            LoadNextScene();
        }
    }

    private void LoadNextScene()
    {
        Debug.Log("EnemyManager is triggering");
        // Assuming the current scene is part of a build, load the next scene in the build.
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene(nextSceneIndex);
    }
}
