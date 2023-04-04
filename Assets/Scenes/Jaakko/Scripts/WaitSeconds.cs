using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitSeconds : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(LogAfterSeconds(5));
        print("Start called");
    }
    IEnumerator LogAfterSeconds (float seconds)
    {
        print("Timer starts");
        yield return new WaitForSeconds(seconds);
        print("Seconds passed: " + seconds);
    }
    //void Update()
    //{
        
    //}
}
