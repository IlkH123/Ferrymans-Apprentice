using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement2 : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float leftBound = 1f;
    public float rightBound = 2f;

    private int directionX = 1;
    private float timeLeftToMove;

    private Rigidbody2D rb2d;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        timeLeftToMove = Random.Range(1f, 6f);
     
     
    }

    
    void Update()
    {
        timeLeftToMove -= Time.deltaTime;

        if (timeLeftToMove <= 0)
        {
            directionX *= -1;
            timeLeftToMove = Random.Range(1f, 6f);
        }

        transform.Translate(Vector2.right * moveSpeed * directionX * Time.deltaTime);

        if (transform.position.x >= rightBound || transform.position.x <= leftBound)
            directionX *= -1; 
    }
}
