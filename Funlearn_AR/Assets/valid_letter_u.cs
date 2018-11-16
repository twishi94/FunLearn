using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.SceneManagement;

public class valid_letter_u : MonoBehaviour, Vuforia.ITrackableEventHandler
{
    private TrackableBehaviour mTrackableBehaviour;
    public AudioSource congo;
    public string scene_name;
    private ImageTargetBehaviour mImageTargetBehaviour = null;
    private int flip = 0;
    private GameObject N_RED = null;
    private GameObject u_green = null;
    int time = 0;

    float delay = 0;
    private void OnVuforiaStarted()
    {
        CameraDevice.Instance.SetFocusMode(
            CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
    }

    private void OnPaused(bool paused)
    {
        if (!paused) // resumed
        {
            // Set again autofocus mode when app is resumed
            CameraDevice.Instance.SetFocusMode(
                CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
        }
    }

    void Start()
    {
        N_RED = gameObject.transform.Find("n_red").gameObject;
        N_RED.SetActive(false);
        u_green = gameObject.transform.Find("u_green").gameObject;
        u_green.SetActive(false);

        mImageTargetBehaviour = GetComponent<ImageTargetBehaviour>();
        var vuforia = VuforiaARController.Instance;
        vuforia.RegisterVuforiaStartedCallback(OnVuforiaStarted);
        vuforia.RegisterOnPauseCallback(OnPaused);

        congo = GetComponent<AudioSource>();
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
        /* if (time % 250 == 0)
         {
             Vector3 cornerInLocalRef = new Vector3(0.5f, 0, 0.5f);
             // Convert from local ref to world ref
             Vector3 cornerInWorldRef = this.transform.TransformPoint(cornerInLocalRef);
             // Convert from world ref to camera ref
             Vector3 cornerInCameraRef = Camera.main.transform.InverseTransformPoint(cornerInWorldRef);
             //		Debug.Log ("For A = " + cornerInCameraRef.y);
             if (cornerInCameraRef.y < 0)
             {
                 flip = 1;
                 Debug.Log("B                                      ");
                 Debug.Log("FLIP                =                  " + flip);
             }
             else
             {
                 flip = 2;
                 b_green = gameObject.transform.Find("b_green").gameObject;
                 b_green.SetActive(false);

                 Q_RED.SetActive(true);
                 Debug.Log("Q                                         ");
                 Debug.Log("FLIP                =                  " + flip);
             }
         }

         if ((flip == 1)  && (newStatus == TrackableBehaviour.Status.DETECTED ||
             newStatus == TrackableBehaviour.Status.TRACKED ||
             newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED) )
         {
             // Play audio when target is found
             congo.Play();
             Invoke("GoToScene", congo.clip.length + delay);

         }
         else
         {
             // Stop audio when target is lost
             congo.Stop();


         }*/
    }

    void Update()

    {
        flip = 0;
        StateManager sm = TrackerManager.Instance.GetStateManager();
        IEnumerable<TrackableBehaviour> activeTrackables = sm.GetActiveTrackableBehaviours();
        int count = 0;
        foreach (TrackableBehaviour tb in activeTrackables)
        {

            //               TRACKABLE NAME NEEDS TO BE CHANGED

            if (tb.TrackableName == "u_playcard")
                count = 1;
        }
        if (count == 1 && time % 50 == 0)
        {
            mImageTargetBehaviour = GetComponent<ImageTargetBehaviour>();

            if (mImageTargetBehaviour == null)
            {
                Debug.Log("ImageTargetBehaviour not found ");
                return;
            }
            Vector3 cornerInLocalRef = new Vector3(0.5f, 0, 0.5f);
            // Convert from local ref to world ref
            Vector3 cornerInWorldRef = this.transform.TransformPoint(cornerInLocalRef);
            // Convert from world ref to camera ref
            Vector3 cornerInCameraRef = Camera.main.transform.InverseTransformPoint(cornerInWorldRef);
            //		Debug.Log ("For A = " + cornerInCameraRef.y);
            if (cornerInCameraRef.y > 0)
            {
                flip = 1;
                Debug.Log("B                                      ");
                Debug.Log("FLIP                =                  " + flip + "          y:      " + cornerInCameraRef.y);
                N_RED.SetActive(false);

                u_green.SetActive(true);
                congo.Play();
                Invoke("GoToScene", congo.clip.length + delay);


            }
            else
            {
                flip = 2;
                congo.Stop();
                u_green = gameObject.transform.Find("u_green").gameObject;
                u_green.SetActive(false);

                N_RED.SetActive(true);
                Debug.Log("Q                                         ");
                Debug.Log("FLIP                =                  " + flip + "          y:      " + cornerInCameraRef.y);
            }

            if (flip != 1)

            {
                congo.Stop();
            }
        }


        time++;
    }

    void GoToScene()
    {
        SceneManager.LoadScene(scene_name);
    }
}
