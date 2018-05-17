using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlatePressure : MonoBehaviour, IDoorOpeningCondition {
    
    new Renderer renderer;
    float last_time_pressed;

    // Use this for initialization
    void Start ()
    {
        renderer = GetComponent<Renderer>();
        last_time_pressed = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (last_time_pressed > 0)
        {
            renderer.material.color = Color.green;
            last_time_pressed -= Time.deltaTime;
        }
        else
            renderer.material.color = Color.red;
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "MovableObject")
        {
            last_time_pressed = 0.1f;
        }
    }
    

    public bool getConditionStatus()
    {
        return renderer.material.color == Color.green;
    }
}
