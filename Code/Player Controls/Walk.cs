using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Walk : MonoBehaviour {

	public Animator anim;

	void start()
	{
		anim = GetComponent<Animator> ();

	}

	void Update()
	{

        /*
        // Grab movement axis
        float moveV = Input.GetAxis("Vertical");
        float moveH = Input.GetAxis("Horizontal");


        // If movement V/H is not 0 we use change boolean expression within Animator
        bool leftClick = Input.GetButton("Fire1");

        if (leftClick)
            anim.SetBool("isAttacking", true);
        else
            anim.SetBool("isAttacking", false);

        if (moveV != 0 || moveH !=0)
            anim.SetBool("isWalking", true);
        else
            anim.SetBool("isWalking", false);*/




    }




}
