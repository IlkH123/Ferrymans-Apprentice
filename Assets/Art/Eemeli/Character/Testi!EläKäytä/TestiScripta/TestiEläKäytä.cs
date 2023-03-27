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
    private bool isGround;
    private bool attacking = false;
    public bool blocking = false;
    private bool doubleJump = false;
    private bool soulClose = false;
    private bool collecting = false;

    private int health;
    private int maxHealth;
    public int souls;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponentInChildren<BoxCollider2D>();
        animator = GetComponentInChildren<Animator>();
        jump = GetComponent<AudioSource>();


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
            if (Input.GetKey(KeyCode.Mouse0))
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


        }

        if(Input.GetKeyDown(KeyCode.C))
        {

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

                animator.SetFloat("walkMultiplier", 1f);
                animator.SetBool("isWalking", true);
                //sound
            }
            else if (Input.GetKey(KeyCode.A))
            {

                this.transform.eulerAngles = new Vector3(0, 180, 0);
                rb.transform.Translate(new Vector3(1, 0, 0) * moveSpeed * Time.deltaTime);


                animator.SetFloat("walkMultiplier", -1f);
                animator.SetBool("isWalking", true);
                //sound
            }
            else
            {
                animator.SetBool("isWalking", false);
            }

            if (Input.GetKey(KeyCode.Space) && isGround)
            {
                rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
                animator.SetTrigger("jump");
                isGround = false;
                StartCoroutine(DoubleJumpTimer());
                //sound
            }
            if (Input.GetKeyDown(KeyCode.Space) && doubleJump)
            {
                doubleJump = false;
                rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
                animator.SetTrigger("jump");
            }
        }

        else if (Input.GetKey(KeyCode.A))
        {

            this.transform.eulerAngles = new Vector3(0, 180, 0);
            rb.transform.Translate(new Vector3(1, 0, 0) * moveSpeed * Time.deltaTime);


            animator.SetFloat("walkMultiplier", -1f);
            animator.SetBool("isWalking", true);
            //sound
        }

        else
        {
            animator.SetBool("isWalking", false);
        }

        if (Input.GetKey(KeyCode.Space) && isGround)
        {
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            animator.SetTrigger("jump");
            isGround = false;
            //sound
           
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
        if (collision.gameObject.CompareTag("Soul"))
        {
            soulClose = false;
            currentSoul = null;
        }
    }

    private void Attack()
    {
        blocking = false;
        attacking = true;
        animator.SetTrigger("attack");

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
        collecting = false;
        currentSpeed = moveSpeed;
        Destroy(currentSoul.gameObject);
        souls += 1;
        Debug.Log(souls);
    }

    IEnumerator DoubleJumpTimer()
    {
        yield return new WaitForSeconds(0.2f);
        doubleJump = true;
    }


}



