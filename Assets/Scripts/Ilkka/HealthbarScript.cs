using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarScript : MonoBehaviour
{
    [SerializeField]
    Slider slider;

    // Start is called before the first frame update
    void Start()
    {

    }
    internal void setMaxHealth(int health)
    {
        if (slider == null)
        {
            slider = gameObject.GetComponent<Slider>();
        }
        slider.maxValue = health;
        slider.value = health;
    }
    internal void setHealth(int health) 
    { 
        slider.value = health;
    }
}
