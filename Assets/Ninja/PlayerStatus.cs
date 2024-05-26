using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public int hitsTaken = 0; // Number of times the player has been hit
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void TakeHit(Vector2 knockbackDirection, float baseKnockbackForce)
    {
        hitsTaken++;
        ApplyKnockback(knockbackDirection, baseKnockbackForce);
    }

    void ApplyKnockback(Vector2 direction, float baseForce)
    {
        float knockbackForce = baseForce * (1 + hitsTaken * 0.1f); // Scale the knockback force
        rb.AddForce(direction * knockbackForce, ForceMode2D.Impulse);
    }

    void Die()
    {
        // Handle player out-of-bounds (e.g., respawn or end game)
        Debug.Log("Player knocked out!");
    }
}

