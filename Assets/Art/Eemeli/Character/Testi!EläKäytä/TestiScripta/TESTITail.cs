using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTITail : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var playerScript = collision.gameObject.GetComponent<TestiEläKäytä>();
            if (!playerScript.blocking)
            {
                playerScript.TakeDamage();
            }
        }
    }
}
