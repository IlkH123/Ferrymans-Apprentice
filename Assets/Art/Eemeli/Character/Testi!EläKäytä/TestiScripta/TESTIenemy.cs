using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTIenemy : MonoBehaviour
{
    int health;
    float moveSpeed;

    private void Start()
    {
        health = 2;
        moveSpeed = 7;
    }

    // Update is called once per frame
    void Update()
    {
        //random movement
        
    }

    public void TakeDamage()
    {
        health -= 1;
        //play sound, animation, particles
        if(health <= 0)
        {
            //Instantiate(soul, this.transform.localposition, quaternion.identity);
            //death sound, animation, particles
            Destroy(this.gameObject);
        }
    }

    public void DetectPlayer()
    {
        //overlapsphere
    }
}
