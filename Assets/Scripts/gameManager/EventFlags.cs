using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



[System.Serializable]
public class EventFlags
{
    public bool hasTractor;
    public bool hasRapid;
    public bool hasBank;
    public bool hasSlip;

    public int currentSavePoint;

    public EventFlags()
    {
        hasTractor = false;
        hasRapid = false;
        hasBank = false;
        hasSlip = false;

        currentSavePoint = 0;
    }


}
