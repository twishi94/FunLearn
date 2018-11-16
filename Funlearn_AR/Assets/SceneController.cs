using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {
    
    public static SceneController Instance;

    [System.Serializable]
    public class SceneData { 
        public string SceneName;
    }

    const int TOTALCOUNT = 16;

    [SerializeField]
    public List<SceneData> sceneDatas = new List<SceneData>(TOTALCOUNT);
    
    List<int> avaliablePos = new List<int>(TOTALCOUNT);

    int currentScene = 0;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
        
        Initialize();
    }

    private void Initialize()
    {
        List<int> newList = new List<int>(TOTALCOUNT);

        for (int i = 0; i < newList.Capacity; i++)
        {
            newList.Add(i);
        }

        int random;

        for (int i = 0; i < newList.Capacity; i++)
        {
            random = Random.Range(0, newList.Count);
            avaliablePos.Add(newList[random]);
            newList.Remove(newList[random]);
        }
    }
    
    public void LoadFirst()
    {
        string nextScene = sceneDatas[avaliablePos[currentScene]].SceneName;
        SceneManager.LoadScene(nextScene);
    }

    public void LoadNext()
    {
        if (currentScene < avaliablePos.Count - 1)
        {
            currentScene++;
            string nextScene = sceneDatas[avaliablePos[currentScene]].SceneName;
            SceneManager.LoadScene(nextScene);
        }
        else
        {
            print("can't go farward, last scene");
        }
    }

    public void LoadPrevious()
    {
        if(currentScene > 0)
        {
            currentScene--;
            string nextScene = sceneDatas[avaliablePos[currentScene]].SceneName;
            SceneManager.LoadScene(nextScene);
        }
        else
        {
            print("can't Go Back, first scene");
        }        
    }


    public bool IsLastScene()
    {
        return currentScene == avaliablePos.Count - 1;
    }

    public bool IsFirstScene()
    {
        return currentScene == 0;
    }

}
