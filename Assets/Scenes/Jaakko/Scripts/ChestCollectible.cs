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
 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2d(Collider other)
    {
       if (other.gameObject.CompareTag("Player"))
        {
            Chest.SetTrigger("ChestOpen");
        }
    }
}
