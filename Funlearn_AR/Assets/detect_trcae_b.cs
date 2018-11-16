using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class detect_trcae_b : MonoBehaviour {
    public Button btn11, btn12, btn13, btn14, btn15, btn16, btn17, btn18;
    int t1 = 0, t2 = 0, t3 = 0, t4 = 0, t5 = 0, t6 = 0, t7 = 0, t8 = 0;
    // Use this for initialization
    void Start () {
        Button btn1 = btn11.GetComponent<Button>();
        Button btn2 = btn12.GetComponent<Button>();
        Button btn3 = btn13.GetComponent<Button>();
        Button btn4 = btn14.GetComponent<Button>();
        Button btn5 = btn15.GetComponent<Button>();
        Button btn6 = btn16.GetComponent<Button>();
        Button btn7 = btn17.GetComponent<Button>();
        Button btn8 = btn18.GetComponent<Button>();
        //Calls the TaskOnClick method when you click the Button
        btn1.onClick.AddListener(TaskOnClick1);
        btn2.onClick.AddListener(TaskOnClick2);
        btn3.onClick.AddListener(TaskOnClick3);
        btn4.onClick.AddListener(TaskOnClick4);
        btn5.onClick.AddListener(TaskOnClick5);
        btn6.onClick.AddListener(TaskOnClick6);
        btn7.onClick.AddListener(TaskOnClick7);
        btn8.onClick.AddListener(TaskOnClick8);
        Debug.Log(t1);
        if (t1 == 1 && t2 == 1 && t3 == 1 && t7 == 1 && t8 == 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        //  m_YourSecondButton.onClick.AddListener(delegate { TaskWithParameters("Hello"); });
    }
    void TaskOnClick1()
    {
        t1 = 1;
        //Output this to console when the Button is clicked
        Debug.Log("You have clicked the button1!");
    }
    void TaskOnClick2()
    {
        t2 = 1;
        //Output this to console when the Button is clicked
        Debug.Log("You have clicked the button2!");
    }
    void TaskOnClick3()
    {
        t3 = 1;
        //Output this to console when the Button is clicked
        Debug.Log("You have clicked the button3!");
    }
    void TaskOnClick4()
    {
        t4 = 1;
        //Output this to console when the Button is clicked
        Debug.Log("You have clicked the button4!");
    }
    void TaskOnClick5()
    {
        t5 = 1;
        //Output this to console when the Button is clicked
        Debug.Log("You have clicked the button5!");
    }
    void TaskOnClick6()
    {
        t6 = 1;
        //Output this to console when the Button is clicked
        Debug.Log("You have clicked the button6!");
    }
    void TaskOnClick7()
    {
        t7 = 1;
        //Output this to console when the Button is clicked
        Debug.Log("You have clicked the button7!");
    }
    void TaskOnClick8()
    {
        t8 = 1;
        //Output this to console when the Button is clicked
        Debug.Log("You have clicked the button8!");
    }
    private void Update()
    {

        if (t1 == 1 && t2 == 1 && t5 == 1  && t8 == 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    // Update is called once per frame



}
