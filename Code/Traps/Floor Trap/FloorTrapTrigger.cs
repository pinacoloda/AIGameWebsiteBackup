using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTrapTrigger : MonoBehaviour {
    public GameObject obj, player;
    private Animation anim;
    //private static bool isPaused = false;

    // Use this for initialization
    void Start()
    {
        anim = obj.GetComponent<Animation>();
        anim.Play("Anim_TrapNeedle_Hide");
    }
	
	// Update is called once per frame
	void Update ()
    {

	}

    // Player walks on trap
    void OnTriggerEnter(Collider other)
    {
        // Animation plays and kills player
        StartCoroutine(wait());
    }

    // Player walks out of trap
    void OnTriggerExit(Collider other)
    {
        // Animation plays and 
        anim.Play("Anim_TrapNeedle_Hide");
        if (player.GetComponent<PlayerStats>().playerHP <= 0)
        {
            anim.Play("Anim_TrapNeedle_Hide");
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(2f);
        anim.Play("Anim_TrapNeedle_Show");
    }
}
