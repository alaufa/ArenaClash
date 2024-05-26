using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHitbox : MonoBehaviour
{
    public float baseKnockbackForce = 5f; // Base force of the knockback

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.gameObject != this.gameObject)
        {
            Vector2 knockbackDirection = (other.transform.position - transform.position).normalized;
            other.GetComponent<PlayerStatus>().TakeHit(knockbackDirection, baseKnockbackForce);
        }
    }
}

