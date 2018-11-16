using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Boss : MonoBehaviour
{
    // Changeable in Unity
    public float detectionRadius = 10f;
    public float bosshp;
    public float playerHp;
    public float initHp;
    public GameObject targetObject;
    private bool canAttack = true;
    Transform target;
    NavMeshAgent agent;
    Animator anim;
    public Image bar;

    // Use this for initialization
    void Start()
    {
        // Enemy is the AI, target is the player
        initHp = bosshp;
        target = targetObject.transform;
        agent = GetComponent<NavMeshAgent>();
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get player HP from PlayerStats script
        playerHp = targetObject.GetComponent<PlayerStats>().playerHP;
        bar.fillAmount = bosshp / initHp;
        if (bosshp > 0)
        {
            /*******************************/
            /*      Detected state         */
            /*******************************/
            // Determine distance from target
            float distance = Vector3.Distance(target.position, transform.position);

            /*******************************/
            /*     Follow state            */
            /*******************************/
            // If target is within radius start moving the NavMeshAgent
            if ((distance) <= detectionRadius)
            {
                anim.SetBool("isWalking", true);
                agent.SetDestination(target.position);
            }

            /*******************************/
            /*     Stop state              */
            /*******************************/
            // Reached player now determine action
            if (distance <= 5f)
            {
                agent.isStopped = true;
                anim.SetBool("isWalking", false);
                anim.StopPlayback();

                /*******************************/
                /*     Attack state            */
                /*******************************/
                if (playerHp > 0)
                {
                    // Call Co-routine for attacking in intervals
                    if (canAttack)
                        StartCoroutine(wait());
                }
                else
                {
                    // Player dead

                }
            }
            else
            {
                agent.isStopped = false;
            }



        }
        else
        {
            // Death animation plays and despawn Skeleton
            //anim.Play("Death");
            Destroy(gameObject, 1.5f);
            target.GetComponent<PlayerStats>().victoryScreen.GetComponent<Canvas>().enabled = true;
            Application.Quit();
        }
    }

    // This shows us detection sphere of enemy
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }

    // Sword swing interval Co-routine
    void swing()
    {
        // If player is in animation mode attack skeleton can't attack
        anim.Play("Stomp");
        canAttack = false;
    }

    IEnumerator wait()
    {
        swing();
        yield return new WaitForSeconds(9f);
        canAttack = true;
    }
}