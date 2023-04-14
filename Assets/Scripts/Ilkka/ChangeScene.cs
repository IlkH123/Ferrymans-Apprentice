using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] internal int nextSceneID;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(nextSceneID);
        }
    }

    public void changeScene()
    {
        SceneManager.LoadScene(nextSceneID);
    }
}
