using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

[RequireComponent(typeof(AudioSource))]
public class word_right : MonoBehaviour
{
	public AudioClip aud_c1fl;
	public AudioClip aud_c2fl;
	public AudioClip aud_c3fl;
	public AudioClip aud_c2fr;
	public AudioClip aud_c1fr;

	public AudioClip aud_r1fl;
	public AudioClip aud_r2fl;
	public AudioClip aud_r3fl;
	public AudioClip aud_r2fr;
	public AudioClip aud_r1fr;

	public AudioClip reorder;

	public AudioClip congo;

    public GameObject obj;
	int t, y;

    void Start()
    {
//		CHANGE WORD HERE
        obj = GameObject.Find("right");
        if (obj != null)
        {
            Debug.Log("Object is not NULL, turning off visibility");
            obj.SetActive(false);
        }
		t = 1;
		y = 1;
	}

    void Update()
	{
		if (t == 1) {
			y++;
			if (y % 250 == 0) {

				//          VARIABLES NEED TO BE CHANGED 
				float x_of_r = script_r.x;
				float x_of_i = script_i.x;
				float x_of_g = script_g.x;
				float x_of_h = script_h.x;
				float x_of_t = script_t.x;

				Debug.Log ("I GET " + x_of_r + ", " + x_of_i + ", " + x_of_g + ", " + x_of_h + ", " + x_of_t);

				bool flip_r = script_r.flip;
				bool flip_i = script_i.flip;
				bool flip_g = script_g.flip;
				bool flip_h = script_h.flip;
				bool flip_t = script_t.flip;

				if (x_of_r == 0 && x_of_i == 0 && x_of_g == 0 && x_of_h == 0 && x_of_t == 0)
					return;

				if (x_of_r == 0 || x_of_i == 0 || x_of_g == 0 || x_of_h == 0 || x_of_t == 0) {
					if (x_of_r == 0) {	
						Debug.Log ("R is not there on the screen");
						AudioSource.PlayClipAtPoint (aud_c1fl, transform.position, 1.0f);
					} else if (x_of_i == 0) {	
						Debug.Log ("I is not there on the screen");
						AudioSource.PlayClipAtPoint (aud_c2fl, transform.position, 1.0f);
					} else if (x_of_g == 0) {	
						Debug.Log ("G is not there on the screen");
						AudioSource.PlayClipAtPoint (aud_c3fl, transform.position, 1.0f);
					} else if (x_of_h == 0) {	
						Debug.Log ("H is not there on the screen");
						AudioSource.PlayClipAtPoint (aud_c2fr, transform.position, 1.0f);
					} else if (x_of_t == 0) {	
						Debug.Log ("T is not there on the screen");
						AudioSource.PlayClipAtPoint (aud_c1fr, transform.position, 1.0f);
					}
					obj.SetActive (false);
				} else {
					if (flip_r || flip_i || flip_g || flip_h || flip_t) {
						if (flip_r == true) {
							Debug.Log ("Try to flip R");
							AudioSource.PlayClipAtPoint (aud_r1fl, transform.position, 1.0f);
						} else if (flip_i == true) {
							Debug.Log ("Try to flip I");
							AudioSource.PlayClipAtPoint (aud_r2fl, transform.position, 1.0f);
						} else if (flip_g == true) {
							Debug.Log ("Try to flip G");
							AudioSource.PlayClipAtPoint (aud_r3fl, transform.position, 1.0f);
						} else if (flip_h == true) {
							Debug.Log ("Try to flip H");
							AudioSource.PlayClipAtPoint (aud_r2fr, transform.position, 1.0f);
						} else if (flip_t == true) {
							Debug.Log ("Try to flip T");
							AudioSource.PlayClipAtPoint (aud_r1fr, transform.position, 1.0f);
						}
						obj.SetActive (false);
					} else if (x_of_t > x_of_h && x_of_h > x_of_g && x_of_g > x_of_i && x_of_i > x_of_r) {
						Debug.Log ("Congratulations! It is the correct word!");
						AudioSource.PlayClipAtPoint (congo, transform.position, 1.0f);
						obj.SetActive (true);
					} else {
						Debug.Log ("Maybe they are in the wrong order");
						AudioSource.PlayClipAtPoint (reorder, transform.position, 1.0f);
						obj.SetActive (false);
					}
				}
			}
		}
	}
}