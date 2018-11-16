using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

[RequireComponent(typeof(AudioSource))]
public class word_felt : MonoBehaviour
{
	public AudioClip aud_c1fl;
	public AudioClip aud_c2fl;
	public AudioClip aud_c2fr;
	public AudioClip aud_c1fr;

	public AudioClip aud_r1fl;
	public AudioClip aud_r2fl;
	public AudioClip aud_r2fr;
	public AudioClip aud_r1fr;

	public AudioClip reorder;

	public AudioClip congo;

    public GameObject obj;
	int t, y;

    void Start()
    {
//		CHANGE WORD HERE
        obj = GameObject.Find("felt");
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
			float x_of_f = script_f.x;
			float x_of_e = script_e.x;
			float x_of_l = script_l.x;
			float x_of_t = script_t.x;

				Debug.Log ("I GET " + x_of_f + ", " + x_of_e + ", " + x_of_l + ", " + x_of_t);

			bool flip_f = script_f.flip;
			bool flip_e = script_e.flip;
			bool flip_l = script_l.flip;
			bool flip_t = script_t.flip;

			if (x_of_f == 0 && x_of_e == 0 && x_of_l == 0 && x_of_t == 0)
				return;

			if (x_of_f == 0 || x_of_e == 0 || x_of_l == 0 || x_of_t == 0) {
				if (x_of_f == 0) {	
					Debug.Log ("F is not there on the screen");
					AudioSource.PlayClipAtPoint (aud_c1fl, transform.position, 1.0f);
				}
				else if (x_of_e == 0) {	
					Debug.Log ("E is not there on the screen");
					AudioSource.PlayClipAtPoint (aud_c2fl, transform.position, 1.0f);
				}
				else if (x_of_l == 0) {	
					Debug.Log ("L is not there on the screen");
					AudioSource.PlayClipAtPoint (aud_c2fr, transform.position, 1.0f);
				}
				else if (x_of_t == 0) {	
					Debug.Log ("T is not there on the screen");
					AudioSource.PlayClipAtPoint (aud_c1fr, transform.position, 1.0f);
				}
				obj.SetActive (false);
			}
			else
			{
				 if (flip_f || flip_e || flip_l || flip_t)
				{
					if (flip_f == true) {
						Debug.Log ("Try to flip F");
						AudioSource.PlayClipAtPoint (aud_r1fl, transform.position, 1.0f);
					}
					else if (flip_e == true) {
						Debug.Log ("Try to flip E");
						AudioSource.PlayClipAtPoint (aud_r2fl, transform.position, 1.0f);
					}
					else if (flip_l == true) {
						Debug.Log ("Try to flip L");
						AudioSource.PlayClipAtPoint (aud_r2fr, transform.position, 1.0f);
					}
					else if (flip_t == true) {
						Debug.Log ("Try to flip T");
						AudioSource.PlayClipAtPoint (aud_r1fr, transform.position, 1.0f);
					}
					obj.SetActive (false);
				}
				else if (x_of_t > x_of_l && x_of_l > x_of_e && x_of_e > x_of_f)
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