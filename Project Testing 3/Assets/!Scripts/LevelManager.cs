using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject[] levelObjects;

    private int currentLevelIndex = 0;

    private void Start()
    {
        SwitchLevel(currentLevelIndex);
    }

    public void SwitchToNextLevel()
    {
        currentLevelIndex = (currentLevelIndex + 1) % levelObjects.Length;
        SwitchLevel(currentLevelIndex);
    }

    private void SwitchLevel(int index)
    {
        for (int i = 0; i < levelObjects.Length; i++)
        {
            levelObjects[i].SetActive(i == index);
        }
    }
}
