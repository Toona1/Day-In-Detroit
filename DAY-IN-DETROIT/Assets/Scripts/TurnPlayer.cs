using UnityEngine;

public class ShootingPointRotation : MonoBehaviour
{
    public Transform shootingPoint; // Reference to the shooting point
    public float rotationAmount = 45f; // Amount to rotate left or right

    private bool isFacingRight = true; // Track the current facing direction of the shooting point

    void Update()
    {
        // If the right arrow is pressed and shooting point is not already facing right
        if (Input.GetKeyDown(KeyCode.RightArrow) && !isFacingRight)
        {
            // Rotate the shooting point to face right
            shootingPoint.rotation = Quaternion.Euler(0, 0, 0); // Facing forward (adjust as needed)
            isFacingRight = true; // Update the state
        }

        // If the left arrow is pressed and shooting point is not already facing left
        if (Input.GetKeyDown(KeyCode.LeftArrow) && isFacingRight)
        {
            // Rotate the shooting point to face left
            shootingPoint.rotation = Quaternion.Euler(0, 180, 0); // Facing left (adjust as needed)
            isFacingRight = false; // Update the state
        }
    }
}
