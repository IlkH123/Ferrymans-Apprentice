using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestiEläKäytä : MonoBehaviour
{

    private Rigidbody2D rb;
    private BoxCollider2D bc;
    public SpriteRenderer sr;
    public Animator animator;
    public TestiEläkäytä2 testi;

    float moveSpeed;
    float jumpForce;
    private bool isGround;
    private bool attacking = false;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponentInChildren<SpriteRenderer>();       
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponentInChildren<BoxCollider2D>();
        animator = GetComponentInChildren<Animator>();
        rb.freezeRotation = true;
        moveSpeed = 5;
        jumpForce = 7;
        isGround = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && !attacking)
        {
            Attack();
        }

        if(Input.GetKey(KeyCode.Alpha1))
        {
            transform.eulerAngles = new Vector3(0, 180, 0); // Flipped
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            transform.eulerAngles = new Vector3(0, 0, 0); // Flipped
        }
    }

    void FixedUpdate()
    {


        if (Input.GetKey(KeyCode.D))
        {
            transform.eulerAngles = new Vector3(0, 0, 0); // Flipped
            rb.transform.Translate(new Vector3(1, 0, 0) * moveSpeed * Time.deltaTime);     
            
            animator.SetFloat("walkMultiplier", 1f);
            animator.SetBool("isWalking", true);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            rb.transform.Translate(new Vector3(1, 0, 0) * moveSpeed * Time.deltaTime);  
            
            animator.SetFloat("walkMultiplier", -1f);
            animator.SetBool("isWalking", true);
        }

        else animator.SetBool("isWalking", false);

        if (Input.GetKey(KeyCode.Space) && isGround)
        {
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            animator.SetTrigger("jump");
            isGround = false;
        }

        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
    }

    private void Attack()
    {
        attacking = true;
        animator.SetTrigger("attack");
    }

    public void AttackReset() 
    {
        attacking = false;
    }
}



