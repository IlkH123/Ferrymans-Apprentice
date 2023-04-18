using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void StartGame()
    {
        // Load the desired scene when the Start Game button is clicked
        GameConductor.ChangeSceneStatic(GameConductor.SceneName.CABIN);
    }

    public void ShowCredits()
    {
        // Load the desired scene when the Credits button is clicked
        GameConductor.ChangeSceneStatic(GameConductor.SceneName.CREDITS);
    }

    public void ExitGame()
    {
        // Quit the game when the Exit button is clicked
        Application.Quit();
    }
}

