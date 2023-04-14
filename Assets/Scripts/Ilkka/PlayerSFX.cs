using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSFX : MonoBehaviour, IAudioManager
{
    [SerializeField]
    internal PlayerController controller;
    [SerializeField]
    internal AudioSource walking, jump, caneWhoosh, grunt;

    public void playSound(audioClip clip)
    {
        switch(clip)
        {
            case audioClip.WALK:
                {
                    if (!walking.isPlaying)
                    {
                        walking.Play();
                    }
                    break;
                }
            case audioClip.JUMP:
                {
                    if (!jump.isPlaying)
                    {
                        jump.Play();
                    }
                    break;
                }
            case audioClip.CANE:
                {
                    if (!caneWhoosh.isPlaying)
                    {
                        caneWhoosh.Play();
                    }
                    break;
                }
            case audioClip.GRUNT: 
                {
                    if (!grunt.isPlaying)
                    {
                        grunt.Play();
                    }
                    break;
                }
            default: { 
                    
                    Debug.Log("Invalid sound enum");
                    break;
                }
        }
    }
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
