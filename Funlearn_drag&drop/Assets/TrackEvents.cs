using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class TrackEvents : MonoBehaviour
{
    public UnityEvent OnTrackingComplete;
	public UnityEvent sequenceCompletedButWasNotCorrect;

    void Start()
    {
        if (OnTrackingComplete == null)
            OnTrackingComplete = new UnityEvent();
		if (sequenceCompletedButWasNotCorrect == null)
			sequenceCompletedButWasNotCorrect = new UnityEvent();
    }
}