using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using VRTK;

public class VictoryCondition_Level1 : MonoBehaviour, IVictoryCondition
{

    bool victory;
    VRTK_BasicTeleport script;
   
    // Use this for initialization
    void Start ()
    {
        script = GetComponent(typeof(VRTK_BasicTeleport)) as VRTK_BasicTeleport;
        script.Teleported += HandleTeleport;

    }

    void HandleTeleport(object sender, DestinationMarkerEventArgs e)
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
