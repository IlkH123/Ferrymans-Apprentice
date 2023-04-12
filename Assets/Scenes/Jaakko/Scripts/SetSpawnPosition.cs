using UnityEngine;
using UnityEngine.SceneManagement;

public class SetSpawnPosition : MonoBehaviour
{
    private void Start()
    {

        Scene currentScene = SceneManager.GetActiveScene();
        Debug.Log("Current scene build index: " + currentScene.buildIndex);

        if (currentScene.buildIndex == 7)
            
        {
            // Set the spawn position of the player in the scene with build index 1
            transform.position = new Vector3(-7, 5, 0); // Change the coordinates as per your requirement
        }
        else if (currentScene.buildIndex == 2)
        {
            // Set the spawn position of the player in the scene with build index 2
            transform.position = new Vector3(2, 2, 0); // Change the coordinates as per your requirement
        }

    }
}
