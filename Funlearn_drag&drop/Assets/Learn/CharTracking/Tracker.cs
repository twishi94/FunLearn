using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracker : MonoBehaviour {
        
    public List<TrackPiece> trackItems;    
    bool isItemTrackedCompletely = false;
    
    void Start () {
        Initialized();
    }

    private void Initialized()
    {
        trackItems = new List<TrackPiece>(transform.childCount);

        for (int i = 0; i < transform.childCount; i++)
        {
            trackItems.Add(transform.GetChild(i).GetComponent<TrackPiece>());
        }
    }

    public void OnItemHovered(TrackPiece trackPiece)
    {
        foreach (var item in trackItems)
        {
            if( item == trackPiece)
            {
                item.IsTracked = true;
            }
        }
        ChackCharTracked();
    }
    
    void ChackCharTracked()
    {
        foreach (var item in trackItems)
        {
            if(item.IsTracked == false)
            {
                isItemTrackedCompletely = false;
                return;
            }
            else
            {
                isItemTrackedCompletely = true;
            }
        }

        if(isItemTrackedCompletely)
        {
            OnComplete();
        }
    }

    private void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            if (!isItemTrackedCompletely)
            {
                ResetTracker();
            }
        }
    }

    private void ResetTracker()
    {
        isItemTrackedCompletely = false;
        foreach (var item in trackItems)
        {
            item.ResetTrackPiece();
        }
    }

    void OnComplete()
    {
        // Add Your Code Here
        print("Item Tarcked");
    }
}
