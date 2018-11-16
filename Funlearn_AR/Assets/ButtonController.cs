using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour {

    public AudioSource audioSource;
    public Animator animator;
    public string animationTriggerName;
    public GameObject next;
    float delay = 1;

	// Use this for initialization
	void Start () {
        PlayAnimation();
        audioSource = GetComponent<AudioSource>();


        next.SetActive(false);
        Invoke("EnableNext", audioSource.clip.length + delay);
        
    }

    public void PlayAnimation () {
        if (!audioSource.isPlaying)
        {
            animator.SetTrigger(animationTriggerName);
            audioSource.Play();
        }        
	}

    void EnableNext()
    {
        next.SetActive(true);
    }

}

