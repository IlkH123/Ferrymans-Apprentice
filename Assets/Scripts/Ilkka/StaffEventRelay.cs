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

    internal void toggleColliderOn()
    {
        if (!cc.enabled) { 
            cc.enabled = true; 
        Debug.Log("Toggled on");
        }
    }
    internal void toggleColliderOff()
    {
        
        if (cc.enabled) { 
            cc.enabled = false;
            Debug.Log("Toggled off");
        }
        
    }

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.tag == "Enemy")
    //    {
    //        // Since we do not know what this hits in advance, I made an interface which all the controller can inherit
    //        // so we can abstract the syntax
    //        IController enemy_control = other.GetComponentInParent<IController>();
    //        Debug.Log("Found and hit type Enemy");

    //    }
        
    //}
}
