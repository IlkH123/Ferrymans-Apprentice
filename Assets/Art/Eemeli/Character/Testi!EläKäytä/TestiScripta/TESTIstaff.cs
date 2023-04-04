using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTIstaff : MonoBehaviour
{
    public GameObject hitSphere;
    public CircleCollider2D cc;
    private Vector3 pos;
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            col.gameObject.GetComponent<TESTIenemy>().TakeDamage();
            pos = cc.transform.position;
            GameObject sphere = (GameObject)Instantiate(hitSphere, pos + (transform.up * 2.1f), Quaternion.identity);
            Destroy(sphere, 0.5f);
        }
    }
}
