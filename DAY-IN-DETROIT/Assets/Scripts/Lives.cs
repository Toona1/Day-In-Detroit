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

    public Lives(int health)
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
    public void SetHealth(int health)
    {
        this._health = health;
        if (this._health <= 0)
        {
            this._hearts = 0;
        }
        else if (this._health > 0 && this._health <= this._healthPerHeart)
        {
            this._hearts = 1;
        }
        else if (this._hearts > this._healthPerHeart && this._hearts <= _healthPerHeart * 2) {
            this._hearts = 2;
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
        Lives lives = new Lives(6);
    }

}
