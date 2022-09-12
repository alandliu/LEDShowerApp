using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{
    public bool firstTime = true;
    public static TimerManager instance;
    public bool isChallenge = false;
    public TMP_Text timetxt;
    public TMP_Text gallontxt;

    public string[] alarms;
    public int curAlarmInd = 0;
    public Image btnImage;
    public Sprite unpressedBtn;
    public Sprite pressedBtn;

    public int curSeconds;
    public bool isTicking = false;
    public bool pastAlarm = false;
    public float showerHeadFlow;
    public float gallonsPerShower;

    private string placeholder;

    public float curGallon;
    public float prevShower = 0f;
    public float savedN = 0f;
    public float savedP = 0f;
    public GameObject saved;
    public TMP_Text prevText;
    public TMP_Text errorText;
    public TMP_Text national;
    public TMP_Text personal;
    

    private void Awake()
    {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (btnImage == null)
        {
            btnImage = GameObject.FindGameObjectWithTag("timer").GetComponent<Image>();
        }
        if (isTicking)
        {
            curGallon += showerHeadFlow * Time.deltaTime / 60;
            gallontxt.text = System.Math.Round(curGallon, 2) + "";
        }
    }

    public void startTimer()
    {
        if (isTicking) stopTimer();
        saved.SetActive(false);
        errorText.gameObject.SetActive(false);
        pastAlarm = false;
        curGallon = 0f;
        isTicking = true;
        curSeconds = 0;

        btnImage.sprite = pressedBtn;

        prevText.gameObject.SetActive(false);
        gallontxt.gameObject.SetActive(true);
        timetxt.gameObject.SetActive(true);
        timetxt.text = calcTime(curSeconds);

        StartCoroutine(addSecond());
    }

    public void stopTimer()
    {
        isTicking = false;

        //check < 60 s
        AudioManager.instance.Stop(alarms[curAlarmInd]);
        prevText.gameObject.SetActive(true);
        timetxt.gameObject.SetActive(false);
        gallontxt.gameObject.SetActive(false);
        saved.SetActive(true);
        btnImage.sprite = unpressedBtn;

        timetxt.color = new Color(0f, 0f, 0f);
        gallontxt.color = new Color(1f, 1f, 1f);

        if (curSeconds < 60)
        {
            errorText.gameObject.SetActive(true);
            return;
        }

        prevShower = curGallon;
        savedN += 16.8f - curGallon;
        savedP += gallonsPerShower - curGallon;
        prevText.text = "Previous: \n" + System.Math.Round(prevShower, 2);
        national.text = "NATIONAL \n" + System.Math.Round(savedN, 2);
        personal.text = "PERSONAL \n" + System.Math.Round(savedP, 2);
    }

    IEnumerator addSecond()
    {
        yield return new WaitForSeconds(1f);
        curSeconds++;
        if (curGallon >= 16.8f && !pastAlarm)
        {
            AudioManager.instance.Play(alarms[curAlarmInd]);
            timetxt.color = new Color(0.78f, 0.31f, 0.31f);
            gallontxt.color = timetxt.color;
            pastAlarm = true;
        }
        if (isTicking) StartCoroutine(addSecond());
        timetxt.text = calcTime(curSeconds);
    }

    public string calcTime(int curSec)
    {
        placeholder = "";
        if (curSec / 60 < 10)
        {
            placeholder += "0";
        }
        placeholder += (curSec / 60) + ":";
        if (curSec % 60 < 10)
        {
            placeholder += "0";
        }
        placeholder += (curSec % 60);
        return placeholder;
    }
}
