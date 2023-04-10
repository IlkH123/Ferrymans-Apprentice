using UnityEngine;

public class OneWayPlatform : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody2D playerRigidbody = other.GetComponent<Rigidbody2D>();
            if (playerRigidbody.velocity.y <= 0)
            {
                playerRigidbody.gravityScale = 0;
                Invoke("RestoreGravity", 0.5f);
            }
        }
    }

    private void RestoreGravity()
    {
        GetComponentInParent<Rigidbody2D>().gravityScale = 1;
    }
}
