using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffEventRelay : MonoBehaviour
{

    [SerializeField]
    PlayerController controller;
    CircleCollider2D cc;


    // Start is called before the first frame update
    void Start()
    {
        if(cc == null)
        {
            cc = GetComponent<CircleCollider2D>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void toggleCollider()
    {
        Debug.Log("Toggled");
        if (cc.enabled) { cc.enabled = false; }
        else if (!cc.enabled) { cc.enabled = true; }
    }
}
