using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SurveyManager : MonoBehaviour
{

    public float showerTime;
    public float flowPerMin;

    public GameObject[] questions;
    public int curQuestionInd;

    public GameObject mm;

    

    private void Start()
    {
        curQuestionInd = 0;
        mm = FindObjectOfType<MainMenu>().gameObject;
        mm.SetActive(false);
    }

    public void nextQuestion()
    {
        questions[curQuestionInd].SetActive(false);
        if (curQuestionInd < questions.Length - 1)
        {
            curQuestionInd++;
            questions[curQuestionInd].SetActive(true);
        }
    }

    public void prevQuestion()
    {
        questions[curQuestionInd].SetActive(false);
        if (curQuestionInd > 0)
        {
            curQuestionInd--;
            questions[curQuestionInd].SetActive(true);
        }
    }
}
