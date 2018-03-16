using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsScript : MonoBehaviour {

    public MonoBehaviour victory_object;
    Animator anim;
    IVictoryCondition script;


	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();
        if (victory_object.GetComponent(typeof(IVictoryCondition)))
        {
            script = victory_object.GetComponent(typeof(IVictoryCondition)) as IVictoryCondition;
        }
        else
        {
            Debug.LogError("Victory Object has to have a script implementing interface IVictoryCondition.");
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(script!=null)
            anim.SetBool("won", script.getState());
	}
}
