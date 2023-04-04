//using UnityEngine;

//public class CollectibleItem : MonoBehaviour
//{
//    public float jumpHeight = 1f;
//    public float fallSpeed = 1f;
//    public int jumpingLayer = 3;
//    public int fallingLayer = 4;

//    private bool isMerging = false;
//    private float startY;
//    private Rigidbody2D rb;
//    private SpriteRenderer spriteRenderer;

//    private void Start()
//    {
//        rb = GetComponent<Rigidbody2D>();
//        startY = transform.position.y;
//        spriteRenderer = GetComponent<SpriteRenderer>();
//    }

//    private void Update()
//    {
//        if (isMerging)
//        {
//            // Jump up
//            float y = transform.position.y - startY;
//            if (y < jumpHeight)
//            {
//                rb.velocity = new Vector2(0f, 5f);
//                spriteRenderer.sortingOrder = jumpingLayer;
//            }
//            else
//            {
//                isMerging = false;
//                rb.velocity = new Vector2(0f, -fallSpeed);
//                spriteRenderer.sortingOrder = fallingLayer;
//            }
//        }
//    }

//    public void Merge()
//    {
//        isMerging = true;


//    }
//}
//using UnityEngine;

//public class CollectibleItem : MonoBehaviour
//{
//    public float mergeSpeed = 1f; // Merge speed of the item
//    public float fallSpeed = 5f; // Fall speed of the item
//    public float xMergeDistance = 1f; // Horizontal distance to move while merging

//    private bool isMerging = false;
//    private Vector2 mergeTargetPos;
//    private Rigidbody2D rb;
//    private SpriteRenderer spriteRenderer;

//    private void Start()
//    {
//        rb = GetComponent<Rigidbody2D>();
//        spriteRenderer = GetComponent<SpriteRenderer>();
//        mergeTargetPos = transform.position;
//    }

//    private void Update()
//    {
//        if (isMerging)
//        {
//            // Move the item towards the merge target position
//            float step = mergeSpeed * Time.deltaTime;
//            transform.position = Vector2.MoveTowards(transform.position, mergeTargetPos, step);

//            // Check if the item has reached the merge target position
//            if (transform.position.Equals(mergeTargetPos))
//            {
//                isMerging = false;
//                rb.velocity = new Vector2(0f, -fallSpeed);
//            }
//        }
//    }

//    public void Merge()
//    {
//        isMerging = true;
//        mergeTargetPos = new Vector2(transform.position.x - xMergeDistance, transform.position.y + 1f);
//        spriteRenderer.sortingOrder = 4; // Set the sorting order to 4
//        rb.velocity = Vector2.zero; // Set the velocity to 0 to stop any previous movement
//    }
//}
using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    public float jumpForce = 10f;
    public float fallSpeed = 1f;
    public int jumpingLayer = 3;
    public int fallingLayer = 4;

    private bool isMerging = false;
    private float startY;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startY = transform.position.y;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (isMerging)
        {
            // Jump up
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            spriteRenderer.sortingOrder = jumpingLayer;
            isMerging = false;
        }
        else if (rb.velocity.y < -0.1f)
        {
            // Falling
            spriteRenderer.sortingOrder = fallingLayer;
        }
    }

    public void Merge()
    {
        isMerging = true;
    }
}
