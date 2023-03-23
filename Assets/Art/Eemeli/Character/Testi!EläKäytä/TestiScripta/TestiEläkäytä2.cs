using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TestiEläkäytä2 : MonoBehaviour
{
    public UnityEvent OnAnimationEventTriggered, ComboEnder;

    public void TriggerEvent()
    {
        OnAnimationEventTriggered?.Invoke();
    }
}
