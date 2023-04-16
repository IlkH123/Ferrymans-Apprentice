using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void StartGame()
    {
        // Load the desired scene when the Start Game button is clicked
        SceneManager.LoadScene("CabinTestiSceneJaakko");
    }

    public void ShowCredits()
    {
        // Load the desired scene when the Credits button is clicked
        SceneManager.LoadScene("Credits Jaakko");
    }

    public void ExitGame()
    {
        // Quit the game when the Exit button is clicked
        Application.Quit();
    }
}

