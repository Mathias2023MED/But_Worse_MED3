using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandAnimation : MonoBehaviour
{
    private Animator mAnimator;
    private Renderer lightningRenderer;
    [SerializeField] float startDelay = 1.0f;
    [SerializeField] float activeTime = 1f;

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
                }
            }
        }
    }

    public void DeactivateLightning()
    {
        if (lightningRenderer != null)
        {
            lightningRenderer.enabled = false;
            mAnimator.ResetTrigger("Trshoot");
        }
    }

    private IEnumerator DeactivateLightningAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        DeactivateLightning();
    }

    private IEnumerator ActivateLightningWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        lightningRenderer.enabled = true;
        StartCoroutine(DeactivateLightningAfterDelay(activeTime)); 
    }
}
