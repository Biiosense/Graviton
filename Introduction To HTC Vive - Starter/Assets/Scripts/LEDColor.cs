using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LEDColor : MonoBehaviour, IDoorOpeningCondition
{
    public List<MonoBehaviour> door_opening_objects;
    public List<MonoBehaviour> door_closing_objects;

    List<IDoorOpeningCondition> door_opening_scripts;
    List<IDoorOpeningCondition> door_closing_scripts;

    // Use this for initialization
    void Start()
    {
        getScripts(door_opening_objects, out door_opening_scripts);
        getScripts(door_closing_objects, out door_closing_scripts);
    }

    // Update is called once per frame
    void Update()
    {
        bool blocked = false;
        foreach (IDoorOpeningCondition script in door_closing_scripts)
            if (script.getConditionStatus())
                blocked = true;

        bool victory = false;
        foreach (IDoorOpeningCondition script in door_opening_scripts)
            if (script.getConditionStatus())
                victory = true;

        if (victory && !blocked)
            setLEDColor(this.gameObject, Color.green);
        else
            setLEDColor(this.gameObject, Color.red);
    }

    static public void setLEDColor(GameObject led, Color color)
    {
        foreach (Transform child in led.GetComponentsInChildren<Transform>())
            if (child != led.transform)
                child.gameObject.GetComponent<Renderer>().material.color = color;
    }

    static public Color getLEDColor(GameObject led)
    {
        Color color = Color.red;
        foreach (Transform child in led.GetComponentsInChildren<Transform>())
            if (child != led.transform)
                color = child.gameObject.GetComponent<Renderer>().material.color;
        return color;
    }

    private void getScripts(List<MonoBehaviour> objects, out List<IDoorOpeningCondition> scripts)
    {
        scripts = new List<IDoorOpeningCondition>();
        foreach (MonoBehaviour obj in objects)
        {
            if (obj.GetComponent(typeof(IDoorOpeningCondition)))
                scripts.Add(obj.GetComponent(typeof(IDoorOpeningCondition)) as IDoorOpeningCondition);
            else
                Debug.LogError("Object " + obj.name + " has to have a script implementing interface IDoorOpeningCondition.");
        }
    }

    public bool getConditionStatus()
    {
        return getLEDColor(this.gameObject) == Color.green;
    }
}

