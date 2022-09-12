using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{

    public Image[] alarmButtons;

    private void OnEnable()
    {
        selectButton(TimerManager.instance.curAlarmInd);
    }


    public void selectButton(int index)
    {
        alarmButtons[TimerManager.instance.curAlarmInd].color = new Color(1f, 1f, 1f);
        TimerManager.instance.curAlarmInd = index;
        alarmButtons[index].color = new Color(0.5f, 0.5f, 0.5f);
        //AudioManager.instance.Play(TimerManager.instance.alarms[TimerManager.instance.curAlarmInd]);
        Debug.Log(TimerManager.instance.alarms[TimerManager.instance.curAlarmInd]);
    }

}
