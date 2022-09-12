using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalMenu : MonoBehaviour
{

    Button cButton;
    Button ncButton;

    public Image sCButton;
    public Image sNcButton;


    private void OnEnable()
    {
        if (sCButton == null)
        {
            sCButton = GetComponent<Image>();
        }
        if (sNcButton == null)
        {
            sNcButton = GetComponent<Image>();
        }

        if (TimerManager.instance.isChallenge)
        {
            setCButton();
        }
        else
        {
            setNcButton();
        }
    }

    public void setCButton()
    {
        sNcButton.color = new Color(1f, 1f, 1f);
        sCButton.color = new Color(0f, 0f, 0f);
        TimerManager.instance.isChallenge = true;
    }

    public void setNcButton()
    {
        sCButton.color = new Color(1f, 1f, 1f);
        sNcButton.color = new Color(0f, 0f, 0f);
        TimerManager.instance.isChallenge = false;
    }
}
