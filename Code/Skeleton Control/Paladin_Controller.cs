using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Paladin_Controller : MonoBehaviour
{
    public float detectionRadius = 10f;

    Transform target;
    NavMeshAgent agent;
    Animator anim;

    // Use this for initialization
    void Start ()
    {
        target = GameObject.Find("Kitsaragi").transform;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();


    }

	// Update is called once per frame
	void Update ()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        print(distance);

        // If spotted, start walking animation
        if (distance > 0)
            anim.SetBool("isWalking", true);
        else
            anim.SetBool("isWalking", false);

        if (distance <= detectionRadius)
            agent.SetDestination(target.position);

	}

    // This shows us detection sphere of enemy
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);

    }
}
