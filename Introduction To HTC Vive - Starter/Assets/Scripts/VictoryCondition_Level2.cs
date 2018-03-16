using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using VRTK;

public class VictoryCondition_Level2 : MonoBehaviour, IVictoryCondition
{

    bool victory;
    VRTK_BasicTeleport script;
   
    // Use this for initialization
    void Start ()
    {
        victory = true;

    }

    public bool getState()
    {
        return victory;
    }

    public void setState(bool state)
    {
        victory = state;
    }

}
