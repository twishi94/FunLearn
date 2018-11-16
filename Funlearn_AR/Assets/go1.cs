using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class go1 : MonoBehaviour {
    int t;
    string bmodel;
    public AudioSource myAudioSource;
    // Use this for initialization
    void Start () {
        t = 0;
        myAudioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        Debug.Log(" just entered go1");
        if (Input.touchCount > 0)
        {
            Debug.Log("entered go1");
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                Debug.Log("You have ");
                myAudioSource.Play();
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                RaycastHit Hit;
                if (Physics.Raycast(ray, out Hit))
                {
                    Debug.Log("here");
                    bmodel = Hit.transform.name;

                    if (bmodel == "test")
                    {
                        t = 1;
                        Debug.Log("You have clicked the go1!");

                        //myAudioSource.Play();
                    }
                }
            }
        }
    }
}
