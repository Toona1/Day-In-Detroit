using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyCounter : MonoBehaviour
{
    public static MoneyCounter instance; // Singleton instance

    private int totalCash; // Player's total cash
    public TMP_Text cashText; // Reference to the UI text to display cash amount

    private void Awake()
    {
        // Ensure only one instance of MoneyCounter exists
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Method to increase the player's total cash
    public void IncreaseCash(int amount)
    {
        totalCash += amount;
        UpdateCashUI();
    }

    // Update the UI with the current cash value
    private void UpdateCashUI()
    {
        cashText.text = "Cash: " + totalCash.ToString();
    }
}
