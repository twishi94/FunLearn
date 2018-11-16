using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.SceneManagement;

public class detect : MonoBehaviour, Vuforia.ITrackableEventHandler
{

    private TrackableBehaviour mTrackableBehaviour;
    public AudioSource congo;
    public string scene_name;
    float delay = 1;
    int flag = 0;

    void Start()
    {
        congo = GetComponent<AudioSource>();
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (flag == 1)
        {
            if (mTrackableBehaviour)
            {
                mTrackableBehaviour.RegisterTrackableEventHandler(this);
            }
        }
    }


    public void OnTrackableStateChanged(
                                    TrackableBehaviour.Status previousStatus,
                                    TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            // Play audio when target is found
            congo.Play();
            Invoke("GoToScene", congo.clip.length + delay);

        }
        else
        {
            // Stop audio when target is lost
            congo.Stop();


        }
    }

    void GoToScene()
    {
        SceneManager.LoadScene(scene_name);
    }
}
