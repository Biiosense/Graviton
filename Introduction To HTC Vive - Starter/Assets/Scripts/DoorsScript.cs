using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsScript : MonoBehaviour {

    public MonoBehaviour obj;
    Animator anim;
    IVictoryCondition script;


	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        script = obj.GetComponent(typeof(IVictoryCondition)) as IVictoryCondition;
    }
	
	// Update is called once per frame
	void Update () {
        anim.SetBool("won", script.getState());
	}
}
