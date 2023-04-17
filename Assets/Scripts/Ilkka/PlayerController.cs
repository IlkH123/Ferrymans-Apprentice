using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class PlayerController : Controller, IController
{

    //Set at start(), uncomment if you need to see the numbers in the editor
    //[SerializeField]
    float moveSpeed, jumpForce, jumpTimer, jumpDelay;

    [SerializeField]
    internal int health, maxHealth, souls;
    internal GameObject currentSoul, currentCollectible;
    
    [SerializeField] internal PlayerInput player_input;
    [SerializeField] internal AnimationEventHandler anim_EH;
    [SerializeField] internal PlayerActions player_actions;
    [SerializeField] internal Rigidbody2D rb;
    [SerializeField] internal HealthbarScript healthbar;
    [SerializeField] internal SoulCounter soul_counter;
    [SerializeField] internal StaffEventRelay staff_relay;
    [SerializeField] internal PlayerSFX player_audio;
    internal BoxCollider2D player_bc2D;
    Animator player_animator;
    CameraFocus camFoc;



    void Start()
    {
        // fetching some gubbins
        rb = GetComponent<Rigidbody2D>();
        player_animator= GetComponentInChildren<Animator>();
        player_bc2D = GetComponentInChildren<BoxCollider2D>();
        camFoc = GetComponent<CameraFocus>();
        
        //Auxiliary values
        maxHealth = 5;
        health = 5;
        healthbar.setMaxHealth(health);
        souls = 0;
    }


    // TODO: I should probably implement some sort of constant values for the public
    // variable references to make the udpate function a lot more readable. Not sure
    // whether that is even possible 

    void Update()
    {
        //Movement when not interacting or blocking
        if (!player_input.interacting && !player_actions.interacting && !player_input.blocking && !player_actions.blocking)
        {
            //Horizontal movement
            
            // Most of the movement code that calls the animation handler was moved to player_actions, but this solution
            // still resets the animations here if the player os not moving. Not sure how well I like it, standard is not consistent
            // TODO: find a solution where the animation resetting is also done in the player_actions

            //crouching?
            if (player_input.crouching)
            {
                // turn on the crouch animation
                anim_EH.isCrouching(player_input.crouching);
                
                //move player
                if (player_input.leftMove)
                {
                    player_actions.MovePlayer(player_input.xMove);
                }
                else if (player_input.rightMove)
                {
                    player_actions.MovePlayer(player_input.xMove);
                }
                else if (!player_input.leftMove && !player_input.rightMove)
                {
                    //if not moving, then turn off the movement animations
                    anim_EH.walkMultiplier(player_input.xMove);
                    anim_EH.isCrouchWalking(player_input.rightMove);
                }
            }
            else
            {
                //turn off crouch animation
                anim_EH.isCrouching(player_input.crouching);

                //move player
                if (player_input.leftMove)
                {
                    player_actions.MovePlayer(player_input.xMove);
                }
                else if (player_input.rightMove)
                {
                    player_actions.MovePlayer(player_input.xMove);
                }
                else if (!player_input.leftMove && !player_input.rightMove)
                {
                    //if not moving, turn off the movement animations
                    anim_EH.walkMultiplier(player_input.xMove);
                    anim_EH.isWalking(player_input.rightMove);
                }
            }

            // Jumping
            if (player_input.upMove)
            {
                if((player_actions.groundCheck && player_actions.jumpCheck) || player_actions.jumpCheck && player_actions.jumpCount < 2)
                {
                    player_actions.Jump();
                }
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
        if (player_input.blocking && !player_actions.blocking)
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

    public bool IsCollectibleNull()
    {
        if (currentCollectible == null) { return true;}
        else return false;
    }

    public bool IsSoulNull()
    {
        if (currentSoul == null) { return true; }
        else return false;
    }

    public void setHealth(int newHealth)
    {
        health = newHealth;
        healthbar.setHealth(health);
    }
    public void setMaxHealth(int newHealth)
    {
        health = newHealth;
        healthbar.setMaxHealth(health);
    }
    public void setSoulCount(int newSouls)
    {
        souls = newSouls;
        soul_counter.setSoulCount(souls);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Arrow")) 
        {
            //Debug.Log("Arrow collision!");
            other.gameObject.GetComponent<EnemyMissile>().destroyImmediate();
            if (!player_input.blocking)
            {
                resolveDamage();
            }
        }
    }

    public void resolveDamage()
    {
        if (health > 1)
        {
            player_actions.TakeDamage();
            anim_EH.takeDamage();
            player_audio.playSound(audioClip.HIT);
            health--;
            healthbar.setHealth(health);
        }
        else if (health <= 1)
        {
            anim_EH.playerDead();
            player_audio.playSound(audioClip.HIT);
            health--;
            healthbar.setHealth(health);
        }
    }

    public override void handleCollision(Collision2D collision) 
    {
        if (!player_input.blocking)
        {
            resolveDamage();
        }
    }

    public override void handleTrigger(Collider2D collision, GameObject collidingObject)
    {
        if (collidingObject.CompareTag("Soul"))
        {
            currentSoul = collidingObject;
            player_actions.soulClose = true;
        }
        if (collidingObject.CompareTag("Health"))
        {
            currentCollectible = collidingObject;
            player_actions.collectibleClose = true;
        }
    }


    //void OnGUI()
    //{
    //    GUI.Label(new Rect(10, 10, 100, 40), 
    //        $"Attack: {player_input.attacking}\nBlocking: {player_input.blocking}");
    //}

}
