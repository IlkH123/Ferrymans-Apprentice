//using UnityEngine;

//public class PlayerAudio : MonoBehaviour
//{
//    public AudioSource walkingSound;
//    public AudioSource jumpSound;

//    private bool isJumping = false;

//    private void Update()
//    {
//        // Check if the player is moving
//        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.01f) //|| Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.01f)
//        {
//            // If the walking sound is not playing, start it
//            if (!walkingSound.isPlaying)
//            {
//                walkingSound.Play();
//            }
//        }
//        else
//        {
//            // If the walking sound is playing, stop it
//            if (walkingSound.isPlaying)
//            {
//                walkingSound.Stop();
//            }
//        }

//        // Check if the player is jumping
//        if (Input.GetKeyDown(KeyCode.W) && !isJumping)
//        {
//            // Play the jump sound
//            jumpSound.Play();

//            // Set isJumping to true so the sound doesn't play again until the player lands
//            isJumping = true;
//        }
//    }

//    private void OnCollisionEnter(Collision collision)
//    {
//        // Check if the player has landed on the ground
//        if (collision.gameObject.CompareTag("Ground"))
//        {
//            // Set isJumping to false so the jump sound can play again
//            isJumping = false;
//        }
//    }
//}
using UnityEngine;
using System.Collections;

public class PlayerAudio : MonoBehaviour
{
    public AudioSource walkingSound;
    public AudioSource jumpSound;

    private bool isGrounded = true;
    private bool hasJumped = false;

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

        // Check if the player is jumping
        if (Input.GetKeyDown(KeyCode.W) && isGrounded && !hasJumped)
        {
            jumpSound.Play();
            hasJumped = true;
            StartCoroutine(ResetJumpFlag());
        }
    }

    private IEnumerator ResetJumpFlag()
    {
        // Wait for a short time before resetting the jump flag
        yield return new WaitForSeconds(1f);
        hasJumped = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the player is touching the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // Check if the player has left the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
