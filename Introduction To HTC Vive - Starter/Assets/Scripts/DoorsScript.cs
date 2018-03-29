using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsScript : MonoBehaviour
{
    public MonoBehaviour door_opening_object;
    IDoorOpeningCondition script;
    Animator anim;


    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        if (door_opening_object.GetComponent(typeof(IDoorOpeningCondition)))
            script = door_opening_object.GetComponent(typeof(IDoorOpeningCondition)) as IDoorOpeningCondition;
        else
            Debug.LogError("Object " + door_opening_object.name + " has to have a script implementing interface IDoorOpeningCondition.");
    }

    // Update is called once per frame
    void Update()
    {
        if (script != null)
        {
            anim.SetBool("won", script.getConditionStatus());
        }
    }
}
