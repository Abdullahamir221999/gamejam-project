using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public Text moneyText;
    public MoneyManager moneyManager;

    private void Start()
    {
        moneyManager = FindObjectOfType<MoneyManager>();
        UpdateMoneyText();
    }

    public void UpdateMoneyText()
    {
        if (moneyManager != null && moneyText != null)
        {
            moneyText.text = "Money: " + moneyManager.PlayerMoney.ToString();
        }
    }
}
