using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    public int StartingMoney = 0;
    private int playerMoney = 0;
    public Text moneyText;

    private void Start()
    {
        // Load the saved money or set it to the starting value.
        playerMoney = PlayerPrefs.GetInt("EarnedMoney", StartingMoney);
        UpdateMoneyText();
    }

    public int PlayerMoney => playerMoney;

    public void AddMoney(int amount)
    {
        playerMoney += amount;
        UpdateMoneyText();
        SaveMoney();
    }

    public void DeductMoney(int amount)
    {
        if (playerMoney >= amount)
        {
            playerMoney -= amount;
            UpdateMoneyText();
            SaveMoney();
        }
        else
        {
            Debug.Log("Not enough money to deduct: " + amount);
        }
    }

    private void UpdateMoneyText()
    {
        if (moneyText != null)
        {
            moneyText.text = "" + playerMoney.ToString();
        }
    }

    public void SaveMoney()
    {
        PlayerPrefs.SetInt("EarnedMoney", playerMoney);
    }
}
