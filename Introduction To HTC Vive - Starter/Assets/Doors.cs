using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour {

    // Use this for initialization
    Animator animator;
    bool doorOpen;

    void Start()
    {
        doorOpen = false;
        animator = GetComponent<Animator>();

    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            doorOpen = true;
            DoorDirection("Open");
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (doorOpen)
        {
            doorOpen = false;
            DoorDirection("Close");
        }
    }

    void DoorDirection(string direction)
    {
        animator.SetTrigger(direction);
    }
}
