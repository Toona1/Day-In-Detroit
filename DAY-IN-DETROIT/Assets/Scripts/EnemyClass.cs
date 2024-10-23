using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClass : MonoBehaviour
{
    [SerializeField]
    private int _health;
    [SerializeField]
    private float _speed;

    public EnemyClass(int health, int speed)
    {
        _health = health;
        _speed = speed;
    }

    public int GetHealth()
    {
        return _health;
    }

    public float GetSpeed()
    {
        return _speed;
    }

    public void SetHealth(int health)
    {
        _health = health;
    }

    public void SetSpeed(int speed)
    {
        _speed = speed;
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
