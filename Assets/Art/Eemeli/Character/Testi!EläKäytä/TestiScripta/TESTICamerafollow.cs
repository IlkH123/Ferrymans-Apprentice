using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTICamerafollow : MonoBehaviour
{
    public Transform playerPosition;
    public Vector2 cameraPos;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        cameraPos.x = playerPosition.position.x;
        cameraPos.y = playerPosition.position.y;
        this.transform.localPosition = new Vector3(cameraPos.x, cameraPos.y + 6, -10);
    }
}
