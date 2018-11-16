using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

[RequireComponent(typeof(AudioSource))]
public class word_nuts : MonoBehaviour
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
        obj = GameObject.Find("nuts");
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
			float x_of_n = script_n.x;
			float x_of_u = script_u.x;
			float x_of_t = script_t.x;
			float x_of_s = script_s.x;

			Debug.Log ("I GET " + x_of_n + ", " + x_of_u + ", " + x_of_t + ", " + x_of_s);

			bool flip_n = script_n.flip;
			bool flip_u = script_u.flip;
			bool flip_t = script_t.flip;
			bool flip_s = script_s.flip;

			if (x_of_n == 0 && x_of_u == 0 && x_of_t == 0 && x_of_s == 0)
				return;

			if (x_of_n == 0 || x_of_u == 0 || x_of_t == 0 || x_of_s == 0) {
				if (x_of_n == 0) {	
					Debug.Log ("N is not there on the screen");
					AudioSource.PlayClipAtPoint (aud_c1fl, transform.position, 1.0f);
				}
				else if (x_of_u == 0) {	
					Debug.Log ("U is not there on the screen");
					AudioSource.PlayClipAtPoint (aud_c2fl, transform.position, 1.0f);
				}
				else if (x_of_t == 0) {	
					Debug.Log ("T is not there on the screen");
					AudioSource.PlayClipAtPoint (aud_c2fr, transform.position, 1.0f);
				}
				else if (x_of_s == 0) {	
					Debug.Log ("S is not there on the screen");
					AudioSource.PlayClipAtPoint (aud_c1fr, transform.position, 1.0f);
				}
				obj.SetActive (false);
			}
			else
			{
					if (flip_n || flip_u || flip_t || flip_s)
				{
					if (flip_n == true) {
						Debug.Log ("Try to flip N");
						AudioSource.PlayClipAtPoint (aud_r1fl, transform.position, 1.0f);
					}
					else if (flip_u == true) {
						Debug.Log ("Try to flip U");
						AudioSource.PlayClipAtPoint (aud_r2fl, transform.position, 1.0f);
					}
					else if (flip_t == true) {
						Debug.Log ("Try to flip T");
						AudioSource.PlayClipAtPoint (aud_r2fr, transform.position, 1.0f);
					}
					else if (flip_s == true) {
						Debug.Log ("Try to flip S");
						AudioSource.PlayClipAtPoint (aud_r1fr, transform.position, 1.0f);
					}
					obj.SetActive (false);
				}
				else if (x_of_s > x_of_t && x_of_t > x_of_u && x_of_u > x_of_n)
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