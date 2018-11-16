using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Skeleton: MonoBehaviour {
    // speed = movement speed, jumpForce = how high you jump
	private float speed = 4f;
	private float jumpForce = 8f;
	private float gravity = 30f;
	private Vector3 moveDirection = Vector3.zero;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//CharacterController controller = gameObject.GetComponent<CharacterController> ();
		
		// Direction movement when not jumping
            // Horizontal = sideways, Vertical = front and back
			//moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			
			//moveDirection = transform.TransformDirection(moveDirection);
			
            // Determines our movement speed
			moveDirection *= speed;

            // Jumping control(default space key)
            if (Input.GetButtonDown("Jump"))
			{
				moveDirection.y = jumpForce;
			}
		
		
        // Determines how are jump is affected by gravity and frames
		moveDirection.y -= gravity * Time.deltaTime;
		
		//controller.Move(moveDirection * Time.deltaTime);
	}
}
