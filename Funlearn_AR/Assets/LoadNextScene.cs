using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour {
    
    public bool islastInSequence;
    public string nextSceneName;

	// Use this for initialization
	void Start () {

        //if(!PlayerPrefs.HasKey(SceneManager.GetActiveScene().name))
        //{
        //    PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, 0);
        //}
        //else
        //{
        //    PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, PlayerPrefs.GetInt(SceneManager.GetActiveScene().name) + 1);
        //}
        
        Invoke("LoadNext", 2);

	}
	
    void LoadNext()
    {
        if(!islastInSequence)
        {
            SceneManager.LoadScene(nextSceneName);
        }
        //else
        //{
        //    SceneController.Instance.LoadNext();
        //}
    }
}
