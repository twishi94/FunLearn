using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mono.Csv;
using System;
using System.Text;

using UnityEngine.EventSystems;

public class LogManager : MonoBehaviour {

    public static LogManager Instance { get; private set; }

    public string mainSceneName;

    EventSystem eventSystem;
    GameObject selectedObject;

    bool fileInitialized = false;

    string fullpath;

    List<List<string>> data = new List<List<string>>();
    
    int lineIndex = 0;
    
    private static string GetPath()
    {
        #if UNITY_EDITOR
            return Application.persistentDataPath + "/";
        #elif UNITY_ANDROID
            return Application.persistentDataPath;
        #elif UNITY_IPHONE
            return Application.persistentDataPath+"/";
        #else
            return Application.dataPath +"/";
        #endif
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            SceneManager.activeSceneChanged += OnSceneChanged;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }
    
    void OnSceneChanged(Scene current, Scene next)
    {
        if(next.name == mainSceneName)
        {
            if(!fileInitialized)
            {
                fileInitialized = true;
                SetFullPath();
            }
            else
            {
                WriteAndClose();
            }
        }
        else
        {
            CheckSceneLineIndex();

            if (lineIndex == 0)
            {
                List<string> nextString = new List<string>
                {
                    SceneManager.GetActiveScene().name
                };

                data.Add(nextString);
            }
        }

        eventSystem = FindObjectOfType<EventSystem>();
    }

    // Use this for initialization
    void Start ()
    {
        eventSystem = FindObjectOfType<EventSystem>();
    }
	
    void SetFullPath()
    {
        string time = System.DateTime.Now.TimeOfDay.Hours + "_" + System.DateTime.Now.TimeOfDay.Minutes + "_" + System.DateTime.Now.TimeOfDay.Seconds;
        string filename = "Log_" + time + ".csv";
        fullpath = GetPath() + filename;

        List<string> nextString = new List<string>
            {
                SceneManager.GetActiveScene().name
            };

        data.Add(nextString);
    }

	// Update is called once per frame
	void Update () {

        if (eventSystem.currentSelectedGameObject == null)
        {
            return;
        }
        else if(selectedObject != eventSystem.currentSelectedGameObject)
        {
            selectedObject = eventSystem.currentSelectedGameObject;
            eventSystem.currentSelectedGameObject.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(new UnityEngine.Events.UnityAction(OnClick));
        }
    }

    void OnClick()
    {
        if(SceneManager.GetActiveScene().name != mainSceneName)
        {
            CheckSceneLineIndex();

            List<string> str = data[lineIndex];

            int value = 0;

            int index = 0;

            for (int i = 0; i < str.Count; i++)
            {
                if(str[i].Contains(selectedObject.gameObject.name))
                {
                    Int32.TryParse(str[i][str[i].Length - 1].ToString(), out value);
                    index = i;
                    break;
                }
            }

            if (value == 0)
            {
                data[lineIndex].Add(selectedObject.gameObject.name + " : " + "1");
            }
            else
            {
                data[lineIndex][index] = (selectedObject.gameObject.name + " : " + (value + 1));
            }                        
        }
    }


    void WriteAndClose()
    {
        CsvFileWriter fileWriter = new CsvFileWriter(@fullpath);

        foreach (var item in data){
            fileWriter.WriteRow(item);
        }

        fileWriter.Dispose();
        lineIndex = 0;
        data.Clear();
        SetFullPath();
    }

    void CheckSceneLineIndex()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        lineIndex = 0;

        for (int i = 0; i < data.Count; i++){
            if (data[i][0] == sceneName){
                lineIndex = i;
            }
        }
    }
}
