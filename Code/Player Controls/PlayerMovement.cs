using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Define our speeds to be changed in Unity editor
    public float fowardSpeed;
    public float strafeSpeed;
    public float backwardsSpeed;
    public float jumpForce;
    public float gravity;
    public float rotationSpeed;
    public float test;
    private Vector3 moveDirection = Vector3.zero;
    Animator anim;
    private Vector3 vs;
    CharacterController controller;
    Rigidbody rb;
    public Camera cam;
    float h;
    float v;

    // Use this for initialization
    void Start ()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        controller = gameObject.GetComponent<CharacterController>();
        Vector3 initPos = GameObject.FindGameObjectWithTag("Boss").transform.localPosition;
        initPos.y += -15;
        initPos.x += 50;
        initPos.z += 28;
        vs = initPos;
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        // Debug tp to boss
        if(Input.GetKey(KeyCode.H))
        {
            transform.position = vs;
        }
        // Main movement controller, as long as player is not attacking or rolling we can move
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Attack")
            && !anim.GetCurrentAnimatorStateInfo(0).IsName("Falling To Roll") 
            && !anim.GetCurrentAnimatorStateInfo(0).IsName("HitReaction")
            && !anim.GetCurrentAnimatorStateInfo(0).IsName("Block")
            && !anim.GetCurrentAnimatorStateInfo(0).IsName("Death")
            && !anim.GetCurrentAnimatorStateInfo(0).IsName("Sweep Fall"))
        {
            h = Input.GetAxisRaw("Horizontal");
            v = Input.GetAxisRaw("Vertical");

            moveDirection = new Vector3(h, 0, v);
            
            float camDir = cam.transform.eulerAngles.y;
            Vector3 turned = Quaternion.Euler(0, camDir, 0) * moveDirection;
            if (turned != Vector3.zero)
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(turned), 0.15f);

            transform.Translate(turned * fowardSpeed * Time.deltaTime, Space.World);
            //moveDirection *= fowardSpeed;
            //rb.isKinematic = false;
            // Play animation with given v and h

            Rolling(Input.GetAxis("Vertical"), h);
            PlayAnimation(h, v);
        
        }
        else if(anim.GetCurrentAnimatorStateInfo(0).IsName("Falling To Roll"))
        {
            moveDirection = new Vector3(v, 0, -h);
            transform.Translate(moveDirection *fowardSpeed* Time.deltaTime, Space.World);
        }

    }


    // Play animation associated with Player Movement
    void PlayAnimation(float v, float h)
    {
        // Attack animation and block animation
        bool leftClick = Input.GetButton("Fire1");
        bool block = Input.GetButton("Fire2");
        if ((leftClick || block) && v == 0 && h == 0)
        {
            anim.SetBool("isStraf", false);
            anim.SetBool("isWalkingBack", false);
            anim.SetBool("isWalking", false);
            if (leftClick && !anim.GetCurrentAnimatorStateInfo(0).IsName("Sweep Fall"))
                anim.Play("Attack");
            else if (block)
                anim.Play("Block", 0, 1f);
        }

        if(v != 0 || h != 0)
        {
            
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
    }

    // Special method to deal with rolling/Iframe
    void Rolling(float v, float h)
    {
        // This is where stamina is consumed and animation is played
        if (Input.GetButtonUp("Jump") && (gameObject.GetComponent<PlayerStats>().stamina >= 20))
        {
            gameObject.GetComponent<PlayerStats>().stamina -= 20;
            anim.Play("Falling To Roll");
        }
    }
}
