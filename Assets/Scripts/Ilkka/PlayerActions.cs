using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    [SerializeField]
    PlayerController controller;
    [SerializeField]                
    AnimationEventHandler anim_EH;  // Don't really wnat this here but some animation calls are better done here
    [SerializeField]
    Rigidbody2D rb;
    [SerializeField]
    BoxCollider2D player_bc2D;
    float moveSpeed, jumpForce, jumpDelay;
    internal int jumpCount;
    internal bool jumpCheck, blocking, attacking, interacting, soulClose;
    //soulClose should probably be in input
    [SerializeField]
    internal bool groundCheck;

    // TODO: I suspect these booleans are superfluous, look into removing these booleans and
    // instead use the ones in input and pass them through the call in the controller
    
    void Start()
    {
        rb = controller.rb;
        player_bc2D = controller.player_bc2D;
        moveSpeed = 7f;
        jumpForce = 15f;
        jumpDelay = 0.5f;
        rb.drag = 2f; // drag lower than 1f results in very slippery movement.
        rb.mass = 1.5f;
        rb.gravityScale = 2f;
        rb.freezeRotation = true;

        //Priming the movement system
        groundCheck = true;
        jumpCheck = true;
        jumpCount = 0;

    }

    internal void MovePlayer(float direction)
    {
        rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);
    }

    internal void Jump(float direction)
    {
        rb.velocity = new Vector2(rb.velocity.x, direction * jumpForce);
        anim_EH.jump();
        groundCheck = false;
        jumpCount++;
        if (jumpCount >= 2) 
        { 
            jumpCheck = false;
            StartCoroutine(JumpDelay());
        }
    }
    //The doublejump is broken. TODO: fix this once we have a dash animation

    IEnumerator JumpDelay()
    {
        yield return new WaitForSeconds(jumpDelay);
        jumpCheck = true;
    }
    internal void Attack()
    {
        anim_EH.attack();
        attacking = true;
        
        //Debug.Log("player_actions Attack method");
        //sound
    }
    public void AttackReset()
    {
        attacking = false;
        //Debug.Log("Attack Reset");
    }
    internal void Block(bool state)
    {
        //anim, particle?
        anim_EH.blocking(state);
        blocking = state;
    }
    internal void Interact()
    {
        //All interactions from the E key go here
        // TODO: implement branching logic for other
        // interactions besides collecting souls
        interacting = true;

        anim_EH.collectSoul();
        StartCoroutine(CollectReset());
        //Debug.Log("Interaction action trigger");

        //particles, sound, animation for soul 
    }
    IEnumerator CollectReset()
    {
        yield return new WaitForSeconds(2f);
        interacting = false;
        //Destroy(currentSoul.gameObject);
        //souls += 1;
        //Debug.Log("Soul collect reset");
    }

    public void TakeDamage()
    {

        //health -= 1;
        //Debug.Log("I've taken damage! HP: " + health);
        //player_animator.SetTrigger("takeDamage");
        ////RefreshUI;
        ////anim, particles, sound
        //if (health <= 0)
        //{
        //    //GameOver
        //    player_animator.SetBool("playerDead", true);
        //}
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            groundCheck = true;
            jumpCheck = true;
            jumpCount = 0;
        }
    }
}
