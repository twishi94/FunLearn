using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour {

    public bool islastInSequence;
    public string nextSceneName;

    public void LoadByIndex(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void LoadByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void SwitchToLearn()
    {
        SceneMan.Instance.SwitchToLearn();
    }

    public void SwitchToQuestion()
    {
        SceneMan.Instance.SwitchToQuestion();
    }

    public void LoadNext()
    {
        if (!islastInSequence)
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            SceneMan.Instance.LoadNext();
        }
    }

    public void LoadPrevious()
    {
        SceneMan.Instance.LoadPrevious();
    }

}
