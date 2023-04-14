using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarScript : MonoBehaviour
{
    [SerializeField]
    int current, max, min;
    [SerializeField]
    Slider state;

    bool isDead;
    // Start is called before the first frame update
    void Start()
    {
        current = 5;
        max = 5;
        min = 0;
        isDead = false;
    }

    void damageTaken(int dmg)
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

    void healingTaken(int dmg)
    {
        state.value += dmg;
        if (state.value > max)
        {
            state.value = max;
        }
    }
}
