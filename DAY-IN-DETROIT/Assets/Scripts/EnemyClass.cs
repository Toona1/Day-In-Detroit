using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyClass : MonoBehaviour // class and class variables
{
    public GameObject player;
    private int _health;
    private float _speed;
    private float _distance;
    private Rigidbody2D body;
    private SpriteRenderer spriteRenderer;
    MoneyCounter money;

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

    public float GetDistance()
    {
        return _distance;
    }

    public void SetHealth(int health)
    {
        _health = health;
    }

    public void SetSpeed(int speed)
    {
        _speed = speed;
    }

    public void SetDistance(float distance)
    {
        _distance = distance;
    }

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        // money = GameObject.FindGameObjectWithTag("Money").GetComponent<MoneyCounter>();

        SetHealth(Random.Range(2, 4)); // randomly sets the health of the enemy (might change or remove this later)
        SetSpeed(Random.Range(3, 6)); // randomly sets the speed of the enemy that's moving towards you
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(GetDistance());
        SetDistance(Vector2.Distance(transform.position, player.transform.position)); // code to make the enemy follow and turn to the player

        //if (GetDistance() > 0f)
        //{
        //    spriteRenderer.flipX = false;
        //}
        //if (GetDistance() < 0f)
        //{
        //    spriteRenderer.flipX = true;
        //}

        //Vector2 direction = player.transform.position - transform.position;
        //direction.Normalize();
        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, GetSpeed() * Time.deltaTime);
        //transform.rotation = Quaternion.Euler(Vector3.forward * angle); // might comment this part out later because i don't know how the art is gonna look so i'm not sure if this is going to work well with it
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // money.IncreaseCash(-20);
            Destroy(this.gameObject); // this does not drop money (whoever's setting up the code to actually kill the enemies make sure this section doesn't drop money)
        }
    }

}
