using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitBox : MonoBehaviour
{
    public GameObject trap;
    public GameObject[] enemy;
    public GameObject enemyWeapon;
    public GameObject ownWeapon;
    private Animator anim;
    public static int numberOfEnemies = 1;
    private bool canHit = true;
    private Rigidbody rb;
    //private static Animation spikeTrap;

    // Use this for initialization
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        //anim = enemy[0].GetComponent<Animator>();
        //anim = enemy.GetComponent<Animator>();
        //spikeTrap = trap.GetComponent<Animation>();
        //enemy = GameObject.FindGameObjectsWithTag("Enemy");
    }

    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Enemy") != null)
        {
            if ((Vector3.Distance(gameObject.transform.position, GameObject.FindGameObjectWithTag("Enemy").transform.position) < 10f))
            {
                //print(GameObject.FindGameObjectWithTag("Enemy").name);
                anim = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Animator>();
            }
            else
            {
                anim = null;
            }
        }
        else if (GameObject.FindGameObjectWithTag("Zombie") != null)
        {
            if ((Vector3.Distance(gameObject.transform.position, GameObject.FindGameObjectWithTag("Zombie").transform.position) < 10f))
            {
                //print(GameObject.FindGameObjectWithTag("Enemy").name);
                anim = GameObject.FindGameObjectWithTag("Zombie").GetComponent<Animator>();
            }
            else
            {
                anim = null;
            }
        }

        /*
        for(int i=0; i<numberOfEnemies; i++)
        {
            if (Vector3.Distance(gameObject.transform.position, enemy[i].transform.position) < 10f)
            {
                anim = enemy[i].GetComponent<Animator>();
                break;
                print(enemy[i].name);
            }
            else
            {
                anim = null;
            }
        }*/


    }

    void OnTriggerExit(Collider other)
    {
        print("Hit");
        if (other.tag != "Player" && other.tag != "Untagged" && anim.GetCurrentAnimatorStateInfo(0).IsName("SwingHeavy"))
        {
            if (canHit)
                StartCoroutine(wait(other));
        }
    }

    IEnumerator wait(Collider ot)
    {
        hitReaction(ot);
        yield return new WaitForSeconds(2f);
        canHit = true;
    }

    void hitReaction(Collider ot)
    {
        if(!gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Falling To Roll") &&
            !gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Block") /*&&
            !ownWeapon.GetComponent<BoxCollider>().isTrigger*/)
        {
            //print(ot.tag);
            if(ot.tag == "Boss")
            {
                gameObject.GetComponent<Animator>().Play("Sweep Fall");
                Vector3 curPos = ot.transform.position - gameObject.transform.position;
                curPos = curPos.normalized;
                rb.AddForce(curPos * 10);
            }
            else
                gameObject.GetComponent<Animator>().Play("HitReaction");
            if(ot.tag == "Boss")
            {
                gameObject.GetComponent<PlayerStats>().playerHP -= 3;
            }
            else
                gameObject.GetComponent<PlayerStats>().playerHP -= 1;
            //print("PlayerHP: " + gameObject.GetComponent<PlayerStats>().playerHP);
        }
        canHit = false;
    }

}