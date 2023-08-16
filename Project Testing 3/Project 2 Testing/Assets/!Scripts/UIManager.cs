using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{   
    public static UIManager Instance;
    public GameObject PausePanel, MobInput;
    public GameObject Level_Complete;
    public GameObject Level_Failed;
    public GameObject loading;
    int levelIndex;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    public void ShowPausePanel()
    {
        Time.timeScale = 0;
        AudioListener.pause = true;
        PausePanel.gameObject.SetActive(true);
    }
    public void ShowCompletePanel()
    {
        //AdsManager._INSTANCE.SHOW_INTERSTITIAL_AD();
       GameManager.Instance.LevelNo += 1;
       if (GameManager.Instance.LevelNo > PlayerPrefs.GetInt("NextLevel"))
        {
            PlayerPrefs.SetInt("NextLevel", GameManager.Instance.LevelNo);
        }
        Level_Complete.gameObject.SetActive(true);
    }
    public void ShowLevelFailed()
    {
        Time.timeScale = 0;
        Level_Failed.gameObject.SetActive(true);
        
    }
    public void OnClickNextButton()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        Level_Complete.gameObject.SetActive(false);
        loading.gameObject.SetActive(true);
        Invoke("GamplayScene", 5f);
    }
    public void OnClickHome()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        Level_Complete.gameObject.SetActive(false);
        loading.gameObject.SetActive(true);
        Invoke("MainMenuScene", 0f);
    }
    public void Restart()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        GameManager.Instance.LevelNo -= 1;
        Level_Complete.gameObject.SetActive(false);
        loading.gameObject.SetActive(true);
        Invoke("GamplayScene", 3f);
    }
    public void Resume()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        PausePanel.gameObject.SetActive(false);
    }
    public void Replay()
    {
        PausePanel.gameObject.SetActive(false);
        loading.gameObject.SetActive(true);
        Invoke("GamplayScene",0f);
        Time.timeScale = 1;
        AudioListener.pause = false;
    }
    public void MainMenuScene()
    {
        GameManager.Instance.Change_Scene("MainMenu");
    }
    public void GamplayScene()
    {
        GameManager.Instance.Change_Scene("GamePlay");
    }
}
