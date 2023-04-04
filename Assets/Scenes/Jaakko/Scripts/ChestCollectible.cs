using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChestCollectible : MonoBehaviour
{

    Animator Chest;
   


    // Start is called before the first frame update
    void Start()
    {
        Chest = GetComponent<Animator>();
        Chest.SetBool("ChestOpen", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnTriggerEnter2d(Collider2D other)
    //{
    //   if (other.CompareTag("Player"))
    //    {
    //        Chest.SetBool("ChestOpen", true);
    //        Debug.Log("Chest open");
    //    }
    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Debug.Log("Collided");
            Chest.SetBool("ChestOpen", true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Chest.SetBool("ChestOpen", false);
    }

}
