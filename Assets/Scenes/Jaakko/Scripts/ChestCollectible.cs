// ### VERSIO 1 ###

//using System.Collections;
//using System.Collections.Generic;
//using Unity.VisualScripting;
//using UnityEngine;

//public class ChestCollectible : MonoBehaviour
//{

//    Animator Chest;



//    // Start is called before the first frame update
//    void Start()
//    {
//        Chest = GetComponent<Animator>();
//        Chest.SetBool("ChestOpen", false);
//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }


//    private void OnTriggerEnter2D(Collider2D collision)
//    {
//        if (collision.CompareTag("Player"))
//        {
//            //Debug.Log("Collided");
//            Chest.SetBool("ChestOpen", true);
//        }
//    }
//    private void OnTriggerExit2D(Collider2D collision)
//    {
//        Chest.SetBool("ChestOpen", false);
//    }

//}

// ### VERSIO 2 ###

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class ChestCollectible : MonoBehaviour
//{
//    public GameObject collectible1;
//    public GameObject collectible2;
//    public GameObject instructionText;
//    public Transform collectibleSpawnPoint;
//    public KeyCode interactKey = KeyCode.E;

//    private Animator Chest;
//    private bool isPlayerNearby = false;
//    private bool isOpen = false;

//    void Start()
//    {
//        Chest = GetComponent<Animator>();
//        Chest.SetBool("ChestOpen", isOpen);
//        instructionText.SetActive(false);
//    }

//    void Update()
//    {
//        if (isPlayerNearby && !isOpen)
//        {
//            instructionText.SetActive(true);
//            if (Input.GetKeyDown(interactKey))
//            {
//                isOpen = true;
//                Chest.SetBool("ChestOpen", isOpen);
//                instructionText.SetActive(false);
//                SpawnCollectible();
//            }
//        }
//        else
//        {
//            instructionText.SetActive(false);
//        }
//    }

//    private void OnTriggerEnter2D(Collider2D collision)
//    {
//        if (collision.CompareTag("Player"))
//        {
//            isPlayerNearby = true;
//        }
//    }

//    private void OnTriggerExit2D(Collider2D collision)
//    {
//        isPlayerNearby = false;
//    }

//    private void SpawnCollectible()
//    {
//        int random = Random.Range(1, 3);
//        if (random == 1)
//        {
//            Instantiate(collectible1, collectibleSpawnPoint.position, Quaternion.identity);
//        }
//        else
//        {
//            Instantiate(collectible2, collectibleSpawnPoint.position, Quaternion.identity);
//        }
//    }
//}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestCollectible : MonoBehaviour
{

    public GameObject instructionText; // Reference to the instruction text GameObject
    public GameObject[] collectibles; // Array of collectibles to spawn
    public Transform collectibleSpawnPoint; // Spawn point for the collectibles

    private Animator Chest; // Animator component of the chest
    private bool isOpen = false; // Flag to check if the chest is open
    private bool isNearby = false; // Flag to check if the player is nearby
    
    // Start is called before the first frame update
    void Start()
    {
        Chest = GetComponent<Animator>();
        Chest.SetBool("ChestOpen", isOpen);
        instructionText.SetActive(false); // Hide the instruction text by default

    }

    // Update is called once per frame
    void Update()
    {
        if (isNearby && !isOpen && Input.GetKeyDown(KeyCode.F))
        {
            // Open the chest
            Chest.SetBool("ChestOpen", true);
            isOpen = true;
            // Play the opening sound
            AudioSource audioSource = GetComponent<AudioSource>();
            if (audioSource != null && audioSource.clip != null)
            {
                audioSource.PlayOneShot(audioSource.clip);
            }


            // Spawn a random collectible
            int randomIndex = Random.Range(0, collectibles.Length);
            GameObject newCollectible = Instantiate(collectibles[randomIndex], collectibleSpawnPoint.position, Quaternion.identity);

            // Call Merge method on the new collectible
            CollectibleItem collectibleItem = newCollectible.GetComponent<CollectibleItem>();
            if (collectibleItem != null)
            {
                collectibleItem.Merge();
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // The player is nearby
            isNearby = true;
            instructionText.SetActive(true); // Show the instruction text
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // The player is no longer nearby
            isNearby = false;
            instructionText.SetActive(false); // Hide the instruction text
        }
    }

}
