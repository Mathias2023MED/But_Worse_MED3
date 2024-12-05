using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Troll : MonoBehaviour
{
    private bool isActive = false;
    [SerializeField] private float moveSpeed = 5f;
    private Transform player;
    private Collider enemyCollider;

    void Awake()
    {
        player = GameObject.Find("Player").transform;
        //gameObject.SetActive(false);
        enemyCollider = GetComponent<BoxCollider>();
        ActivateEnemy();
        isActive = true;
    }

    void Update()
    {
        if (isActive)
        {
            MoveTowardsPlayer();
        }
    }

    private void MoveTowardsPlayer()
    {
        Vector3 playerPosition = player.position;
        transform.LookAt(playerPosition);
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    private void ActivateEnemy()
    {
        isActive = true;
        enemyCollider.enabled = true;
    }
}
