using UnityEngine;

public class FireRateUpgradeButton : MonoBehaviour
{
    public int upgradeCost = 1; // Cost of the upgrade
    public float newShootingCooldown; // The upgraded shooting cooldown

    public void ApplyUpgrade()
    {
        
        //Deduct the cost of the upgrade from the player's money.
        MoneyManager moneyManager = FindObjectOfType<MoneyManager>();
        if (moneyManager != null)
        {
            if (moneyManager.DeductMoney(upgradeCost))
            {
                PlayerPrefs.SetFloat("cooldown", newShootingCooldown);
            }
            else
            {
                Debug.Log("Not enough money to buy the upgrade.");
            }
        }
    }
}
