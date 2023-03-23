using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // Scene Indexes for the current and the next scene,
    // The next scene must be set from the editor
    // You'll find the scene Indices under File> Build Settings
    [SerializeField]
    int currentSceneID, nextSceneID;

    void Start()
    {
        // Saves the Index of the scene the object is in
        // on initialization
        currentSceneID = gameObject.scene.buildIndex;
    }

    // This is for button objects
    public void ButtonPress()
    {
        SceneManager.LoadScene(nextSceneID);
    }

    // This is the event method that gets called when the collider set
    // to the object is set as trigger and collided with
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log(other + " Entered the trigger");
            SceneManager.LoadScene(nextSceneID);
        }
    }

}

