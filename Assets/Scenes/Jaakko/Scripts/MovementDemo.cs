using UnityEngine;

public class MovementDemo : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    public int maxJumps = 2;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool facingRight = true;
    private bool isGrounded = false;
    private int jumps = 0;
    private const float groundCheckRadius = 0.2f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * speed, rb.velocity.y);

        if (move > 0 && !facingRight)
        {
            Flip();
        }
        else if (move < 0 && facingRight)
        {
            Flip();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        if (isGrounded)
        {
            jumps = 0;
        }
    }

    void Jump()
    {
        Debug.Log("Jumps: " + jumps);

        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumps = 1;
            Debug.Log("Ground jump!");
        }
        else if (jumps < maxJumps)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumps++;
            Debug.Log("Extra jump!");
        }
    }



    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(new Vector3(0, 180, 0));
    }
}
