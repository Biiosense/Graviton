using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LEDColor : MonoBehaviour
{
    public List<MonoBehaviour> door_opening_objects;
    List<IDoorOpeningCondition> scripts;

    // Use this for initialization
    void Start ()
    {
        scripts = new List<IDoorOpeningCondition>();
        foreach (MonoBehaviour obj in door_opening_objects)
        {
            if (obj.GetComponent(typeof(IDoorOpeningCondition)))
                scripts.Add(obj.GetComponent(typeof(IDoorOpeningCondition)) as IDoorOpeningCondition);
            else
                Debug.LogError("Object " + obj.name + " has to have a script implementing interface IDoorOpeningCondition.");
        }
            

    }

    // Update is called once per frame
    void Update ()
    {
        bool victory = false;
        foreach(IDoorOpeningCondition script in scripts)
            if (script.getConditionStatus())
                victory = true;

        if (victory)
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


    static public T getScript<T>(MonoBehaviour obj) where T : MonoBehaviour
    {
        if (obj.GetComponent(typeof(T)))
            return obj.GetComponent(typeof(T)) as T;
        else
            throw new System.ArgumentException("Object " + obj.name + " doesn't have script of type " + typeof(T).Name + " attached.");
    }
}
