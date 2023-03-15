using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CabinDoorTrigger : MonoBehaviour
{
    public string scene;
    public string triggerName;
    [SerializeField] GameObject openCabinDoor;

    void Start()
    {
        openCabinDoor.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(triggerName))
        {
            openCabinDoor.SetActive(true);
            Invoke("LoadSceneWithDelay", 2f);
        }
    }

    void LoadSceneWithDelay()
    {
        SceneManager.LoadScene(scene);
    }
}

