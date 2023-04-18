using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Purely for categorization reasons

public class Controller : MonoBehaviour, IController
{
    public virtual void HandleCollision(Collision2D collision) { }
    public virtual void HandleTrigger() { }
    public virtual void HandleTrigger(Collider2D collision) { }
    public virtual void HandleTriggerExit(Collider2D collision) { }

    //not sure if this one is neccessary, you might be able to derive the game object from the collider,
    //thus passing a reference of itself is not needed.
    public virtual void HandleTrigger(Collider2D collision, GameObject collidingObject) { }
    public virtual void HandleTriggerExit(Collider2D collision, GameObject collidingObject) { }

}
