using UnityEngine;

public class ShootingPointRotation : MonoBehaviour
{
    public Transform shootingPoint; // Reference to the shooting point
    public float rotationAmount = 45f; // Amount to rotate left or right

    private bool isFacingRight = true; // Track the current facing direction of the shooting point

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) && !isFacingRight)
        {
            shootingPoint.rotation = Quaternion.Euler(0, 0, 0);
            isFacingRight = true; 
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && isFacingRight)
        {
            shootingPoint.rotation = Quaternion.Euler(0, 180, 0); 
            isFacingRight = false;
        }
    }
}
