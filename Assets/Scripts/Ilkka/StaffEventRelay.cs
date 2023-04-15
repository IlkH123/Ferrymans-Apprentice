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
        //Debug.Log("Toggled on");
        }
    }
    internal void toggleColliderOff()
    {
        
        if (cc.enabled) { 
            cc.enabled = false;
            //Debug.Log("Toggled off");
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            // This is stupid and should be done with collision and not trigger, but don't have the time to fix it.
            // TODO: get rid of this terrible garbage
            CollisionRelay enemy_relay = other.GetComponentInParent<CollisionRelay>();
            enemy_relay.relayTriggerEvent();
        }

    }
}
