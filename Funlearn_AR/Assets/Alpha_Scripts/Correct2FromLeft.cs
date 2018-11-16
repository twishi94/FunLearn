using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;


[RequireComponent(typeof(AudioSource))]
public class Correct2FromLeft : MonoBehaviour {
	public AudioClip clip;
	int x = 0;
	void Start () {
		
	}
	void Update () {
			if (x == 100) {
				AudioSource.PlayClipAtPoint (clip, transform.position, 1.0f);
				x = 0;
			}
			x++;
	}
}




