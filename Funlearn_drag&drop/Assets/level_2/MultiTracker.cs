using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TrackEvents))]
public class MultiTracker : MonoBehaviour {
   

    [System.Serializable]
    public class ItemInfo
    {
        public TrackableCharacter trackingItem;
        public bool isTracked;
    }

    [SerializeField]
    public List<ItemInfo> characters;
    TrackEvents trackEvents;

	bool isTrackingDone = false;
	bool isSequenceCompleteButNotCorrect = false;

    void Start()
    {
      
        foreach (var item in FindObjectsOfType<TrackableCharacter>())
        {
            item.RegisterMultiTracking(this);
        }

        trackEvents = GetComponent<TrackEvents>();

    }

    public void OnitemTrack(TrackableCharacter newTrackItem)
    {
        foreach (var item in characters)
        {
            if (item.trackingItem == newTrackItem)
            {
                item.isTracked = true;
            }
        }

        bool alltracked = false;

        foreach (var item in characters)
        {
            if (item.isTracked)
            {
                alltracked = true;
            }
            else
            {
                alltracked = false;
                return;
            }
        }
        if (alltracked)
        {
            print("all item Tracked");
            if (CheckCharSequence())
            {
                OnTrackingDone();
            }
            else
            {
                //sequenceNotCorrect();
            };
        }
    }

    public void OnLoseTracking(TrackableCharacter lostItem)
    {
        foreach (var item in characters)
        {
            if (item.trackingItem == lostItem)
            {
                item.isTracked = false;
            }
        }
    }


    bool CheckCharSequence()
    {
        List<float> xPos = new List<float>();

        foreach (var item in characters)
        {
           
            xPos.Add(item.trackingItem.transform.position.x);
        }
        for (int i = 0; i < characters.Count - 1; i++) {
            if(xPos[i] < xPos[i+1] && characters[i].isTracked && characters[i+1].isTracked) {
				continue;
            } else {
                sequenceNotCorrect();
                return false;
            }
        }
		return true;
    }

    internal bool isValidSymbol(TrackableCharacter trackableCharacter)
    {
        bool isValid = false;

        foreach (var item in characters)
        {
            if(item.trackingItem == trackableCharacter)
            {
                isValid = true;
                break;
            }
            else
            {
                isValid = false;
            }
        }

        return isValid;
    }

    void OnTrackingDone()
    {
        if(!isTrackingDone)
        {
            isTrackingDone = true;
            trackEvents.OnTrackingComplete.Invoke();
        }        
    }
	void sequenceNotCorrect() {
	
			isSequenceCompleteButNotCorrect = true;
			trackEvents.sequenceCompletedButWasNotCorrect.Invoke();     
	}
}
