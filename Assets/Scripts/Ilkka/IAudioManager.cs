using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// This interface is the heart of any different audio managers you might need, the idea is to inherit this and then use
// a switch statement to play the sounds you need. This way you can pick and choose which audio files you implement
// in addition it is easy to expand this enum that defines the clips.
// WHEN YOU INHERIT THIS IT IS IMPORTANT THAT YOU MAKE A DEFAULT SWITCH STATEMENT FOR INVALID ENUMS
public enum audioClip
{
    WALK = 0,
    JUMP = 1,
    CANE = 2,
    GRUNT = 3
}
public interface IAudioManager
{
    public void playSound(audioClip clip);

}


