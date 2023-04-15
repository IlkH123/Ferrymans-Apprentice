using UnityEngine;
using UnityEngine.Events;

public class AnimationEventHandler : MonoBehaviour
{
    [SerializeField]
    PlayerController controller;
    Animator animator;

    private void Start()
    {
        if (animator == null)
        {
            animator = GetComponentInChildren<Animator>();
        }
    }

    void Update()
    {
        
    }

    internal void isWalking(bool state)
    {
        animator.SetBool("isWalking", state);
    }
    internal void isCrouching(bool state)
    {
        animator.SetBool("isCrouching", state);
    }
    internal void isCrouchWalking(bool state)
    {
        animator.SetBool("isCrouchWalking", state);
    }

    //Using this method will look funny because it will work like a setter
    //when you pass the input boolean through it, it matches the if statement
    //entry boolean. Something like this:
    //
    //if (player_input.leftMove) {
    //    anim_EH.isWalking(player_input.leftMove);
    // }
    //
    //As long as they are both the same boolean
    //reference, this SHOULD work
    // TODO: find a solution that is more specific (explicit?)

    internal void walkMultiplier(float direction)
    {
        switch (direction)
        {
            case -1f:
                animator.SetFloat("walkMultiplier", -1f);
                this.transform.eulerAngles = new Vector3(0, 180, 0);
                break;
            case 1f:
                animator.SetFloat("walkMultiplier", 1f);
                this.transform.eulerAngles = new Vector3(0, 0, 0); // Flipped
                break;
            default:
                break;
        }
    }
    internal void jump()
    {
        animator.SetTrigger("jump");
    }
    internal void attack()
    {
        animator.SetTrigger("attack");
    }
    internal void collectSoul()
    {
        animator.SetTrigger("collectSoul");
    }
    internal void takeDamage()
    {
        animator.SetTrigger("takeDamage");
    }
    internal void playerDead()
    {
        animator.SetBool("playerDead", true);
    }
    internal void blocking(bool state)
    {
        animator.SetBool("blocking", state);
    }
    internal void powerAttack()
    {
        animator.SetTrigger("powerAttack");
    }
    internal void doubleJump()
    {
        animator.SetTrigger("doubleJump");
    }
    internal void crouchAttack()
    {
        animator.SetTrigger("crouchAttack");
    }
    
}
