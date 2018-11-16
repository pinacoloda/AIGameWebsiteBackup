using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Attack : MonoBehaviour {
    public Animator anim;

    void start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // If Q is pressed, attack animation is turned on, when depressed turned off.
        if (Input.GetKeyDown(KeyCode.Q))
        {
            anim.SetBool("isAttacking", true);
        }
        else
            anim.SetBool("isAttacking", false);

    }
}
