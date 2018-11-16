using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class word_pop : MonoBehaviour
{
	public AudioClip aud_c1fl;//change letter
	//public AudioClip aud_c2fl;
	//public AudioClip aud_c1fr;

	public AudioClip aud_r1fl;//rotate letter
	//	public AudioClip aud_r2fl;
	//	public AudioClip aud_r1fr;

	//	public AudioClip reorder;

	public AudioClip congo;

	//public GameObject obj;
	int y, t;

	void Start()
	{
		//		CHANGE WORD HERE
		//obj = GameObject.Find("bat");
		//if (obj != null)
		//{
		//Debug.Log("Object is not NULL, turning off visibility");
		//obj.SetActive(false);
		//}
		y = 1;
		t = 1;
	}
    IEnumerator Example()
    {
        print(Time.time);
        yield return new WaitForSeconds(5);
        print(Time.time);
    }
    void Update()
	{
		if (t == 1) {
			y++;
			if (y % 250 == 0) {
				//          VARIABLES NEED TO BE CHANGED 
				float x_of_p = script_p.x;
				//float x_of_a = script_a.x;
				//float x_of_t = script_t.x;

				//Debug.Log ("I GET " + x_of_b + ", " + x_of_a + ", " + x_of_t);

				bool flip_p = script_p.flip;
				//bool flip_a = script_a.flip;
				//bool flip_t = script_t.flip;

				//if (x_of_b == 0 && x_of_a == 0 && x_of_t == 0)
				//	return;

				if (x_of_p == 0 ) {
					//obj.SetActive (false);
					Debug.Log ("B is not there on the screen");
					AudioSource.PlayClipAtPoint (aud_c1fl, transform.position, 1.0f);
					// else if (x_of_a == 0) {	
					//	Debug.Log ("A is not there on the screen");
					//	AudioSource.PlayClipAtPoint (aud_c2fl, transform.position, 1.0f);
					//} else if (x_of_t == 0) {	
					//	Debug.Log ("T is not there on the screen");
					//	AudioSource.PlayClipAtPoint (aud_c1fr, transform.position, 1.0f);
					//}

				} else {
					if (flip_p ) {
						//obj.SetActive (false);

						Debug.Log ("Try to flip B");
						AudioSource.PlayClipAtPoint (aud_r1fl, transform.position, 1.0f);
						//else if (flip_a == true) {
						//	Debug.Log ("Try to flip A");
						//	AudioSource.PlayClipAtPoint (aud_r2fl, transform.position, 1.0f);
						//} else if (flip_t == true) {
						//	Debug.Log ("Try to flip T");
						//	AudioSource.PlayClipAtPoint (aud_r1fr, transform.position, 1.0f);
						//}

					} else  {
						//obj.SetActive (true);
						Debug.Log ("Congratulations! It is the correct word!");
                        StartCoroutine(Example());
                        //yield return new WaitForSeconds(5);
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
						t = 0;

					} 
					//else {
					//	AudioSource.PlayClipAtPoint (reorder, transform.position, 1.0f);
					//	obj.SetActive (false);
					//}
				}
			}
		}
	}
}