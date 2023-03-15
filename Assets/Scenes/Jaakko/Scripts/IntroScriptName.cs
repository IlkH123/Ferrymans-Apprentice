using UnityEngine;
using UnityEngine.UI;

public class IntroScriptName : MonoBehaviour
{
    public Image introImage; // Reference to the image object

    private float scrollSpeed = 60f; // Speed of scrolling

    private void Update()
    {
        // Move the intro image up by scrollSpeed every frame
        introImage.rectTransform.anchoredPosition += Vector2.up * scrollSpeed * Time.deltaTime;

        // Stop scrolling once the intro image reaches the top of the screen
        if (introImage.rectTransform.anchoredPosition.y >= 0)
        {
            enabled = false; // Disable the script
        }
    }
}

