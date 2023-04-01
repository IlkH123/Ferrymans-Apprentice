using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestiEläKäytä : MonoBehaviour
{

    private Rigidbody2D rb;
    private BoxCollider2D bc;
    public Animator animator;
    public TestiEläkäytä2 testi;
    private GameObject currentSoul;


    float moveSpeed;
    float currentSpeed;
    float jumpForce;
    [SerializeField] public bool isGround;
    [SerializeField] public bool attacking = false;
    [SerializeField] public bool blocking = false;
    [SerializeField] public bool doubleJump = false;
    [SerializeField] public bool soulClose = false;
    [SerializeField] public bool collecting = false;
    [SerializeField] public bool isCrouching = false;
    [SerializeField] public bool isMoving = false;

    private int health;
    private int maxHealth;
    public int souls;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponentInChildren<BoxCollider2D>();
        animator = GetComponentInChildren<Animator>();
        //jump = GetComponent<AudioSource>();


        rb.freezeRotation = true;
        moveSpeed = 5;
        jumpForce = 8;
        isGround = true;

        health = 5;
        maxHealth = health;
        souls = 0;
        currentSpeed = moveSpeed;
    }

    void Update()
    {
        if (!collecting && !attacking)
        {
            
            if (Input.GetKey(KeyCode.Mouse0) && !blocking)
            {   
                Attack();
            }

            if (Input.GetKey(KeyCode.Mouse1))
            {
                Block();
            }
            else
            {
                blocking = false;
                animator.SetBool("blocking", false);
            }

            if (Input.GetKeyDown(KeyCode.E) && isGround && soulClose)
            {    
                CollectSoul();
            }

            if (Input.GetKeyDown(KeyCode.K))
            {
                animator.SetTrigger("powerAttack"); //because i can xd
            }

            if (Input.GetKeyDown(KeyCode.Space) && isGround)
            {
                rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
                animator.SetBool("isCrouching", false);
                animator.SetBool("isCrouchWalking", false);
                animator.SetTrigger("jump");
                isGround = false;
                StartCoroutine(DoubleJumpTimer());
                //sound
            }
            if (Input.GetKeyDown(KeyCode.Space) && doubleJump)
            {
                doubleJump = false;
                rb.AddForce(transform.up * jumpForce * 0.5f, ForceMode2D.Impulse);
                animator.SetTrigger("doubleJump");
            }
        }

        if(Input.GetKey(KeyCode.S) && !collecting && isGround)
        {
            isCrouching = true;
            animator.SetBool("isCrouching", true);
            currentSpeed = moveSpeed * 0.75f;
        }
        else
        {
            isCrouching = false;
            animator.SetBool("isCrouching", false);
            currentSpeed = moveSpeed;
            if(isMoving)
            {
                animator.SetBool("isCrouchWalking", false);
                animator.SetBool("isWalking", true);
            }
        }

    }
    void FixedUpdate()
    {

        if (!collecting && !blocking)
        {
            //Addforce + drag, airdrag = 0
            if (Input.GetKey(KeyCode.D))
            {
                this.transform.eulerAngles = new Vector3(0, 0, 0); // Flipped
                rb.transform.Translate(new Vector3(1, 0, 0) * currentSpeed * Time.deltaTime);
                isMoving = true;
                if (isCrouching)
                {
                    animator.SetBool("isCrouchWalking", true);
                }
                else
                {
                    animator.SetFloat("walkMultiplier", 1f);
                    animator.SetBool("isWalking", true);
                }

                //sound
            }
            else if (Input.GetKey(KeyCode.A))
            {

                this.transform.eulerAngles = new Vector3(0, 180, 0);
                rb.transform.Translate(new Vector3(1, 0, 0) * currentSpeed * Time.deltaTime);
                isMoving = true;
                if (isCrouching)
                {
                    animator.SetBool("isCrouchWalking", true);
                }
                else
                {
                    animator.SetFloat("walkMultiplier", -1f);
                    animator.SetBool("isWalking", true);
                }

                //sound
            }
            else
            {
                isMoving = false;
                animator.SetBool("isWalking", false);
                animator.SetBool("isCrouchWalking", false);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            isGround = true;
            doubleJump = false;
        }

        if (col.gameObject.CompareTag("Health") && health < maxHealth)
        {
            Destroy(col.gameObject);
            health += 2;
            Debug.Log("Healed, HP: " + health);
            //particles
            if (health > maxHealth)
            {
                health = maxHealth;
                //RefreshUI();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Soul"))
        {
            soulClose = true;
            currentSoul = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Soul") && !collecting)
        {
            soulClose = false;
            currentSoul = null;
        }
    }

    private void Attack()
    {
        blocking = false;
        attacking = true;
        if(isCrouching)
        {
            animator.SetTrigger("crouchAttack");
        }
        else animator.SetTrigger("attack");

        //sound
    }
    public void AttackReset()
    {
        attacking = false;
    }

    public void Block()
    {
        //anim, particle?
        blocking = true;
        animator.SetBool("blocking", true);
    }

    public void TakeDamage()
    {

        health -= 1;
        Debug.Log("I've taken damage! HP: " + health);
        animator.SetTrigger("takeDamage");
        //RefreshUI;
        //anim, particles, sound
        if (health <= 0)
        {
            //GameOver
            animator.SetBool("playerDead", true);
        }
    }

    void CollectSoul()
    {
        currentSpeed = 0;
        collecting = true;
        animator.SetTrigger("collectSoul");
        StartCoroutine(CollectReset());
        //particles, sound, animation for soul    
    }
    IEnumerator CollectReset()
    {
        yield return new WaitForSeconds(2f);
        Destroy(currentSoul.gameObject);
        collecting = false;
        currentSpeed = moveSpeed;   
        souls += 1;
        Debug.Log(souls);
    }

    IEnumerator DoubleJumpTimer()
    {
        yield return new WaitForSeconds(0.2f);
        doubleJump = true;
        yield return new WaitForSeconds(0.8f);
        doubleJump = false;
    }
}



