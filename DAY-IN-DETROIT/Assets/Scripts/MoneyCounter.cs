using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyCounter : MonoBehaviour
{
    public static MoneyCounter instance;

    private int totalCash;
    public TMP_Text cashText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void IncreaseCash(int amount)
    {
        totalCash += amount;
        UpdateCashUI();
    }

    public void DeductCash(int amount)
    {
        totalCash -= amount;
        UpdateCashUI();
        Debug.Log("Cash deducted! Current balance: " + totalCash);
    }

    public int GetTotalCash()
    {
        return totalCash;
    }

    private void UpdateCashUI()
    {
        cashText.text = "Cash: " + totalCash.ToString();
    }
}
