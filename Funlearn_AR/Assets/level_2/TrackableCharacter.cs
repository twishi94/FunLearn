using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.SceneManagement;

public class TrackableCharacter : MonoBehaviour, ITrackableEventHandler
{
    public GameObject validObject;
    public GameObject invalidObject;

    private GameObject mainObject;

    private TrackableBehaviour mTrackableBehaviour;
    MultiTracker multiTracker;

    private void Awake()
    {
        OnTrackingLost();
    }

    void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
    }

    public void RegisterMultiTracking(MultiTracker tracker)
    {
        multiTracker = tracker;
        StartTracking();
    }

    public void StartTracking()
    {
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }


    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            multiTracker.OnitemTrack(this);
            OnTrackingFound();
        }
        else if (previousStatus == TrackableBehaviour.Status.TRACKED &&
                 newStatus == TrackableBehaviour.Status.NOT_FOUND)
        {
            OnTrackingLost();
            multiTracker.OnLoseTracking(this);
        }
        else
        {
            // For combo of previousStatus=UNKNOWN + newStatus=UNKNOWN|NOT_FOUND
            // Vuforia is starting, but tracking has not been lost or found yet
            // Call OnTrackingLost() to hide the augmentations
            OnTrackingLost();
            multiTracker.OnLoseTracking(this);
        }
    }
        
    protected virtual void OnTrackingFound()
    {
        if (multiTracker.isValidSymbol(this))
        {
            mainObject = validObject;
        }
        else
        {
            mainObject = invalidObject;
        }

        var rendererComponents = mainObject.GetComponentsInChildren<Renderer>(true);
        var colliderComponents = mainObject.GetComponentsInChildren<Collider>(true);
        var canvasComponents = mainObject.GetComponentsInChildren<Canvas>(true);

        // Enable rendering:
        foreach (var component in rendererComponents)
            component.enabled = true;

        // Enable colliders:
        foreach (var component in colliderComponents)
            component.enabled = true;

        // Enable canvas':
        foreach (var component in canvasComponents)
            component.enabled = true;
    }


    protected virtual void OnTrackingLost()
    {
        var rendererComponents = validObject.GetComponentsInChildren<Renderer>(true);
        var colliderComponents = validObject.GetComponentsInChildren<Collider>(true);
        var canvasComponents = validObject.GetComponentsInChildren<Canvas>(true);

        // Disable rendering:
        foreach (var component in rendererComponents)
            component.enabled = false;

        // Disable colliders:
        foreach (var component in colliderComponents)
            component.enabled = false;

        // Disable canvas':
        foreach (var component in canvasComponents)
            component.enabled = false;


        rendererComponents = invalidObject.GetComponentsInChildren<Renderer>(true);
        colliderComponents = invalidObject.GetComponentsInChildren<Collider>(true);
        canvasComponents = invalidObject.GetComponentsInChildren<Canvas>(true);

        // Disable rendering:
        foreach (var component in rendererComponents)
            component.enabled = false;

        // Disable colliders:
        foreach (var component in colliderComponents)
            component.enabled = false;

        // Disable canvas':
        foreach (var component in canvasComponents)
            component.enabled = false;
        
    }
}
