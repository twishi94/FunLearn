using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class word_fit : MonoBehaviour
{
	public AudioClip aud_c1fl;//change letter
	//public AudioClip aud_c2fl;
	//public AudioClip aud_c1fr;

	public AudioClip aud_r1fl;//rotate letter
//	public AudioClip aud_r2fl;
//	public AudioClip aud_r1fr;

	//public AudioClip reorder;

	//public AudioClip congo;

	//public GameObject obj;
	int y, t;

	void Start()
	{
		//		CHANGE WORD HERE
		//obj = GameObject.Find("fit");
		//if (obj != null)
		//{
			//Debug.Log("Object is not NULL, turning off visibility");
		//	obj.SetActive(false);
	//	}
		y = 1;
		t = 1;
	}

	void Update()
	{
		if (t == 1) {
			y++;
			if (y % 250 == 0) {
				//          VARIABLES NEED TO BE CHANGED 
				float x_of_f = script_f.x;
				//float x_of_i = script_i.x;
				//float x_of_t = script_t.x;

			//	Debug.Log ("I GET " + x_of_f + ", " + x_of_i + ", " + x_of_t);

				bool flip_f = script_f.flip;
				//bool flip_i = script_i.flip;
			//	bool flip_t = script_t.flip;



				if (x_of_f == 0) {
					//obj.SetActive (false);
						
						Debug.Log ("F is not there on the screen");
						AudioSource.PlayClipAtPoint (aud_c1fl, transform.position, 1.0f);//change this

					//else if (x_of_i == 0) {	
					//	Debug.Log ("A is not there on the screen");
					//	AudioSource.PlayClipAtPoint (aud_c2fl, transform.position, 1.0f);
					//} else if (x_of_t == 0) {	
					//	Debug.Log ("T is not there on the screen");
					//	AudioSource.PlayClipAtPoint (aud_c1fr, transform.position, 1.0f);
				//	}
				} else {
					if (flip_f) {
						//obj.SetActive (false);

							Debug.Log ("Try to flip F");
							AudioSource.PlayClipAtPoint (aud_r1fl, transform.position, 1.0f);//change this

					// else if (flip_i == true) {
					//		Debug.Log ("Try to flip I");
					//		AudioSource.PlayClipAtPoint (aud_r2fl, transform.position, 1.0f);
					//	} else if (flip_t == true) {
					//		Debug.Log ("Try to flip T");
					//		AudioSource.PlayClipAtPoint (aud_r1fr, transform.position, 1.0f);
					//	}
					}
				else {
						//obj.SetActive (true);
						SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

						//AudioSource.PlayClipAtPoint (congo, transform.position, 1.0f);//change this
						t = 0;
					} 
				//else {
				//		obj.SetActive (false);
				//		AudioSource.PlayClipAtPoint (reorder, transform.position, 1.0f);
				//	}
				}
			}
		}
	}
}