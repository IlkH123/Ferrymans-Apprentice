using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTIbg : MonoBehaviour
{
    public Transform cameraPos;
    Vector2 bgPos;
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        bgPos.x = cameraPos.position.x;
        this.transform.localPosition = new Vector3(bgPos.x, 7.5f , 0);
    }
}
