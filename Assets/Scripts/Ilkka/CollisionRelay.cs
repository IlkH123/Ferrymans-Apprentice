using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// Generic collison relay. Requires you to have a controller that inherits IController. The relay is put onto a child in
// a prefab and pointed towards a controller in the parent (or anywhere else for that matter) that houses all the code.
// As the controller implements the required method, the relay sends the collision up the hierarchy.

public class CollisionRelay : MonoBehaviour
{
    [SerializeField]
    Controller controller;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        controller.HandleCollision(collision);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        controller.HandleTrigger(collision);
    }

    public void relayTriggerEvent() 
    {
        controller.HandleTrigger();
        Debug.Log("Pass through the relay");
    }
}
