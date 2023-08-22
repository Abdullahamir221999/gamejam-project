using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayHandler : MonoBehaviour
{
    public static GamePlayHandler Instance;
    public GTA_LevelInfo[] Gta_Levels;
    [HideInInspector] public int Gta_Levelno;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {
        Gta_Levelno = PlayerPrefs.GetInt("NextLevel"); //GameManager.Instance.LevelNo;
        ActiveLevel();
        Debug.Log(Gta_Levelno + "=gameplayindex");
    }
    
    public void ActiveLevel()
    {
        for(int i = 0; i <= Gta_Levels.Length-1; i++)
        {
            if(i == Gta_Levelno)
            {
                Debug.Log("level value" + Gta_Levelno);
                Gta_Levels[i].Level.gameObject.SetActive(true);
            }
            else
            {
                Gta_Levels[i].Level.gameObject.SetActive(false);
            }
        }
    }
  
}

[System.Serializable]
public class GTA_LevelInfo
{
    public GameObject Level;
}