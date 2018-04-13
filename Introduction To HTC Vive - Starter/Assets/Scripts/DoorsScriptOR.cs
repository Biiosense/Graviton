using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsScriptOR : MonoBehaviour
{
    public List<MonoBehaviour> door_opening_objects;
    List<IDoorOpeningCondition> scripts;
    Animator anim;


    // Use this for initialization
    void Start()
    {
        anim = gameObject.GetComponentInChildren<Animator>();
        scripts = new List<IDoorOpeningCondition>();
        foreach (MonoBehaviour door_opening_object in door_opening_objects)
        {
            if (door_opening_object.GetComponent(typeof(IDoorOpeningCondition)))
                scripts.Add(door_opening_object.GetComponent(typeof(IDoorOpeningCondition)) as IDoorOpeningCondition);
            else
                Debug.LogError("Object " + door_opening_object.name + " has to have a script implementing interface IDoorOpeningCondition.");
        }

    }

    // Update is called once per frame
    void Update()
    {
        bool victory = true;
        foreach (Transform child in GetComponentsInChildren<Transform>())
            if (child.gameObject.name == "LED" && child.gameObject.GetComponent<Renderer>().GetComponent<Material>().color != Color.green)
                victory = false;
    }
}
