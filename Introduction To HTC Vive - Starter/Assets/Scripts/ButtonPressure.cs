using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using VRTK;

public class ButtonPressure : MonoBehaviour, IDoorOpeningCondition {

    bool activated;
    new Renderer renderer;

    VRTK_InteractableObject eventScript;


	// Use this for initialization
	void Start () {
        activated = false;
        renderer = GetComponent<Renderer>();
        eventScript = GetComponent(typeof(VRTK_InteractableObject)) as VRTK_InteractableObject;
        eventScript.InteractableObjectTouched += handleEvent;

    }
	
	// Update is called once per frame
	void Update () {
        if (activated)
            renderer.material.color = Color.green;
        else
            renderer.material.color = Color.red;
    }

    void handleEvent(object sender, InteractableObjectEventArgs e)
    {
        activated = !activated;
    }

    public bool getConditionStatus()
    {
        return activated;
    }
}
