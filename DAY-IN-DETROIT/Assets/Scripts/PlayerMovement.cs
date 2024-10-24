using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed; // no value assigned as you can do that in the unity object
    public float herbMeter = 0;
    public float maxHerb = 4;
    bool dashing = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D rigid = GetComponent<Rigidbody2D>(); // unused atm but i'm leaving it in
        Vector2 pos = transform.position;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            pos.x -= (speed + herbMeter) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            pos.x += (speed + herbMeter) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            pos.y += (speed + herbMeter) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))  
        {
            pos.y -= (speed + herbMeter) * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.S) & dashing == false) // have to use keydown here because getkey runs every single frame
        {
            StartCoroutine(Dash(5));
        }
        
        transform.position = pos;

        if (herbMeter > 0) // (do this later) an afterimage effect on the player when this is active would be cool
        {
            // Debug.Log(herbMeter);
            herbMeter -= 0.2f * Time.deltaTime;
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.CompareTag("Herb"))
        {
            Debug.Log("herb touched");
            herbMeter = maxHerb;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("enemy touched");
        }

    }


    IEnumerator Dash(int speedincrease)
    {
        speed += speedincrease;
        dashing = true;
        yield return new WaitForSeconds(0.5f);
        speed -= speedincrease;
        yield return new WaitForSeconds(0.5f); // cooldown on the dash
        dashing = false;
    }
}
