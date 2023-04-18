using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailAttack : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Tail collision");
        if (collision.collider.CompareTag("Player"))
        {
            var controller = collision.gameObject.GetComponent<PlayerController>();
            controller.HandleCollision(collision);
        }
    }
}
