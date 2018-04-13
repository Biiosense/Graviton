using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LEDColor : MonoBehaviour {

    public MonoBehaviour door_opening_object;
    IDoorOpeningCondition script;

    // Use this for initialization
    void Start () {
        if (door_opening_object.GetComponent(typeof(IDoorOpeningCondition)))
            script = door_opening_object.GetComponent(typeof(IDoorOpeningCondition)) as IDoorOpeningCondition;
        else
            Debug.LogError("Object " + door_opening_object.name + " has to have a script implementing interface IDoorOpeningCondition.");

    }

    // Update is called once per frame
    void Update ()
    {
        if (script.getConditionStatus())
            foreach (Transform child in GetComponentsInChildren<Transform>())
                child.gameObject.GetComponent<Renderer>().GetComponent<Material>().color = Color.green;
        else
            foreach (Transform child in GetComponentsInChildren<Transform>())
                child.gameObject.GetComponent<Renderer>().GetComponent<Material>().color = Color.red;
    }
}
