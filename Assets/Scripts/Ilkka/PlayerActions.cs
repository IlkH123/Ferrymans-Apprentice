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
    float moveSpeed, crouchedSpeed, jumpForce, jumpDelay;
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
        moveSpeed = 5f;
        crouchedSpeed = moveSpeed * 0.75f;
        jumpForce = 20f;
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
        if (controller.player_input.crouching)
        {
            rb.velocity = new Vector2(direction * crouchedSpeed, rb.velocity.y);
            if (controller.player_input.leftMove)
            {
                anim_EH.walkMultiplier(controller.player_input.xMove);
                anim_EH.isCrouchWalking(controller.player_input.leftMove);
            }
            else if (controller.player_input.rightMove)
            {
                anim_EH.walkMultiplier(controller.player_input.xMove);
                anim_EH.isCrouchWalking(controller.player_input.rightMove);
            }
            //this is probably superfluous, since stopping the animations are still in the controller
            
            //else if (!controller.player_input.leftMove && !controller.player_input.rightMove)
            //{
            //    anim_EH.walkMultiplier(controller.player_input.xMove);
            //    anim_EH.isCrouchWalking(controller.player_input.rightMove);
            //}
        }
        else
        {
            rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);

            if (controller.player_input.leftMove)
            {
                anim_EH.walkMultiplier(controller.player_input.xMove);
                anim_EH.isWalking(controller.player_input.leftMove);
            }
            else if (controller.player_input.rightMove)
            {
                anim_EH.walkMultiplier(controller.player_input.xMove);
                anim_EH.isWalking(controller.player_input.rightMove);
            }
            //this is probably superfluous, since stopping the animations are still in the controller
            
            //else if (!controller.player_input.leftMove && !controller.player_input.rightMove)
            //{
            //    anim_EH.walkMultiplier(controller.player_input.xMove);
            //    anim_EH.isWalking(controller.player_input.rightMove);
            //}
        }
    }

    internal void Jump()
    {
        if(groundCheck && jumpCheck)
        {
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            anim_EH.jump();
            jumpCheck = false;
            groundCheck = false;
            jumpCount++;
        }
        else if (jumpCheck)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0 );
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            anim_EH.doubleJump();
            jumpCheck = false;
            jumpCount++;
        }
        if (jumpCount <= 2) 
        { 
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
        attacking = true;
        controller.staff_relay.toggleColliderOn();

        if (controller.player_input.crouching)
        {
            anim_EH.crouchAttack();
            
        }
        else
        {
            //I'm putting this here because I'm lazy
            // TODO: find a solution where this is done when you hold down the attack button
            // for a certain amount of time
            if(controller.player_input.holdingShift)
            {
                anim_EH.powerAttack();
            }
            else
            {
                anim_EH.attack();
            }
        }
        
        //Debug.Log("player_actions Attack method");
        //sound
    }
    public void AttackReset()
    {
        attacking = false;
        controller.staff_relay.toggleColliderOff();
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
