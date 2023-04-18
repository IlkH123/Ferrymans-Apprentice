using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSceneChange : MonoBehaviour
{
    public void BackToMenu()
    {
        // Load the desired scene when the button is clicked
        GameConductor.ChangeSceneStatic(GameConductor.SceneName.MAIN_MENU);
    }

}