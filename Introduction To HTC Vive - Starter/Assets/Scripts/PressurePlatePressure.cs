using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlatePressure : MonoBehaviour, IDoorOpeningCondition {

    int objects_triggered_count;
    new Renderer renderer;

    // Use this for initialization
    void Start ()
    {
        objects_triggered_count = 0;
        renderer = GetComponent<Renderer>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (objects_triggered_count > 0)
            renderer.material.color = Color.green;
        else
            renderer.material.color = Color.red;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "MovableObject")
        {
            objects_triggered_count++;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "MovableObject")
        {
            objects_triggered_count--;
        }
    }

    public bool getConditionStatus()
    {
        return renderer.material.color == Color.green;
    }
}
