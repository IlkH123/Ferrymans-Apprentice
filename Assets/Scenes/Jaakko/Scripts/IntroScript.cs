using UnityEngine;
using TMPro;

public class IntroScript : MonoBehaviour
{
    public TMP_Text introText; // Reference to the TMP object

    private float scrollSpeed = 80f; // Speed of scrolling

    private void Update()
    {
        // Move the intro text up by scrollSpeed every frame
        introText.rectTransform.anchoredPosition += Vector2.up * scrollSpeed * Time.deltaTime;

        // Stop scrolling once the intro text reaches the top of the screen
        if (introText.rectTransform.anchoredPosition.y >= 1400)
        {
            enabled = false; // Disable the script
        }
    }
}

