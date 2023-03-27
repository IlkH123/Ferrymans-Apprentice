using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTIArrow : MonoBehaviour
{
    
    void Start()
    {
        StartCoroutine(Destroy());
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            var playerScript = collision.GetComponent<TestiEläKäytä>();
            if(!playerScript.blocking)
            {
                playerScript.TakeDamage();
            }
            Destroy(this.gameObject);
        }
    }
}
