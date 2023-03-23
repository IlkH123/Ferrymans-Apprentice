using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.1f;
    [SerializeField] private LayerMask groundMask;

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool facingRight = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Make the player jump if they're on the ground and press the jump button
            if (isGrounded)
            {
                rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            }
        }
    }

    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        // Move the player left or right
        Vector2 movement = new Vector2(horizontalInput, 0f);
        rb.velocity = new Vector2(movement.x * speed, rb.velocity.y);

        // Check if the player should turn around
        if (horizontalInput > 0 && !facingRight)
        {
            Flip();
        }
        else if (horizontalInput < 0 && facingRight)
        {
            Flip();
        }

        // Check if the player is on the ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundDistance, groundMask);
    }

    private void Flip()
    {
        // Switch the direction the player is facing
        facingRight = !facingRight;

        // Flip the player's sprite
        transform.Rotate(0f, 180f, 0f);
    }
}
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerMovement : MonoBehaviour
//{
//    public float speed = 5f;
//    public float jumpForce = 10f;
//    public int maxJumps = 2;
//    public Transform groundCheck;
//    public LayerMask groundLayer;
//    public Animator animator;

//    private Rigidbody2D rb;
//    private bool facingRight = true;
//    private bool isGrounded = false;
//    private int jumps = 0;

//    void Start()
//    {
//        rb = GetComponent<Rigidbody2D>();
//    }

//    void Update()
//    {
//        float move = Input.GetAxis("Horizontal");
//        rb.velocity = new Vector2(move * speed, rb.velocity.y);

//        if (move > 0 && !facingRight)
//        {
//            Flip();
//        }
//        else if (move < 0 && facingRight)
//        {
//            Flip();
//        }

//        if (Input.GetKeyDown(KeyCode.Space) && (isGrounded || jumps < maxJumps))
//        {
//            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
//            jumps++;
//        }

//        if (Input.GetKeyDown(KeyCode.S))
//        {
//            Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, 0.1f, groundLayer);
//            if (colliders.Length > 1)
//            {
//                transform.position = new Vector2(transform.position.x, colliders[1].transform.position.y);
//            }
//        }

//        if (Input.GetKeyDown(KeyCode.Mouse0))
//        {
//            animator.SetTrigger("MeleeAttack");
//        }

//        animator.SetFloat("Speed", Mathf.Abs(move));
//        animator.SetBool("Grounded", isGrounded);
//        animator.SetInteger("Jumps", jumps);
//    }

//    void FixedUpdate()
//    {
//        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
//        if (isGrounded)
//        {
//            jumps = 0;
//        }
//    }

//    void Flip()
//    {
//        facingRight = !facingRight;
//        transform.Rotate(new Vector3(0, 180, 0));
//    }
//}
