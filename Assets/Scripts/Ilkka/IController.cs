using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This interface is for bundling controller types, and insures there's a method to relay collisions from a child to the parent
//that has the controller, which should inherit this.

public interface IController
{
    void handleCollision();
}
