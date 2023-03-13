using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestiEläKäytä : MonoBehaviour
{

    private Rigidbody2D rb;
    private BoxCollider2D bc;
    public Animator animator;
    public TestiEläkäytä2 testi;
    public CircleCollider2D staffCollider;


    float moveSpeed;
    float jumpForce;
    private bool isGround;
    private bool attacking = false;
    private bool blocking = false;

    private int health;
    private int maxHealth;
    public int souls;




    void Start()
    {    
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponentInChildren<BoxCollider2D>();
        animator = GetComponentInChildren<Animator>();


        rb.freezeRotation = true;
        moveSpeed = 5;
        jumpForce = 8;
        isGround = true;

        health = 5;
        maxHealth = health;
        souls = 0;
    }

    void Update()
    {
        //if (!attacking)
        if (Input.GetKey(KeyCode.Mouse0) && !attacking)
        {
            Attack();
        }

        if (Input.GetKey(KeyCode.Mouse1) && !attacking)
        {
            Block();
        }
        else blocking = false;
    }

    void FixedUpdate()
    {


        if (Input.GetKey(KeyCode.D))
        {
            this.transform.eulerAngles = new Vector3(0, 0, 0); // Flipped
            rb.transform.Translate(new Vector3(1, 0, 0) * moveSpeed * Time.deltaTime);

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
            //sound
        }

        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }

        //if(col.gameObject.CompareTag("CollectbileHealth"))
        {
            health += 2;
            //particles, destroy col.object
            if(health > maxHealth)
            {
                health = maxHealth;
                //RefreshUI();
            }
        }
    }

    private void Attack()
    {
        staffCollider.enabled = true;
        attacking = true;
        animator.SetTrigger("attack");

        //sound
    }
    public void AttackReset() 
    {
        staffCollider.enabled = false;
        attacking = false;
    }

    public void Block()
    {
        //anim, particle?
        blocking = true;
    }

    public void TakeDamage()
    {
        //if blocking? damageTaken *= 0.5f;
        health -= 1;
        //RefreshUI;
        //anim, particles, sound
        if(health <= 0)
        {
            //GameOver
        }
    }

}



