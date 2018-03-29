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
        anim = GetComponent<Animator>();
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
        if (scripts.Count > 0)
        {
            bool victory = false;
            foreach (IDoorOpeningCondition script in scripts)
                victory |= script.getConditionStatus();
            anim.SetBool("won", victory);
        }
    }
}
