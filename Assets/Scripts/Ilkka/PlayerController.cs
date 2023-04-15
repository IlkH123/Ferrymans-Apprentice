using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{

    //Set at start(), uncomment if you need to see the numbers in the editor
    //[SerializeField]
    float moveSpeed, jumpForce, jumpTimer, jumpDelay;
    
    [SerializeField]
    PlayerInput player_input;
    [SerializeField]
    AnimationEventHandler anim_EH;
    [SerializeField]
    internal PlayerActions player_actions;
    [SerializeField]
    internal Rigidbody2D rb;
    internal BoxCollider2D player_bc2D;
    Animator player_animator;
    CameraFocus camFoc;

    int health, souls;
    private GameObject currentSoul;

    void Start()
    {
        // fetching some gubbins
        rb = GetComponent<Rigidbody2D>();
        player_animator= GetComponentInChildren<Animator>();
        player_bc2D = GetComponentInChildren<BoxCollider2D>();
        camFoc = GetComponent<CameraFocus>();
        
        //Auxiliary values
        health = 5;
        souls = 0;
    }


    // TODO: I should probably implement some sort of constant values for the public
    // variable references to make the udpate function a lot more readable. Not sure
    // whether that is even possible 

    void Update()
    {
        //Movement when not interacting or blocking
        if (!player_input.interacting && !player_input.blocking)
        {
            //Horizontal movement
            //most of this crap should be moved to player_actions
            if (player_input.leftMove)
            {
                player_actions.MovePlayer(player_input.xMove);
                anim_EH.walkMultiplier(player_input.xMove);
                anim_EH.isWalking(player_input.leftMove);
            }
            else if (player_input.rightMove)
            {
                player_actions.MovePlayer(player_input.xMove);
                anim_EH.walkMultiplier(player_input.xMove);
                anim_EH.isWalking(player_input.rightMove);
            }
            else if (!player_input.leftMove && !player_input.rightMove)
            {
                anim_EH.walkMultiplier(player_input.xMove);
                anim_EH.isWalking(player_input.rightMove);
            }
            
            // Jumping
            if (player_input.upMove)
            {
                if(player_actions.groundCheck && player_actions.jumpCheck)
                {
                    player_actions.Jump(player_input.yMove);
                }
                else if (player_actions.jumpCount < 2)
                {
                    player_actions.Jump(player_input.yMove);
                }
            }

            //crouch, not done yet
            if (player_input.downMove)
            {
            }
        }

        //Attacking
        // The if statement checks both the input and makes sure the action is not already underway
        if((!player_input.blocking && player_input.attacking) && !player_actions.attacking)
        {
            player_actions.Attack();
            //Debug.Log("Player controller if statement");
        }

        //Blocking
        //This has a problem where it will always send some call to the anim event handler
        // TODO: find a solution where it only sends one call when needed.
        if (player_input.blocking)
        {
            player_actions.Block(player_input.blocking);
            
        }
        else if (!player_input.blocking && player_actions.blocking)
        {
            player_actions.Block(player_input.blocking);
        }

        //Interaction
        if(player_input.interacting && !player_actions.interacting)
        {
            player_actions.Interact();
            //Debug.Log("Interaction controller if statement");
            //TODO: This needs branching logic for future interactions
        }
        
    }

    //void OnGUI()
    //{
    //    GUI.Label(new Rect(10, 10, 100, 40), 
    //        $"Attack: {player_input.attacking}\nBlocking: {player_input.blocking}");
    //}

}
