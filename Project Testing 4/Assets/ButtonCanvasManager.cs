using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCanvasManager : MonoBehaviour
{
    public GameObject[] ButtonLeft;
    public GameObject[] ButtonRight;
    public GameObject[] ButtonMid;
    // Start is called before the first frame update
    void Start()
    {
        ButtonsAtLevels();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ButtonsAtLevels()
    {
        bool t = true;
        bool f = false;
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

}
