using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100f; // Enemy's health  

    public void TakeDamage(float damage)
    {
        health -= damage;
        Animator animator = GetComponent<Animator>();
        if (animator != null && health > 19)
        {
            StartCoroutine(PlayTakeDamageAnimationTwice(animator));
        }
        if (health <= 0)
        {
            Die();
        }
    }

    IEnumerator PlayTakeDamageAnimationTwice(Animator animator)
    {
        animator.SetTrigger("take_damage");
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        animator.SetTrigger("take_damage");
    }

    void Die()
    {
        // Handle enemy death (e.g., play death animation, destroy object, etc.)  
        Debug.Log("Enemy died!");
        Animator animator = GetComponent<Animator>();
        if (animator != null)
        {
            animator.SetTrigger("death");
        }
        Destroy(gameObject, 2f); // Delay the destruction to allow the death animation to play  
    }
}

