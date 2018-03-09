using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsScript : MonoBehaviour {

    Animator anim;
    

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        bool won;
        won = true;
        anim.SetBool("won", won);
	}
}
