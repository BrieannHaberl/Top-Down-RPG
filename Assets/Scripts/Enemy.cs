using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damageAmount = 1; // Amount of damage this enemy deals to the player

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with the player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Get the heart component from the player GameObject
            HeartManager playerHealth = collision.gameObject.GetComponent<HeartManager>();

            // Check if the heard component is not null
            if (playerHealth != null)
            {
                // Deal damage to the player
                playerHealth.TakeDamage(damageAmount);
            }
        }
    }
}
