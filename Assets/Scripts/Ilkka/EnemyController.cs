using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Controller, IController
{
    int health;
    float moveSpeed;

    public GameObject arrowPrefab;
    public GameObject soulPrefab;

    Vector2 playerPos;
    Vector2 thisPos;
    Quaternion arrowRotation;
    float shootRadius = 15;
    float meleeRadius = 5;

    float shootForce = 2;
    bool canShoot = true;
    bool canMelee = true;
    bool meleeRange = false;

    public LayerMask playerLayer;

    public Animator anim;
    public GameObject hpbar;
    public HealthbarScript hpscript;
    

    private void Start()
    {
        health = 4;
        moveSpeed = 7;
        hpscript.setMaxHealth(health); 
    }

    void Update()
    {
        //random movement
        DetectPlayer();

    }
    
    public void TakeDamage()
    {
        // Currently 1 hit == one damage point and hit type does not matter.
        // TODO: rewrite this to vary damage according to hit so the powerattack
        // does more damage

        health -= 1;
        hpscript.setHealth(health);
        //play sound, animation, particles
        if (health <= 0)
        {
            Instantiate(soulPrefab, this.transform.position + (transform.up * -2), Quaternion.identity);
            //death sound, animation, particles
            Destroy(this.gameObject);
        }
    }

    public void DetectPlayer()
    {
        Collider2D Collidermelee = Physics2D.OverlapCircle(this.transform.position, meleeRadius, playerLayer);
        {
            if (Collidermelee != null)
            {
                meleeRange = true;
                if (canMelee)
                {
                    canMelee = false;
                    anim.SetTrigger("Melee");
                    StartCoroutine(MeleeTimer());
                }
            }
            else meleeRange = false;
        }

        if (!meleeRange)
        {
            Collider2D ColliderRanged = Physics2D.OverlapCircle(this.transform.position, shootRadius, playerLayer);
            {
                if (canShoot && ColliderRanged != null)
                {
                    playerPos = ColliderRanged.gameObject.transform.position + (transform.up * 5);
                    thisPos = this.gameObject.transform.position;
                    Debug.Log("Player in sight");
                    canShoot = false;
                    ShootArrow();
                    StartCoroutine(ArrowTimer());
                }
            }
        }

    }

    void ShootArrow()
    {
        //PArticle etc to warn player
        //animation
        if (playerPos.x > thisPos.x)
        {
            arrowRotation = Quaternion.Euler(new Vector3(0, 0, -90));
        }
        else arrowRotation = Quaternion.Euler(new Vector3(0, 0, 90));

        GameObject arrowFlight = Instantiate(arrowPrefab, this.transform.position, arrowRotation);
        var arrowRB = arrowFlight.GetComponent<Rigidbody2D>();
        arrowRB.AddForce((playerPos - thisPos) * shootForce, ForceMode2D.Impulse);
    }

    IEnumerator ArrowTimer()
    {
        yield return new WaitForSeconds(5f);
        canShoot = true;
    }
    IEnumerator MeleeTimer()
    {
        yield return new WaitForSeconds(1f);
        canMelee = true;
    }

    // this method is broken because the staff is a trigger and not a collider, it is pointless and arse
    public override void handleCollision(Collision2D collision)
    {
        if (collision.collider.CompareTag("Staff"))
        {
            TakeDamage();
            Debug.Log("Enemy took a hit");
        }
    }

    public override void handleTrigger() 
    {
        Debug.Log("Made it to the enemy controller");
        TakeDamage();
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, shootRadius);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, meleeRadius);
    }
}

