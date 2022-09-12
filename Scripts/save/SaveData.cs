using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public float gallonsPerShower;
    public float flowRate;
    public float savedN;
    public float savedP;
    public float previous;

    public SaveData(TimerManager tm)
    {
        gallonsPerShower = tm.gallonsPerShower;
        flowRate = tm.showerHeadFlow;
        savedN = tm.savedN;
        savedP = tm.savedP;
        previous = tm.prevShower;
    }
}
