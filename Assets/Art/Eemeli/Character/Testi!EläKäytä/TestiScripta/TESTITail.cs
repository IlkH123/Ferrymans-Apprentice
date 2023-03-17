using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTITail : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var playerScript = collision.gameObject.GetComponent<TestiEl�K�yt�>();
            if (!playerScript.blocking)
            {
                playerScript.TakeDamage();
            }
        }
    }
}
