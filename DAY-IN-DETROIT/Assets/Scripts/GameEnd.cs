using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
    // Referance to scenes class 
    public Scenes scenes;

    // Goes to win screen when player reaches home
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            scenes.PlayerWin();
        }
    }
}
