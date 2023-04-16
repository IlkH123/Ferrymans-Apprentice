using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroSceneController : MonoBehaviour
{
    public GameObject pressAnyKeyText;
    public string nextSceneName;
    public float delayBeforePrompt = 2.0f;

    private bool promptShown = false;

    void Start()
    {
        // Hide the "Press any key" text initially
        pressAnyKeyText.SetActive(false);
    }

    void Update()
    {
        // If the delay time has passed and the prompt hasn't been shown yet, show it
        if (Time.timeSinceLevelLoad > delayBeforePrompt && !promptShown)
        {
            promptShown = true;
            pressAnyKeyText.SetActive(true);
        }

        // If any key is pressed, load the next scene
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
