using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Question4 : MonoBehaviour
{
    public SurveyManager sm;
    public TimerManager tm;
    public TMP_Text tmpText;
    public TMP_Text calc;
    public int min;
    public int sec;

    private void OnEnable()
    {
        sm = FindObjectOfType<SurveyManager>();
        tm = FindObjectOfType<TimerManager>();

        min = (int) Mathf.Floor(16.8f / sm.flowPerMin);
        sec = (int) Mathf.Floor(((16.8f / sm.flowPerMin) - min) * 60);
        tmpText.text = "I challenge you to reduce your shower time to: \n " + min + " minutes and " + sec + " seconds at most!";

    }

    public void Continue()
    {
        //sm.nextQuestion();
        sm.mm.SetActive(true);
        tm.showerHeadFlow = sm.flowPerMin;
        tm.gallonsPerShower = sm.flowPerMin * sm.showerTime;
        SceneManager.LoadScene("Menu");
    }
}
