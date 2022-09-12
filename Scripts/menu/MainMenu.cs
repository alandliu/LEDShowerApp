using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject alarmSettings;
    public GameObject showerSettings;
    public GameObject mainMenu;
    public GameObject GoalsScreen;

    public GameObject showerheadBtn;
    public GameObject alarmBtn;
    public GameObject exitBtn;
    
    public TimerManager tm;

    public static MainMenu instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ToTimer()
    {
        if (TimerManager.instance.firstTime)
        {
            SceneManager.LoadScene("FirstTime");
            TimerManager.instance.firstTime = false;
        }
        else if (!TimerManager.instance.isChallenge)
        {
            if (!TimerManager.instance.isTicking)
            {
                tm.startTimer(); //SceneManager.LoadScene("Timer");
                showerheadBtn.SetActive(false);
                alarmBtn.SetActive(false);
                exitBtn.SetActive(false);
            }
            else
            {
                TimerManager.instance.stopTimer();
                FromTimer();
            }
           
        }
        else SceneManager.LoadScene("Challenge");
    }

    public void FromTimer()
    {
        showerheadBtn.SetActive(true);
        alarmBtn.SetActive(true);
        exitBtn.SetActive(true);
    }

    public void QuitApp()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void ToGoals()
    {
        mainMenu.SetActive(false);
        GoalsScreen.SetActive(true);
    }

    public void FromGoals()
    {
        mainMenu.SetActive(true);
        GoalsScreen.SetActive(false);
    }

    public void ToAlarmSettings()
    {
        mainMenu.SetActive(false);
        alarmSettings.SetActive(true);
    }

    public void FromAlarmSettings()
    {
        alarmSettings.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void ToShowerSettings()
    {
        /*mainMenu.SetActive(false);
        alarmSettings.SetActive(true);*/
        SceneManager.LoadScene("FirstTime");
    }

    public void FromShowerSettings()
    {
        alarmSettings.SetActive(false);
        mainMenu.SetActive(true);
    }

}
