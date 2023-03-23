using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTIstaff : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            col.gameObject.GetComponent<TESTIenemy>().TakeDamage();
        }
    }
}
