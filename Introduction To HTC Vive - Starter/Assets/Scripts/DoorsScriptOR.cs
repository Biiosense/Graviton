using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsScriptOR : MonoBehaviour
{
    Animator anim;


    // Use this for initialization
    void Start()
    {
        anim = gameObject.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool victory = false;
        foreach (Transform child in GetComponentsInChildren<Transform>())
            if (child.gameObject.name == "LED" && getLEDColor(child.gameObject) == Color.green)
                victory = true;
        
        anim.SetBool("won", victory);
    }

    static public Color getLEDColor(GameObject led)
    {
        return led.GetComponentInChildren<Renderer>().material.color;
        
    }
}
