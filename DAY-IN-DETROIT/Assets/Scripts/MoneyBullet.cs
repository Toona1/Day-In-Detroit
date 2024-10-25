using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyClass enemy = collision.GetComponent<EnemyClass>();
        if (enemy != null)
        {
            enemy.Disappear(); // Call the method to make the enemy disappear
            Destroy(gameObject); // Destroy the bullet
        }
    }
}
