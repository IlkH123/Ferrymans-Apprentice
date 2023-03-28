using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 3f; // speed at which the enemy moves
    public float jumpForce = 5f; // force of the enemy's jump
    public float leftBound = 2f; // left edge of movement range
    public float rightBound = 8f; // right edge of movement range

    private int directionX = 1; // 1 = moving right, -1 = moving left
    private int directionY = 1; // 1 = not jumping, -1 = jumping
    private float timeLeftToMove;
    private float timeLeftToJump;

    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        timeLeftToMove = Random.Range(1f, 6f);
        timeLeftToJump = Random.Range(1f, 6f);
    }

    void Update()
    {
        timeLeftToMove -= Time.deltaTime;
        timeLeftToJump -= Time.deltaTime;

        if (timeLeftToMove <= 0)
        {
            directionX *= -1;
            timeLeftToMove = Random.Range(1f, 6f);
        }

        if (timeLeftToJump <= 0)
        {
            directionY *= -1;
            rb2d.velocity += new Vector2(0f, jumpForce * directionY);
            timeLeftToJump = Random.Range(1f, 6f);
        }

        transform.Translate(Vector2.right * moveSpeed * directionX * Time.deltaTime);

        if (transform.position.x >= rightBound || transform.position.x <= leftBound)
            directionX *= -1;
    }
}