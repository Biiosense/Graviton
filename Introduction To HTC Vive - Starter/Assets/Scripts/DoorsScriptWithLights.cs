using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsScriptWithLights : MonoBehaviour
{
    Animator[] anims;

    // Use this for initialization
    void Start()
    {
        anims = gameObject.GetComponentsInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool victory = true;
        foreach (Transform child in GetComponentsInChildren<Transform>())
            if (child.gameObject.name == "LED" && getLEDColor(child.gameObject) != Color.green)
                victory = false;
        
        foreach(Animator anim in anims)
            anim.SetBool("won", victory);
    }

    static public Color getLEDColor(GameObject led)
    {
        return led.GetComponentInChildren<Renderer>().material.color;
        
    }
}
