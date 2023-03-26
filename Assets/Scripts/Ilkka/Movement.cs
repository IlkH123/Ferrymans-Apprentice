using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Legacy;
using UnityEngine;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    /*
     * Tää on mun väliaikanen oma movement scripti
     * lähinnä pelkästään testausta varten
     * -Ilkka
     */

    [SerializeField]
    float moveSpeed, jumpForce, jumpTimer, jumpDelay;
    [SerializeField]
    Rigidbody2D rb;
    [SerializeField]
    CameraFocus camFoc;
    
    //[SerializeField]
    //GameObject sh;
    // ^ can't remember what this was for

    float xMove, yMove;
    int jumpCount;
    public bool groundCheck;
    public bool grabCheck;

    void Start()
    {
        // The initial configs for the movement system.
        moveSpeed = 10f;
        jumpForce = 15f;
        jumpDelay = 0.5f;
        rb.drag = 1f; // drag lower that this results in very slippery movement.
        rb.mass = 1f;
        rb.gravityScale = 2f;
        camFoc = GetComponent<CameraFocus>();

        //Priming the movement system
        groundCheck = false;
        grabCheck = false;
        jumpTimer = 0;
        jumpCount = 0;
    }

    void Update()
    {
        //updating the raw imput of the player to derive a direction
        xMove = Input.GetAxisRaw("Horizontal"); // d = 1, a = -1
        yMove = Input.GetAxisRaw("Vertical"); // w = 1, s = -1

        //If the player is in the air, increase the timer if it is not capped
        if (groundCheck == false && jumpTimer < jumpDelay)
        {
        jumpTimer = jumpTimer + Time.deltaTime;
            
        }

        MovePlayer();
        Jump();
        
    }

    void MovePlayer()
    {
        rb.velocity = new Vector2(xMove * moveSpeed, rb.velocity.y);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W) && jumpCount < 2)
        {
            if (groundCheck == true)
            {
                rb.velocity = new Vector2(rb.velocity.x, yMove * jumpForce);
                groundCheck = false;
                camFoc.groundCheck = groundCheck;
                jumpTimer = 0f;
                jumpCount++;
            }
            else if (jumpTimer > 0.5f && jumpCount < 2) 
            {
                rb.velocity = new Vector2(rb.velocity.x, yMove * jumpForce);
                jumpTimer = 0f;
                jumpCount++;
            }
            
        }
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            groundCheck = true;
            camFoc.groundCheck = groundCheck;
            jumpCount = 0;
            jumpTimer = 0f;
        }
        if (collision.gameObject.tag == "Wall" && Input.GetKey(KeyCode.Space))
        {
            grabCheck = true;
        }
    }
}
