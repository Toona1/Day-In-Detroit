using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    //Runs when "play" button pressed
    public void PlayGame()
    {
        SceneManager.LoadScene("Street");
    }

    //Runs when "try again" or "play again" buttons prssed
    public void EnterMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    //Runs when player health reaches zero
    public void PlayerDeath()
    {
        SceneManager.LoadScene("Death Screen");
    }

    //Runs when player get home with positive money
    public void PlayerWin()
    {
        SceneManager.LoadScene("Win Screen");
    }
}
