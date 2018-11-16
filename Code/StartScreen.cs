using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : MonoBehaviour {
    public Camera playerCam, titleScreen;


	// Use this for initialization
	void Start () {
        playerCam.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey("return") || Input.anyKeyDown)
        {
            print("Pressed enter");
            titleScreen.gameObject.SetActive(false);
            playerCam.gameObject.SetActive(true);    
        }
	}
}
