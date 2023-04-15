using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Purely for categorization reasons

public class Controller : MonoBehaviour, IController
{
    public virtual void handleCollision(Collision2D collision) { }
    public virtual void handleTrigger() { }
    
}
