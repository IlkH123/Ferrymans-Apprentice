using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    PlayerController controller;
    internal float xMove, yMove;
    internal bool attacking, blocking, interacting, leftMove, rightMove, upMove, downMove;

    // Start is called before the first frame update
    void Start()
    {
        if (controller != null)
        {
            controller = GetComponent<PlayerController>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //updating the raw imput of the player to get a float for direction
        //This script no longers uses these but they are mostly for outside calls
        //where you need to know the direction of the input.
        xMove = Input.GetAxisRaw("Horizontal"); // d = 1, a = -1
        yMove = Input.GetAxisRaw("Vertical"); // w = 1, s = -1

        // Left Mouse
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            attacking = true;
            //Debug.Log("Left mouse click");
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            attacking = false;
        }

        //Right Mouse
        if (Input.GetKey(KeyCode.Mouse1))
        {
            blocking = true;
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            blocking = false;
        }

        //Interaction
        if (Input.GetKeyDown(KeyCode.E))
        {
            interacting = true;
            //Debug.Log("Interaction input");
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            interacting = false;
        }

        //Left move
        if (Input.GetKeyDown(KeyCode.A))
        {
            leftMove = true;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            leftMove = false;
        }

        //Right move
        if (Input.GetKeyDown(KeyCode.D))
        {
            rightMove = true;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            rightMove = false;
        }

        //Crouch
        if (Input.GetKeyDown(KeyCode.S))
        {
            downMove = true;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            downMove = false;
        }

        //Jump
        if (Input.GetKeyDown(KeyCode.W))
        {
            upMove = true;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            upMove = false;
        }
        
    }
}
