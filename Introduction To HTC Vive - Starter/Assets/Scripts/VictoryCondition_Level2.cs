using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using VRTK;

public class VictoryCondition_Level2 : MonoBehaviour, IDoorOpeningCondition
{

    bool victory;
    VRTK_BasicTeleport script;
   
    // Use this for initialization
    void Start ()
    {
        victory = true;

    }

    public bool getConditionStatus()
    {
        return victory;
    }
}
