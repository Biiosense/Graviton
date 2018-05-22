using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

using VRTK;

public class DispenserPressure : MonoBehaviour
{

    public enum ColorName { white, blue, cyan, grey, magenta, orange, purple, yellow };
    public ColorName color_name;
    Color color;

    MonoBehaviour curr_cube;

    new Renderer renderer;
    float time_last_pushed;
    VRTK_InteractableObject eventScript;

    // Use this for initialization
    void Start()
    {
        curr_cube = null;
        renderer = GetComponent<Renderer>();
        ColorUtility.TryParseHtmlString(color_name.ToString(), out color);
        time_last_pushed = 0.0f;
        eventScript = GetComponent(typeof(VRTK_InteractableObject)) as VRTK_InteractableObject;
        eventScript.InteractableObjectTouched += handleEvent;
    }

    // Update is called once per frame
    void Update()
    {
        if (time_last_pushed > 0.0f)
        {
            renderer.material.color = Color.green;
            time_last_pushed -= Time.deltaTime;
        }
        else
            renderer.material.color = color;

    }

    void handleEvent(object sender, InteractableObjectEventArgs e)
    {
        if (time_last_pushed <= 0.0f)
        {
            time_last_pushed = 0.5f;
            Spawn();
        }
    }

    void Spawn()
    {
        if (curr_cube != null)
            Destroy(curr_cube.gameObject);

        Vector3 pos = transform.position;
        pos += new Vector3(0, 1, Mathf.Sign(pos.y));
        curr_cube = Instantiate(Resources.Load<MonoBehaviour>("MovableObject"), pos, Quaternion.identity);

        if (color_name.ToString() != "white")
            curr_cube.GetComponent<Renderer>().material.color = color;
    }
}
