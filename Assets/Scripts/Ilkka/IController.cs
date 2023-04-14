using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This interface is for bundling controller types to the same category, and insures there's a method to
//relay collisions from a child to the parent that has the controller, which should inherit this. Could
//probably be a class and not an interface.
// currently does none of this, a glorified filing tool. Arse.

public interface IController
{
    void handleCollision();
}
