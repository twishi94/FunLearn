using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

[RequireComponent(typeof(AudioSource))]
public class word_tower : MonoBehaviour
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
	int y, t;

    void Start()
    {
//		CHANGE WORD HERE
        obj = GameObject.Find("tower");
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
			float x_of_t = script_t.x;
			float x_of_o = script_o.x;
			float x_of_w = script_w.x;
			float x_of_e = script_e.x;
			float x_of_r = script_r.x;

				Debug.Log ("I GET " + x_of_t + ", " + x_of_o + ", " + x_of_w + ", " + x_of_e + ", " + x_of_r);

			bool flip_t = script_t.flip;
			bool flip_o = script_o.flip;
			bool flip_w = script_w.flip;
			bool flip_e = script_e.flip;
			bool flip_r = script_r.flip;

			if (x_of_t == 0 && x_of_o == 0 && x_of_w == 0 && x_of_e == 0 && x_of_r == 0)
				return;

			if (x_of_t == 0 || x_of_o == 0 || x_of_w == 0 || x_of_e == 0 || x_of_r == 0) {
				if (x_of_t == 0) {	
					Debug.Log ("T is not there on the screen");
					AudioSource.PlayClipAtPoint (aud_c1fl, transform.position, 1.0f);
				}
				else if (x_of_o == 0) {	
					Debug.Log ("O is not there on the screen");
					AudioSource.PlayClipAtPoint (aud_c2fl, transform.position, 1.0f);
				}
				else if (x_of_w == 0) {	
					Debug.Log ("W is not there on the screen");
					AudioSource.PlayClipAtPoint (aud_c3fl, transform.position, 1.0f);
				}
				else if (x_of_e == 0) {	
					Debug.Log ("E is not there on the screen");
					AudioSource.PlayClipAtPoint (aud_c2fr, transform.position, 1.0f);
				}
				else if (x_of_r == 0) {	
					Debug.Log ("R is not there on the screen");
					AudioSource.PlayClipAtPoint (aud_c1fr, transform.position, 1.0f);
				}
				obj.SetActive (false);
			}
			else
			{
				if (flip_t || flip_o || flip_w || flip_e || flip_r)
				{
					if (flip_t == true) {
						Debug.Log ("Try to flip T");
						AudioSource.PlayClipAtPoint (aud_r1fl, transform.position, 1.0f);
					}
					else if (flip_o == true) {
						Debug.Log ("Try to flip O");
						AudioSource.PlayClipAtPoint (aud_r2fl, transform.position, 1.0f);
					}
					else if (flip_w == true) {
						Debug.Log ("Try to flip W");
						AudioSource.PlayClipAtPoint (aud_r3fl, transform.position, 1.0f);
					}
					else if (flip_e == true) {
						Debug.Log ("Try to flip E");
						AudioSource.PlayClipAtPoint (aud_r2fr, transform.position, 1.0f);
					}
					else if (flip_r == true) {
						Debug.Log ("Try to flip R");
						AudioSource.PlayClipAtPoint (aud_r1fr, transform.position, 1.0f);
					}
					obj.SetActive (false);
				}
				else if (x_of_r > x_of_e && x_of_e > x_of_w && x_of_w > x_of_o && x_of_o > x_of_t)
				{
					Debug.Log ("Congratulations! It is the correct word!");
					AudioSource.PlayClipAtPoint (congo, transform.position, 1.0f);
					t = 0;
					obj.SetActive (true);
				}
				else
				{
					Debug.Log ("Maybe they are in the wrong order");
					AudioSource.PlayClipAtPoint (reorder, transform.position, 1.0f);
					obj.SetActive (false);
				}
			}
		}
	}
}
}