using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Animator animator;
 
	// Use this for initialization
	void Start () {
		animator.Play("bb");
	}
	
	// Update is called once per frame
	void Update () {
        animator.Play("bb");
	}
}
