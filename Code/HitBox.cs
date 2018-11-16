using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour {
    public GameObject enemy;
    Animator anim;
    public GameObject player;
    public GameObject enemyWep;
    private bool canHit = true;
    Animator playerSwing;

    // Use this for initialization
    void Start()
    {
        playerSwing = player.GetComponent<Animator>();
        if (enemy != null)
        { 
            anim = enemy.GetComponent<Animator>();
        }
        else
        {
            anim = null;
        }
	}

    void Update()
    {
        if(anim != null)
        {

        }
    }

    // When player sword collider enters hitbox
    void OnTriggerExit(Collider other)
    {
        if((other.tag != "Enemy" && other.tag != "Zombie" && other.tag != "Untagged") && anim != null && playerSwing.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            if (canHit)
                StartCoroutine(wait());
        }
    }

    IEnumerator wait()
    {
        hitReaction();
        yield return new WaitForSeconds(1f);
        canHit = true;
    }

    void hitReaction()
    {
        if (enemy.tag == "Enemy")
        {
            anim.Play("Hit");
            enemy.GetComponent<Skeleton_Controller>().hp -= 1;
        }
        else if(enemy.tag == "Zombie")
        {
            anim.Play("Getting Hit");
            enemy.GetComponent<ZombieController>().hp -= 1;
        }
        //print("SkeletonHP: " + enemy.GetComponent<Skeleton_Controller>().hp);
        canHit = false;
    }

}
