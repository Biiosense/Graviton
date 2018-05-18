using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleScript : MonoBehaviour {

    public enum ColorName { white, blue, cyan, grey, gray, orange, purple, black };
    public ColorName color_name;
    Color color;

    new Renderer renderer;

    // Use this for initialization
    void Start ()
    {
        ColorUtility.TryParseHtmlString(color_name.ToString(), out color);
        renderer = GetComponent<Renderer>();
        renderer.material.color = color;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
