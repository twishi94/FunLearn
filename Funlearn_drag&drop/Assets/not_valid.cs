using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.SceneManagement;

public class not_valid : MonoBehaviour, Vuforia.ITrackableEventHandler
{
    private TrackableBehaviour mTrackableBehaviour;
    public AudioSource try_another;
    

    float delay = 1;


    void Start()
    {
        try_another = GetComponent<AudioSource>();
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();

        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
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
            try_another.Play();
      

        }
        else
        {
            // Stop audio when target is lost
            try_another.Stop();


        }
    }

  
}
