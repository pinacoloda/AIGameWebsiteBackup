using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockOn : MonoBehaviour
{
    public GameObject player, followCamera;
    private GameObject enemy;

    void Start()
    {

    }

    void Update()
    {
        // If player is holding down Fire3(tab on keyboard)
        if (Input.GetKey(KeyCode.Tab))
        {
            // Find the closest gameobject with tag enemy and lock on to it
            if (GameObject.FindGameObjectWithTag("Enemy") || GameObject.FindGameObjectWithTag("Zombie") || GameObject.FindGameObjectWithTag("Boss"))
                enemy = GameObject.FindGameObjectWithTag("Enemy");
            //else if (GameObject.FindGameObjectWithTag("Zombie"))
            //enemy = GameObject.FindGameObjectWithTag("Zombie");
            // else if (GameObject.FindGameObjectWithTag("Boss"))
            //enemy = GameObject.FindGameObjectWithTag("Boss");
            print(enemy.tag);
            if (Vector3.Distance(player.transform.position, enemy.transform.position) <= 20f)
            {
                print(enemy.tag);
                transform.LookAt(enemy.transform);
            }
        }
    }
}
