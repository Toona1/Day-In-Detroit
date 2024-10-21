using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyCounter : MonoBehaviour
{
    public int money = 0; // Starting money value
    public Text moneyText; // Reference to the UI Text

    void Start()
    {
        UpdateMoneyText(); // Initialize the money display
    }

    // Call this method to add money
    public void AddMoney(int amount)
    {
        money += amount;
        UpdateMoneyText();
    }

    // Call this method to deduct money
    public void DeductMoney(int amount)
    {
        money -= amount;
        if (money < 0)
            money = 0; // Ensure the money doesn't go negative
        UpdateMoneyText();
    }

    // Update the displayed money
    void UpdateMoneyText()
    {
        moneyText.text = "Money: " + money.ToString();
    }
}
