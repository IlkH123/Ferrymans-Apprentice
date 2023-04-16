using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSceneChange : MonoBehaviour
{
    public void BackToMenu()
    {
        // Load the desired scene when the button is clicked
        SceneManager.LoadScene("Main Menu Jaakko");
    }

}