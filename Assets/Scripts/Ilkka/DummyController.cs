using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyController : Controller, IController
{
    [SerializeField]
    BoxCollider2D text_trigger;
    [SerializeField]
    BoxCollider2D dummy_bc;
    [SerializeField]
    DummyCollisionRelay dummy_relay;
    Animator animator;

    float hitPoints;

    // Start is called before the first frame update
    void Start()
    {
        if (dummy_bc == null)
        {
            dummy_bc = dummy_relay.GetComponent<BoxCollider2D>();
        }
        if (animator == null)
        {
            animator = dummy_relay.GetComponent<Animator>();
        }

        hitPoints = 3;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void takeDamage()
    {
        hitPoints--;
        if(hitPoints > 0)
        {
            animator.SetTrigger("dummyHit");
        }
        else
        {
            animator.SetTrigger("dummyDeath");
        }
    }

    void IController.handleCollision(Collision2D collision)
    {
        
    }
}
