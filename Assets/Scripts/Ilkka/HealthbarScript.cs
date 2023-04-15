using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarScript : MonoBehaviour
{
    [SerializeField]
    int current, max;
    const int min = 0;
    [SerializeField]
    Slider state;

    bool isDead;
    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
    }
    internal void setValues(int newCurrent, int newMax) 
    { 
        current = newCurrent;
        max = newMax;
        state.maxValue = max;
        state.value = current;
    }
    internal void setHealth(int value) 
    { 
        current = value; 
        state.value = value;
    }
    internal void damageTaken(int dmg)
    {
        if (state.value - dmg < min)
        {
            state.value = min;
            isDead = true;
        }
        else
        {
            state.value -= dmg;
        }
    }

    internal void healingTaken(int dmg)
    {
        state.value += dmg;
        if (state.value > max)
        {
            state.value = max;
        }
    }
}
