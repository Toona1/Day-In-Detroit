using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed; // no value assigned as you can do that in the unity object
    public float herbMeter = 0;
    public float maxHerb = 4;
    public bool dashing = false;
    public bool punching = false;

    bool canBeHit = true;
    Lives health;

    public Animator anim;
    
    
    // Start is called before the first frame update
    void Start()
    {
        health = GameObject.FindGameObjectWithTag("Lives").GetComponent<Lives>();
        //health.UpdateHealth(3);
        // health.SetHealth(health.GetHealth() - 1); //testing if it works
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D rigid = GetComponent<Rigidbody2D>(); // unused atm but i'm leaving it in
        Vector2 pos = transform.position;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            pos.x -= (speed + herbMeter * 2) * Time.deltaTime;
            anim.SetFloat("Speed", 0.06f);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            pos.x += (speed + herbMeter * 2) * Time.deltaTime;
            anim.SetFloat("Speed", 0.06f);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            pos.y += (speed + herbMeter * 2) * Time.deltaTime;
            anim.SetFloat("Speed", -0.06f);
        }
        if (Input.GetKey(KeyCode.DownArrow))  
        {
            pos.y -= (speed + herbMeter * 2) * Time.deltaTime;
            anim.SetFloat("Speed", -0.06f);
        }
        
        if (Input.GetKeyDown(KeyCode.S) & dashing == false) // have to use keydown here because getkey runs every single frame
        {
            StartCoroutine(Dash(3, true));
        }
        if (Input.GetKey(KeyCode.D) & (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))) 
        {
            StartCoroutine(Punch(false));
        }
        if (Input.GetKey(KeyCode.D) & Input.GetKey(KeyCode.DownArrow)) 
        {
            StartCoroutine(Punch(true));
        }

        transform.position = pos;

        if (herbMeter > 0)
        {
            // Debug.Log(herbMeter);
            herbMeter -= 0.5f * Time.deltaTime;
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Herb"))
        {
            //Debug.Log("herb touched");
            herbMeter = maxHerb;
        }
        if (collision.gameObject.CompareTag("Enemy") && canBeHit == true) 
        {
            //Debug.Log("enemy touched");
            Debug.Log(health.GetHealth());
            health.UpdateHealth(health.GetHealth() - 1);
            StartCoroutine(Invincible(.25f));
        }

    }

    IEnumerator Dash(int speedincrease, bool direction)
    {
        if (direction == true) {
            speed += speedincrease;
            dashing = true;
            anim.SetBool("IsDashing", true);
            yield return new WaitForSeconds(0.5f);
            speed -= speedincrease;
            anim.SetBool("IsDashing", false);
            yield return new WaitForSeconds(2f); // cooldown on the dash
            dashing = false;
        } else if (direction == false){
            speed += speedincrease;
            dashing = true;
            anim.SetBool("IsDashing 0", true);
            yield return new WaitForSeconds(0.5f);
            speed -= speedincrease;
            anim.SetBool("IsDashing 0", false);
            yield return new WaitForSeconds(2f); // cooldown on the dash
            dashing = false;
        }
        yield return new WaitForSeconds(3);
    }

    IEnumerator Invincible(float time)
    {
        canBeHit = false;
        yield return new WaitForSeconds(time);
        canBeHit = true;
    }

    IEnumerator Punch(bool direction)
    {
        canBeHit = false;
        if (direction == true) {
            punching = true;
            anim.SetBool("IsPunch", true);
            yield return new WaitForSeconds(1f);
            yield return new WaitForSeconds(1f); // cooldown on the dash
            punching = false;
            anim.SetBool("IsPunch", false);
        } else {
            punching = true;
            anim.SetBool("IsPunch 0", true);
            yield return new WaitForSeconds(1f);
            yield return new WaitForSeconds(1f); // cooldown on the dash
            punching = false;
            anim.SetBool("IsPunch 0", false);
        }
        canBeHit = true;
    }

}

