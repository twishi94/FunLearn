﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bcon : MonoBehaviour {
    public AudioSource myAudioSource;
    string bmodel;
	// Use this for initialization
	void Start () {
        myAudioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit Hit;
            if(Physics.Raycast(ray, out Hit)){
                bmodel = Hit.transform.name;
                if(bmodel == "alpha_b")
                {
                    myAudioSource.Play(); 
                }
            }
        }
	}
}