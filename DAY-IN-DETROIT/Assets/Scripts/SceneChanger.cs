using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    // Runs when "play" button pressed
    public void PlayGame()
    {
        SceneManager.LoadScene("GamePlay1");
    }

    // Runs when "try again" or "play again" buttons prssed
    public void EnterMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    // Runs when player health reaches zero
    public void PlayerDeath()
    {
        SceneManager.LoadScene("Game Over");
    }

    // Runs when player get home
    public void PlayerWin()
    {
        SceneManager.LoadScene("Win");
    }
}
