using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventRedirector : MonoBehaviour
{
    public UnityEvent attack, crouchAttack, powerAttack, block, collectSouls; 

    void anim_event_Attack()
    {
        attack?.Invoke();
    }

    void anim_event_CrouchAttack() 
    { 
        crouchAttack?.Invoke();
    }

    void anim_event_PowerAttack()
    {
        powerAttack?.Invoke();
    }
    void anim_event_Block()
    {
        block?.Invoke();
    }
    void anim_event_collectSouls()
    {
        collectSouls.Invoke();
    }
}
