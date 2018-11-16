using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMan : MonoBehaviour {
    
    public static SceneMan Instance;

    [System.Serializable]
    public class SceneData { 
        public string SceneName;
    }

    [System.Serializable]
    public class GameType
    {
        [SerializeField]
        public List<SceneData> sceneDatas;
        
        public List<int> avaliablePos { get; private set; }
        public int currentScene { get; set; }

        public int SceneCount { get; private set; }

        public void InitilaizeMembers(int sceneCount)
        {
            SceneCount = sceneCount;
            currentScene = 0;
            // we'll initialize this through editor
            //sceneDatas = new List<SceneData>(sceneCount);
            avaliablePos = new List<int>(sceneCount);
        }
    }

    [SerializeField]
    public GameType questionGames;
    [SerializeField]
    public GameType learnGames;

    GameType currentGameType;


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

        if(questionGames.sceneDatas.Count > 0)
        {
            questionGames.InitilaizeMembers(questionGames.sceneDatas.Count);
        }

        if (learnGames.sceneDatas.Count > 0)
        {
            learnGames.InitilaizeMembers(learnGames.sceneDatas.Count);
        }

        // make sure both avaliable list are initilized and random
        currentGameType = learnGames;
        Randomize();
        currentGameType = questionGames;
        Randomize();
    }

    public void SwitchToQuestion()
    {
        currentGameType = questionGames;
        LoadFirst();
    }

    public void SwitchToLearn()
    {
        currentGameType = learnGames;
        LoadFirst();
    }

    private void Randomize()
    {
        List<int> newList = new List<int>(currentGameType.SceneCount);

        for (int i = 0; i < newList.Capacity; i++)
        {
            newList.Add(i);
        }

        int random;

        for (int i = 0; i < newList.Capacity; i++)
        {
            random = Random.Range(0, newList.Count);
            currentGameType.avaliablePos.Add(newList[random]);
            newList.Remove(newList[random]);
        }
    }
    
    public void LoadFirst()
    {
        string nextScene = currentGameType.sceneDatas[currentGameType.avaliablePos[currentGameType.currentScene]].SceneName;
        SceneManager.LoadScene(nextScene);
    }

    public void LoadNext()
    {
        if (currentGameType.currentScene < currentGameType.avaliablePos.Count - 1)
        {
            currentGameType.currentScene++;
            string nextScene = currentGameType.sceneDatas[currentGameType.avaliablePos[currentGameType.currentScene]].SceneName;
            SceneManager.LoadScene(nextScene);
        }
        else
        {
            print("can't go farward, last scene");
            SceneManager.LoadScene(0);
        }
    }

    public void LoadPrevious()
    {
        if(currentGameType.currentScene > 0)
        {
            currentGameType.currentScene--;
            string nextScene = currentGameType.sceneDatas[currentGameType.avaliablePos[currentGameType.currentScene]].SceneName;
            SceneManager.LoadScene(nextScene);
        }
        else
        {
            print("can't Go Back, first scene");
            SceneManager.LoadScene(0);
        }        
    }


    public bool IsLastScene()
    {
        return currentGameType.currentScene == currentGameType.avaliablePos.Count - 1;
    }

    public bool IsFirstScene()
    {
        return currentGameType.currentScene == 0;
    }

}
