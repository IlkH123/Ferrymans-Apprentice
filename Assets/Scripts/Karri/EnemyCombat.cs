using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public float meleeRange = 1.5f; // distance for melee attack
    public float shootingRange = 5f; // distance for shooting attack
    public float shootingInterval = 2f; // interval between shots
    public GameObject bulletPrefab; // prefab for bullet object

    private Transform playerTransform;
    private float timeLeftToShoot;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        timeLeftToShoot = 0f;
    }

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, playerTransform.position);

        if (distanceToPlayer < meleeRange)
        {
            // Perform melee attack
            MeleeAttack();
        }
        else if (distanceToPlayer < shootingRange)
        {
            // Aim at player and possibly shoot
            AimAndShoot();
        }
    }

    private void MeleeAttack()
    {
        // Perform melee attack logic
        Debug.Log("Performing melee attack!");
    }

    private void AimAndShoot()
    {
        // Aim at player
        Vector2 directionToPlayer = playerTransform.position - transform.position;
        transform.up = directionToPlayer;

        // Check if ready to shoot
        if (timeLeftToShoot <= 0f)
        {
            // Shoot bullet
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.velocity = directionToPlayer.normalized * 10f; // set bullet velocity

            // Reset shooting timer
            timeLeftToShoot = shootingInterval;
        }
        else
        {
            // Decrement shooting timer
            timeLeftToShoot -= Time.deltaTime;
        }
    }
}