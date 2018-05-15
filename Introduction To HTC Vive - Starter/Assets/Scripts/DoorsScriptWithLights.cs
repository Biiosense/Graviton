using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsScriptWithLights : MonoBehaviour
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
        bool victory = true;
        foreach (Transform child in GetComponentsInChildren<Transform>())
            if (child.gameObject.name == "LED" && getLEDColor(child.gameObject) == Color.red)
                victory = false;
        
        anim.SetBool("won", victory);
    }

    static public Color getLEDColor(GameObject led)
    {
        return led.GetComponentInChildren<Renderer>().material.color;
        
    }
}
