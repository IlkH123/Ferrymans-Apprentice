using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testi3jeejee : MonoBehaviour
{
    public void MovingRight()
    {
        transform.eulerAngles = new Vector3(0, 0, 0);
    }

    public void MovingLeft()
    {
        transform.eulerAngles = new Vector3(0, 180, 0);
    }
}
