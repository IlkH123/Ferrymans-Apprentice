using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameConductor : MonoBehaviour
{
    public static GameConductor instance;
    public GameObject player;
    public bool isPaused;
    private float previousTimeScale;

    public enum SceneName
    {
        INTRO = 0,
        MAIN_MENU = 1,
        CREDITS = 2,
        CABIN = 3,
        FOREST1_1 = 4,
    }

    private void Awake()
    {
        if (GameConductor.instance == null) GameConductor.instance = this;
        else Destroy(gameObject);
        previousTimeScale = Time.timeScale;
        Time.timeScale = 0;
        isPaused = true;
    }

    public void TogglePause() 
    {
        if (Time.timeScale > 0)
        {
            previousTimeScale = Time.timeScale;
            Time.timeScale = 0;
            isPaused = true;
            AudioListener.pause = true;
            PauseMenu();
        }
        else if (Time.timeScale == 0) 
        {
            Time.timeScale = previousTimeScale;
            isPaused= false;
            AudioListener.pause = false;
            PauseMenu();
        }
    }
    public void Unpause()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = previousTimeScale;
            isPaused = false;
            AudioListener.pause = false;
        }
    }
    public void PauseMenu()
    {
        UIManager ui = gameObject.GetComponent<UIManager>();
        if (ui != null)
        {
            ui.TogglePausePanel();
            if (ui.otherUI.activeSelf) 
            { 
                ui.ToggleOtherUI();
            }
        }
    }
    
    public void GameOver()
    {
        UIManager ui = gameObject.GetComponent<UIManager>();
        if (ui != null) 
        {
            Time.timeScale = 0;
            ui.ToggleDeathPanel();
            ui.ToggleOtherUI();
        }
    }

    public void GameOverEndofDemo()
    {
        UIManager ui = gameObject.GetComponent<UIManager>();
        if (ui != null)
        {
            player.GetComponent<PlayerInput>().InputPurge();
            ui.ToggleEndPanel();
            ui.ToggleOtherUI();
            isPaused = true;
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UIManager ui = gameObject.GetComponent<UIManager>();
        if (ui != null)
        {
            if (GetSceneIndexAsSceneName() == SceneName.FOREST1_1)
            {
                ui.EnableOtherUI();
            }
        }
    }

    public SceneName? GetSceneIndexAsSceneName()
    {
        var index = SceneManager.GetActiveScene().buildIndex;
        switch(index)
        {
            case 0:
                return SceneName.INTRO;
            case 1:
                return SceneName.MAIN_MENU;
            case 2:
                return SceneName.CREDITS;
            case 3:
                return SceneName.CABIN;
            case 4:
                return SceneName.FOREST1_1;
            default:
                SceneName? returnIndex = null;
                return returnIndex;
        }
    }
    public void ChangeScene(SceneName scene)
    {
        switch(scene) {
            case SceneName.INTRO:
                SceneManager.LoadScene("Intro");
                break;
            case SceneName.MAIN_MENU:
                SceneManager.LoadScene("Main Menu");
                break;
            case SceneName.CREDITS:
                SceneManager.LoadScene("Credits");
                break;
            case SceneName.CABIN:
                SceneManager.LoadScene("Cabin");
                break;
            case SceneName.FOREST1_1:
                SceneManager.LoadScene("Forest 1-1");
                break;
            default:
                Debug.Log("Invalid scene enum value");
                break;
        }
    }

    //Same thing but static, not really sure if we need both, but there we go.
    public static void ChangeSceneStatic(SceneName scene)
    {
        switch (scene)
        {
            case SceneName.INTRO:
                SceneManager.LoadScene("Intro");
                break;
            case SceneName.MAIN_MENU:
                SceneManager.LoadScene("Main Menu");
                break;
            case SceneName.CREDITS:
                SceneManager.LoadScene("Credits");
                break;
            case SceneName.CABIN:
                SceneManager.LoadScene("Cabin");
                break;
            case SceneName.FOREST1_1:
                SceneManager.LoadScene("Forest 1-1");
                break;
            default:
                Debug.Log("Invalid scene enum value");
                break;
        }
    }

    public void Kill()
    {
        Time.timeScale = 1;
        Destroy(player);
        Destroy(this.gameObject);
    }
}
