using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class check : MonoBehaviour {
    int t;
    string bmodel;
    // Use this for initialization
    void Start () {
        t = 0;
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("entered go2");
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Debug.Log("You have ");
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit Hit;
            if (Physics.Raycast(ray, out Hit))
            {
                Debug.Log("here");
                bmodel = Hit.transform.name;

                if (bmodel == "New Sprite")
                {
                    t = 1;
                    Debug.Log("You have clicked the go1!");
                    //myAudioSource.Play();
                }
            }
        }
    }
}
