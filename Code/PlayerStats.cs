using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {
    public float playerHP;
    private float deaths = 0;
    public float stamina;
    public float staminaRefreshRate;
    public float waitTime;
    public float flasks;
    public GameObject flaskCounter;
    public GameObject deathCounter;
    public GameObject deathScreen, victoryScreen;
    private Rigidbody rb;
    private bool isRefreshable = true;
    private bool isPaused = true;
    private Animator anim;
    private Vector3 initPos;

    // Use this for initialization
    void Start()
    {

        initPos = gameObject.transform.position;
        anim = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody>();
        deathScreen.GetComponent<Canvas>().enabled = false;
        victoryScreen.GetComponent<Canvas>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(((Input.GetKeyUp(KeyCode.Z) || Input.GetButtonUp("Fire3"))) && flasks > 0)
        {
            playerHP += 3;
            if(flasks >= 0)
                flasks -= 1;
            string ts = flasks.ToString();
            flaskCounter.GetComponent<Text>().text = ts;
        }
        gameObject.GetComponent<SimpleHealthBar>().UpdateBar(playerHP, 10f);
        gameObject.GetComponent<StaminaScript>().UpdateBar(stamina, 100f);
        if (isRefreshable && stamina >= 0 && stamina <= 100)
            StartCoroutine(staminaRefresh());

        if(playerHP <= 0)
        {
            anim.Play("Death", 0, 1f);
            //anim.SetTrigger("Pause");
            deathScreen.GetComponent<Canvas>().enabled = true;
            //rb.velocity = Vector3.zero;
            //rb.angularVelocity = Vector3.zero;
            //rb.Sleep();
            if(Input.GetKeyUp(KeyCode.Tab) || Input.GetButtonUp("Submit"))
            {
                deaths += 1;
                string ts2 = deaths.ToString();
                deathCounter.GetComponent<Text>().text = ts2;
                //rb.velocity = Vector3.zero;
                //rb.angularVelocity = Vector3.zero;
                //rb.Sleep();
                transform.position = initPos;
                playerHP = 10;
                deathScreen.GetComponent<Canvas>().enabled = false;
                StartCoroutine(respawn());
                
                
            }
            //gameObject.GetComponent<CharacterController>().enabled = true;

        }
	}

    // Every 10 seconds we add +1 stamina to player
    IEnumerator staminaRefresh()
    {
        increment();
        yield return new WaitForSeconds(staminaRefreshRate);
        isRefreshable = true;
    }

    void increment()
    {
        if(stamina <= 100)
            stamina += 1;
        isRefreshable = false;
    }

    IEnumerator respawn()
    {
        wait();
        yield return new WaitForSeconds(waitTime * Time.deltaTime);
        isPaused = true;
    }

    void wait()
    {
        //print("Waiting");
        isPaused = false;
    }
}
