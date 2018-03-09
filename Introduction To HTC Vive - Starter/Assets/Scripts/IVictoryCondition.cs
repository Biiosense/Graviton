using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IVictoryCondition
{
    void setState(bool state);
    bool getState();
}
