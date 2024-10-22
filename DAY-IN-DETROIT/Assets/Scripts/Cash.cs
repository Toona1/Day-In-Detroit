using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cash : MonoBehaviour
{
    public int value; // Value of this cash object

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object colliding with the cash has the Player tag
        if (other.gameObject.CompareTag("Player"))
        {
            // Destroy the cash object and add its value to the player's total cash
            MoneyCounter.instance.IncreaseCash(value);
            Destroy(gameObject); 
        }
    }
}
