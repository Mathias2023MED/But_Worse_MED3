using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100f; // Enemy's health

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Handle enemy death (e.g., play death animation, destroy object, etc.)
        Debug.Log("Enemy died!");
        Destroy(gameObject); // For simplicity, destroy the enemy when health reaches 0
    }
}

