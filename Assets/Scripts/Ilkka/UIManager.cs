using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] public GameObject deathPanel, endPanel, pausePanel, controlsPanel, otherUI;

    public void TogglePausePanel()
    {
        pausePanel.SetActive(!pausePanel.activeSelf);
    }
    public void ToggleDeathPanel()
    {
        deathPanel.SetActive(!deathPanel.activeSelf);
    }
    public void ToggleEndPanel()
    {
        endPanel.SetActive(!endPanel.activeSelf);
    }
    public void ToggleOtherUI() 
    { 
        otherUI.SetActive(!otherUI.activeSelf);
    }
    public void OpenControls()
    {
        controlsPanel.SetActive(true);
    }
    public void FromControlsToGame()
    {
        controlsPanel.SetActive(false);
        GameConductor.instance.Unpause();
    }
    public void EnableOtherUI()
    {
        otherUI.SetActive(true);
    }
}
