using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacingCameraScript : MonoBehaviour {

    public MonoBehaviour camera;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.LookAt(camera.transform);
        gameObject.transform.Rotate(new Vector3(90, 0, 0));

    }
}
