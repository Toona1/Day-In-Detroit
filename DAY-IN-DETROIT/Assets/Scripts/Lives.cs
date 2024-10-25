using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Lives : MonoBehaviour
{
    [SerializeField]
    private GameObject life1, life2, life3;
    public Scenes scenesScript;

    // Lives variables
    private int _health;
    private int _hearts;
    private int _healthPerHeart;

    // Constructor
    public void LivesSetup(int health)
    {
        if (health % 3 != 0)
        {
            health -= (health % 3);
        }
        if (health < 0)
        {
            health = 3;
        }
        this._hearts = 3;
        this._health = health;
        this._healthPerHeart = health / 3;
    }
    // Checks health to see if hearts need to be removed
    public void UpdateHealth(int health)
    {
        this._health = health;
        if (this._health <= 0)
        {
            this._hearts = 0;
            Destroy(life1);
            scenesScript.PlayerDeath();
        }
        else if (this._health <= this._healthPerHeart)
        {
            this._hearts = 1;
            Destroy(life2);
        }
        else if (this._health <= (this._healthPerHeart * 2)) {
            this._hearts = 2;
            Destroy(life3);
        }
    }
    // Getters and setters
    public int GetHealth()
    {
        return this._health;
    }
    public int GetHearts()
    {
        return this._hearts;
    }

    // Initializes
    void Start()
    {
        this.LivesSetup(3);

    }

    void Update()
    {
        //Debug.Log(this.GetHealth());
    }



}
