using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandAnimation : MonoBehaviour
{
    private Animator mAnimator;
    private Renderer lightningRenderer;
    [SerializeField] float startDelay = 1.0f;
    [SerializeField] float activeTime = 1f;

    public float damage = 10f; // Amount of damage to deal
    public float range = 100f; // Maximum range of the raycast
    public Camera playerCamera; // Reference to the player's camera
    public LayerMask hitLayer; // Layers the raycast should check (ignore non-enemy objects)

    // Start is called before the first frame update
    void Start()
    {
        mAnimator = GetComponent<Animator>();
        GameObject lightningParticleSystem = GameObject.FindGameObjectWithTag("Lightning");
        if (lightningParticleSystem != null)
        {
            lightningRenderer = lightningParticleSystem.GetComponent<Renderer>();
            if (lightningRenderer != null)
            {
                lightningRenderer.enabled = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (mAnimator != null)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                mAnimator.SetTrigger("Trshoot");
               
                if (lightningRenderer != null)
                {
                    StartCoroutine(ActivateLightningWithDelay(startDelay)); // Delay start by 1 second
                    FireRaycast();
                }
            }
        }
    }

    public void DeactivateLightning()
    {
        if (lightningRenderer != null)
        {
            lightningRenderer.enabled = false;
            mAnimator.SetTrigger("Tridle");
        }
    }

    private IEnumerator DeactivateLightningAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        DeactivateLightning();
        //mAnimator.ResetTrigger("Trshoot");
    }

    private IEnumerator ActivateLightningWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        lightningRenderer.enabled = true;
        StartCoroutine(DeactivateLightningAfterDelay(activeTime));
        
    }

    void FireRaycast()
    {
        // Shoot a ray from the camera's forward direction
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;

        // Draw the ray in the scene view for debugging purposes
        Debug.DrawRay(ray.origin, ray.direction * range, Color.red, 2.0f);

        if (Physics.Raycast(ray, out hit, range, hitLayer))
        {
            // Check if the ray hits an object with the "Enemy" tag
            if (hit.collider.CompareTag("Enemy"))
            {
                // Log the hit for testing purposes
                Debug.Log("Enemy hit!");

                // Get the enemy's health component and apply damage
                EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(damage); // Apply damage to the enemy
                }
            }
        }
    }
}
