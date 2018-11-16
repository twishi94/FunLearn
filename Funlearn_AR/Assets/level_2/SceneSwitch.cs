using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour {

    public string nextSceneName;
    public float delay;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void LoadNextScene()
    {
        Invoke("_loadNextScene", audioSource.clip.length + delay);
    }

    private void _loadNextScene()
    {
        if (nextSceneName != null)
            SceneManager.LoadScene(nextSceneName);
    }

}
