using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Globalization;

public class InputNumber : MonoBehaviour
{
    public string iShowerTime;
    public GameObject inputField;
    public GameObject errorField;
    
    public SurveyManager sm;

    private float floatValue;


    public void takeFPM()
    {
        iShowerTime = inputField.GetComponent<Text>().text;
        Debug.Log("initial shower length set to " + iShowerTime);
        if (float.TryParse(iShowerTime, out floatValue) && float.Parse(iShowerTime, CultureInfo.InvariantCulture.NumberFormat) <= 60f)
        {
            sm.showerTime = float.Parse(iShowerTime, CultureInfo.InvariantCulture.NumberFormat);
            errorField.SetActive(false);
            sm.nextQuestion();
        } else
        {
            errorField.SetActive(true);
        }
    }
}
