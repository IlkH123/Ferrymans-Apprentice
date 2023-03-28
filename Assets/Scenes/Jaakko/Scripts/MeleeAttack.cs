using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{

    Animator meleeHandAnimator;
    public bool meleeAttack;

    void Start()
    {
        meleeHandAnimator = GetComponent<Animator>();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            meleeHandAnimator.SetBool("meleeAttack", true);
        }
        else
        {
            meleeHandAnimator.SetBool("meleeAttack", false);
        }
    }
}