using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

[RequireComponent(typeof(AudioSource))]
public class word_dip : MonoBehaviour
{
	public AudioClip aud_c1fl;
	public AudioClip aud_c2fl;
	public AudioClip aud_c1fr;

	public AudioClip aud_r1fl;
	public AudioClip aud_r2fl;
	public AudioClip aud_r1fr;

	public AudioClip reorder;

	public AudioClip congo;

    public GameObject obj;
	int t, y;

    void Start()
    {
//		CHANGE WORD HERE
        obj = GameObject.Find("dip");
        if (obj != null)
        {
            Debug.Log("Object is not NULL, turning off visibility");
            obj.SetActive(false);
        }
		y = 1;
		t = 1;
	}

    void Update()
	{
		if (t == 1) {
			y++;
			if (y % 250 == 0) {
//          VARIABLES NEED TO BE CHANGED 
			float x_of_d = script_d.x;
			float x_of_i = script_i.x;
			float x_of_p = script_p.x;

			Debug.Log ("I GET " + x_of_d + ", " + x_of_i + ", " + x_of_p);

			bool flip_d = script_d.flip;
			bool flip_i = script_i.flip;
			bool flip_p = script_p.flip;

			if (x_of_d == 0 && x_of_i == 0 && x_of_p == 0)
				return;

			if (x_of_d == 0 || x_of_i == 0 || x_of_p == 0) {
				if (x_of_d == 0) {	
					Debug.Log ("D is not there on the screen");
					AudioSource.PlayClipAtPoint (aud_c1fl, transform.position, 1.0f);
				}
				else if (x_of_i == 0) {	
							AudioSource.PlayClipAtPoint (aud_c2fl, transform.position, 1.0f);
				}
				else if (x_of_p == 0) {	
					Debug.Log ("P is not there on the screen");
					AudioSource.PlayClipAtPoint (aud_c1fr, transform.position, 1.0f);
				}
				obj.SetActive (false);
			}
			else
			{
				if (flip_d || flip_i || flip_p)
				{
					if (flip_d == true) {
						Debug.Log ("Try to flip D");
						AudioSource.PlayClipAtPoint (aud_r1fl, transform.position, 1.0f);
					}
					else if (flip_i == true) {
						Debug.Log ("Try to flip I");
						AudioSource.PlayClipAtPoint (aud_r2fl, transform.position, 1.0f);
					}
					else if (flip_p == true) {
						Debug.Log ("Try to flip P");
						AudioSource.PlayClipAtPoint (aud_r1fr, transform.position, 1.0f);
					}
					obj.SetActive (false);
				}
				else if (x_of_p > x_of_i && x_of_i > x_of_d)
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