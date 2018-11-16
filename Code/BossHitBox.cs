using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHitBox : MonoBehaviour
{
    public GameObject enemy;
    Animator anim;
    public GameObject playerAnim;
    private bool hit = false;
    private bool canBeHit = true;

    // Use this for initialization
    void Start()
    {
        anim = enemy.GetComponent<Animator>();
    }

    void Update()
    {

    }

    // When player sword collider enters hitbox
    void OnTriggerEnter(Collider other)
    {
        // Check for current player animation name "Attack" set true if it is
        if ((other.tag == "Player"))
        {
            hit = true;
        }
    }

    // When player sword collider moves out of hitbox
    void OnTriggerExit(Collider other)
    {
        if (canBeHit && other.tag == "Player")
            StartCoroutine(waitHitBox());

    }

    IEnumerator waitHitBox()
    {
        hitReaction();
        yield return new WaitForSeconds(1f);
        canBeHit = true;
    }

    void hitReaction()
    {
        //print("SkeletonHP: " + enemy.GetComponent<Skeleton_Controller>().hp);
        enemy.GetComponent<Boss>().bosshp -= 1;
        canBeHit = false;
    }
}