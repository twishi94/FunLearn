using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour {

    public Text uiText;
    public Button nextButton;
    public Button previousButton;


	// Use this for initialization
	void Start () {

        //int count = 0;

        //if (!PlayerPrefs.HasKey(SceneManager.GetActiveScene().name))
        //{
        //    PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, 0);
        //}

        //count = PlayerPrefs.GetInt(SceneManager.GetActiveScene().name);

        uiText.text = SceneManager.GetActiveScene().name; // + " : " + count;

        if(SceneController.Instance.IsFirstScene())
        {
            previousButton.gameObject.SetActive(false);
        }

        if(SceneController.Instance.IsLastScene())
        {
            nextButton.gameObject.SetActive(false);
        }

	}

    public void Next()
    {
        SceneController.Instance.LoadNext();
    }

    public void Previous()
    {
        SceneController.Instance.LoadPrevious();
    }
	
}
