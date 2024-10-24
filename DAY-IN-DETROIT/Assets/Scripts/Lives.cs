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

    private int _health;
    private int _hearts;
    private int _healthPerHeart;

    public void LivesSetup(int health)
    {
        if (health % 3 != 0)
        {
            health -= health % 3;
        }
        if (health < 0)
        {
            health = 3;
        }
        this._hearts = 3;
        this._health = health;
        this._healthPerHeart = health / 3;
    }
    public void UpdateHealth(int health)
    {
        this._health = health;
        if (this._health <= 0)
        {
            this._hearts = 0;
            Destroy(life3);
            scenesScript.PlayerDeath();
        }
        else if (this._health > 0 && this._health <= this._healthPerHeart)
        {
            this._hearts = 1;
            Destroy(life2);
        }
        else if (this._hearts > this._healthPerHeart && this._hearts <= _healthPerHeart * 2) {
            this._hearts = 2;
            Destroy(life1);
            Debug.Log("Destroyed life1");
        }
    }
    public int GetHealth()
    {
        return this._health;
    }
    public int GetHearts()
    {
        return this._hearts;
    }

    // Start is called before the first frame update
    void Start()
    {
        this.LivesSetup(6);
        Debug.Log(this._healthPerHeart);
        Destroy(life1);
    }

    void Update()
    {
        this.UpdateHealth(this._health);
    }

    //public void Update()
    //{
    //    // Debug.Log(GetHearts());
    //    switch (GetHealth()) // most slipshod code ever but it works well and i can't really think of a better way to do this
    //    {
    //        case 3:
    //            life1.gameObject.SetActive(true);
    //            life2.gameObject.SetActive(true);
    //            life3.gameObject.SetActive(true);
    //            break;
    //        case 2:
    //            life1.gameObject.SetActive(true);
    //            life2.gameObject.SetActive(true);
    //            life3.gameObject.SetActive(false);
    //            break;
    //        case 1:
    //            life1.gameObject.SetActive(true);
    //            life2.gameObject.SetActive(false);
    //            life3.gameObject.SetActive(false);
    //            break;
    //        case 0:
    //            life1.gameObject.SetActive(false);
    //            life2.gameObject.SetActive(false);
    //            life3.gameObject.SetActive(false);
    //            Debug.Log("the player should be dead but i don't know how the scene changer works so someone replace this with code that sends you to the game over screen");
    //            break;
    //    }
    //}

}
