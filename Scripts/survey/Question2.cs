using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Globalization;

public class Question2 : MonoBehaviour
{
    public string iFlowRate;
    public GameObject inputField;
    public GameObject errorField;

    public SurveyManager sm;

    private float floatValue;

    public void setDefault()
    {
        sm.flowPerMin = 2.1f;
        errorField.SetActive(false);
        sm.nextQuestion();
    }

    public void takeFPM()
    {
        iFlowRate = inputField.GetComponent<Text>().text;
        Debug.Log("initial flow rate set to " + iFlowRate);
        if (float.TryParse(iFlowRate, out floatValue) && float.Parse(iFlowRate, CultureInfo.InvariantCulture.NumberFormat) <= 10.0f)
        {
            sm.flowPerMin = float.Parse(iFlowRate, CultureInfo.InvariantCulture.NumberFormat);
            errorField.SetActive(false);
            sm.nextQuestion();
        }
        else
        {
            errorField.SetActive(true);
        }
    }
}
