using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    public int LevelNo;
    bool gameHasEnded = false;
    public float restartDelay = 1f;
    public GameObject[] ButtonLeft;
    public GameObject[] ButtonRight;
    public GameObject[] ButtonMid;
    public GameObject[] AllEnemies;
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
        ButtonsAtLevels();
    }
    public void Change_Scene(string name)
    {
        SceneManager.LoadScene(name);
    }
    public void ButtonsAtLevels()
    {
        bool t=true;
        bool f=false;
        int lvlNo = GameManager.Instance.LevelNo;
        switch (lvlNo)
        {
            case 0:
                ButtonLeft[0].SetActive(false);
                ButtonLeft[1].SetActive(false);
                ButtonRight[0].SetActive(false);
                ButtonRight[1].SetActive(false);
                ButtonMid[0].SetActive(false);
                ButtonMid[1].SetActive(false);
                Debug.Log("NO BUTTONS");
                break;
            case 1:
                ButtonLeft[0].SetActive(false);
                ButtonLeft[1].SetActive(false);
                ButtonRight[0].SetActive(false);
                ButtonRight[1].SetActive(false);
                ButtonMid[0].SetActive(false);
                ButtonMid[1].SetActive(false);
                Debug.Log("NO BUTTONS");
                break;
            case 2:
                ButtonLeft[0].SetActive(false);
                ButtonLeft[1].SetActive(false);
                ButtonRight[0].SetActive(false);
                ButtonRight[1].SetActive(false);
                ButtonMid[0].SetActive(false);
                ButtonMid[1].SetActive(false);
                Debug.Log("NO BUTTONS");
                break;
            case 3:
                ButtonLeft[0].SetActive(t);
                ButtonLeft[1].SetActive(f);
                ButtonRight[0].SetActive(t);
                ButtonRight[1].SetActive(f);
                ButtonMid[0].SetActive(t);
                ButtonMid[1].SetActive(f);
                Debug.Log("BLUE GREEN RED");
                break;
            case 4:
                ButtonLeft[0].SetActive(f);
                ButtonLeft[1].SetActive(t);
                ButtonRight[0].SetActive(f);
                ButtonRight[1].SetActive(t);
                ButtonMid[0].SetActive(f);
                ButtonMid[1].SetActive(t);
                Debug.Log("turqoiuse purple orange");
                break;
            case 5:
                ButtonLeft[0].SetActive(f);
                ButtonLeft[1].SetActive(t);
                ButtonRight[0].SetActive(f);
                ButtonRight[1].SetActive(t);
                ButtonMid[0].SetActive(t);
                ButtonMid[1].SetActive(f);
                Debug.Log("turqoise purple RED");
                break;
            case 6:
                ButtonLeft[0].SetActive(t);
                ButtonLeft[1].SetActive(f);
                ButtonRight[0].SetActive(t);
                ButtonRight[1].SetActive(f);
                ButtonMid[0].SetActive(f);
                ButtonMid[1].SetActive(t);
                Debug.Log("BLUE GREEN orange");
                break;
            default:
                break;
        }
    }


    public GameObject[] enemiesAtLevel()
    {
        int lvlNo=GameManager.Instance.LevelNo;
        List<GameObject> tempEnemies = new List<GameObject>(); 

        switch(lvlNo)
        {
            case 0:
                tempEnemies.Add(AllEnemies[1]);
                tempEnemies.Add(AllEnemies[1]);
                tempEnemies.Add( AllEnemies[1]);
                Debug.Log("Color Changed to Red all characters");
                break;
            case 1:
                tempEnemies.Add(AllEnemies[2]);
                tempEnemies.Add(AllEnemies[2]);
                tempEnemies.Add(AllEnemies[2]);
                Debug.Log("Color Changed to Green all characters");
                break;
            case 2:
                tempEnemies.Add(AllEnemies[0]);
                tempEnemies.Add(AllEnemies[0]);
                tempEnemies.Add(AllEnemies[0]);
                Debug.Log("Color Changed to Blue all characters");
                break;
            case 3:
                tempEnemies.Add(AllEnemies[1]);
                tempEnemies.Add( AllEnemies[2]);
                tempEnemies.Add(AllEnemies[0]);
                Debug.Log("Color Changed to Red,Green,Blue characters");
                break;
            case 4:
                tempEnemies.Add(AllEnemies[4]);
                tempEnemies.Add(AllEnemies[3]);
                tempEnemies.Add(AllEnemies[5]);
                Debug.Log("Color Changed to Turqoise,Purple,Orange characters");
                break;
            case 5:
               
                tempEnemies.Add(AllEnemies[4]);
                tempEnemies.Add(AllEnemies[1]);
                tempEnemies.Add(AllEnemies[8]);
                tempEnemies.Add(AllEnemies[3]);
                Debug.Log("Color Changed to Red,Purple,turqoise,Big red characters");
                break;
            case 6:
                tempEnemies.Add(AllEnemies[0]);
                tempEnemies.Add(AllEnemies[2]);
                tempEnemies.Add(AllEnemies[5]);
                tempEnemies.Add(AllEnemies[7]);
                Debug.Log("Color Changed to Big Blue,blue,Green,Orange,Big Green characters");
                break;
            default:
                break;
        }



        return tempEnemies.ToArray();

    }

}
