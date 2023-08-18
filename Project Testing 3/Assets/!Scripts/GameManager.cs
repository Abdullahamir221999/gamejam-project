using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int LevelNo;
    bool gameHasEnded = false;
    public float restartDelay = 1f;

    // Add the turret position as a public Transform variable.
    public Transform turretPosition;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }
    public void Change_Scene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
