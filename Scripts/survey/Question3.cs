using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Question3 : MonoBehaviour
{
    public SurveyManager sm;
    public TMP_Text tmpText;
    public TMP_Text calc;

    private void OnEnable()
    {
        sm = FindObjectOfType<SurveyManager>();

        if (sm.flowPerMin * sm.showerTime > 16.8f)
        {
            tmpText.text = "Oh no! Your water usage is higher than the average American's usage (16.8 gallons per shower).";
        }
        else
        {
            tmpText.text = "Congratulations! Your water usage is lower than the average American's usage (16.8 gallons per shower).";
        }
        calc.text = "Your average water usage rate per shower is: \n" + (sm.flowPerMin * sm.showerTime) + " gallons.";
    }

    public void Continue()
    {
        sm.nextQuestion();
    }
}