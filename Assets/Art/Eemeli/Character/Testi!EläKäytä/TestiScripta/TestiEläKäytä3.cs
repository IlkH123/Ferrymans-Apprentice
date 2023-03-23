using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TestiEläKäytä3 : MonoBehaviour
{
    public UnityEvent OnAnimationEventTriggered, ComboEnder;

    public void TriggerEvent2()
    {
        OnAnimationEventTriggered?.Invoke();
    }
}
