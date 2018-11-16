using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleHitBox : MonoBehaviour {
    public GameObject obj, player;
    private Animator anim;

    // Use this for initialization
    void Start ()
    {
        anim = player.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            anim.Play("HitReaction");
            player.GetComponent<PlayerStats>().playerHP -= 5;
        }
    }
}
