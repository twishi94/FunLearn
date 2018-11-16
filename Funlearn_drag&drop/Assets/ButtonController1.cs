using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController1 : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject next;
    float delay = 1;
    // Use this for initialization
    void Start()
    {
        
        //audioSource = GetComponent<AudioSource>();
        next.SetActive(false);
        Invoke("EnableNext", audioSource.clip.length + delay);
        PlayAudio();
    }

    // Update is called once per frame
    public void PlayAudio()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }

    }
    void EnableNext()
    {
        next.SetActive(true);
    }
}