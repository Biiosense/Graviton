using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class ColorPickerScript : MonoBehaviour, IDoorOpeningCondition {

    private string[] color_names = new string[] { "white", "blue", "cyan", "grey", "orange", "purple", "black" };
    public MonoBehaviour capsule;
    private int color_id = 1;
    Color color;
    new Renderer renderer;
    float last_time_pressed;
    VRTK_InteractableObject eventScript;

    // Use this for initialization
    void Start () {
        renderer = GetComponent<Renderer>();
        ColorUtility.TryParseHtmlString(color_names[color_id], out color);
        last_time_pressed = 0.0f;
        eventScript = GetComponent(typeof(VRTK_InteractableObject)) as VRTK_InteractableObject;
        eventScript.InteractableObjectTouched += handleEvent;
    }

    // Update is called once per frame
    void Update () {
        ColorUtility.TryParseHtmlString(color_names[color_id], out color);
        renderer.material.color = color;
        if (last_time_pressed > 0.0f) 
            last_time_pressed -= Time.deltaTime;

    }

    void handleEvent(object sender, InteractableObjectEventArgs e)
    {
        if (last_time_pressed <= 0.0f)
        {
            last_time_pressed = 0.5f;
            color_id++;
            color_id = color_id % color_names.Length;
        }
    }
    
    public bool getConditionStatus()
    {
        Renderer capsuleRenderer = capsule.gameObject.GetComponent<Renderer>();
        return capsuleRenderer.material.color.Equals(renderer.material.color);
    }

}
