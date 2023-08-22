using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectionHandler : MonoBehaviour
{
    
    public GameObject loadingScreen;
    public GameObject[] Levels;
    //public GameObject playbtn;
    int Current_Level;
    int unlockedLevels;
    int LatestLevel;
    
   
    void Start()
    {
        UnlockLevel();
    }
    public void UnlockLevel()
    {
        unlockedLevels = PlayerPrefs.GetInt("NextLevel");

        for (int i = 0; i <= unlockedLevels; i++)
        {
            LatestLevel = i;
        }
        Current_Level = GameManager.Instance.LevelNo;
    }
    public void OnClickLevel()
    {
        GameManager.Instance.LevelNo = LatestLevel;
        Current_Level = GameManager.Instance.LevelNo;
        Debug.Log("level Index" + Current_Level);
    }

    public void OnClickNext()
    {
        //audioSource.Stop();
        loadingScreen.SetActive(true);
        Invoke("Change_Scene", 5f);
        
    }

    public void OnClickLevelBtn()
    {
        for (int i = 0; i <= unlockedLevels; i++)
        {
            if (i == Current_Level)
            {
                Levels[i].gameObject.transform.GetChild(0).gameObject.SetActive(true);
            }

            else
            {
                Levels[i].gameObject.transform.GetChild(0).gameObject.SetActive(false);
            }

        }
    }

    public void Change_Scene()
    {
        GameManager.Instance.Change_Scene("GamePlay");
    }
}
