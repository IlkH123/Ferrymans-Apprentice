using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public AudioSource walkingSound;

    private void Update()
    {
        // Check if the player is moving
        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.01f || Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.01f)
        {
            // If the walking sound is not playing, start it
            if (!walkingSound.isPlaying)
            {
                walkingSound.Play();
            }
        }
        else
        {
            // If the walking sound is playing, stop it
            if (walkingSound.isPlaying)
            {
                walkingSound.Stop();
            }
        }
    }
}
