using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulController : Controller
{
    [SerializeField]
    LayerMask ground;
    [SerializeField]
    CircleCollider2D my_collider;
    [SerializeField]
    Rigidbody2D my_body;
    const float floatHeight = 2f;
    bool falling;

    private void Awake()
    {
        falling = true;
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        if (falling)
        {
            transform.Translate(Vector2.down * (Time.deltaTime * 5f));
            //checkHeight();
        }
    }

    void checkHeight()
    {
        //Collider2D desiredHeight = Physics2D.OverlapCircle(transform.position, floatHeight, ground);
        

        if (Physics2D.OverlapCircle(transform.position, floatHeight, ground).CompareTag("Ground"))
        {
            Debug.Log("Touching grass");
            falling = false;
            
        }
        else falling = true;

    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.collider.CompareTag("Ground")) 
    //    {
    //        Debug.Log("Touching grass");
    //        falling = false;
    //        my_body.bodyType = RigidbodyType2D.Static;
    //        my_collider.isTrigger = true;
    //    }
    //}

    public override void HandleCollision(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            //Debug.Log("Touching grass");
            falling = false;
            my_body.bodyType = RigidbodyType2D.Static;
            my_collider.isTrigger = true;
            my_collider.radius *= 0.5f;
        }
    }

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        other.gameObject.GetComponent<Controller>().handleTrigger(my_collider);
    //    }
    //}

    //public override void HandleTrigger(Collider2D other)
    //{
    //    if (other.CompareTag("Player") && other.gameObject.GetComponent<PlayerController>().IsSoulNull())
    //    {
    //        other.gameObject.GetComponent<PlayerController>().HandleTrigger(my_collider, gameObject);
    //    }
    //}

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, floatHeight);
    }
}
