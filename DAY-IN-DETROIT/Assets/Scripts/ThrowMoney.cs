using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThrowMoney : MonoBehaviour
{
    public Transform shootingPoint; // Where the bullet will be instantiated
    public GameObject bulletPrefab; // The prefab for the bullet
    public float speed = 10f; // Speed of the bullet
    public bool isFacingRight = true; // Variable to determine the facing direction
    public int costPerShot = 1; // Cost to shoot, set to 1

    void Update()
    {
        // Update isFacingRight based on player input
        HandleInput();

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Shoot();
        }
    }

    void HandleInput()
    {
        float moveInput = Input.GetAxis("Horizontal");
        isFacingRight = moveInput > 0; // Set based on movement input
    }

    void Shoot()
    {
        // Check if there's enough money before shooting
        if (MoneyCounter.instance != null && MoneyCounter.instance.GetTotalCash() >= costPerShot)
        {
            // Deduct money for the shot
            MoneyCounter.instance.DeductCash(costPerShot);

            // Instantiate the bullet and set its position
            GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, Quaternion.identity);

            // Get the Rigidbody2D component of the bullet
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();

            if (bulletRb != null)
            {
                // Determine the shoot direction based on isFacingRight
                Vector2 shootDirection = isFacingRight ? Vector2.right : Vector2.left;

                // Set the bullet's velocity
                bulletRb.velocity = shootDirection * speed;

                // Optionally, rotate the bullet to face the shoot direction
                float angle = isFacingRight ? 0f : 180f; // 0 for right, 180 for left
                bullet.transform.rotation = Quaternion.Euler(0, 0, angle);
            }
        }
        else
        {
            Debug.Log("Not enough money to shoot!");
        }
    }
}
