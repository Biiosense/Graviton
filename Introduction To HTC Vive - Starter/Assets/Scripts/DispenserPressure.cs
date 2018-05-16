using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

using VRTK;

public class DispenserPressure : MonoBehaviour {


    new Renderer renderer;

    VRTK_InteractableObject eventScript;

    

    // Use this for initialization
    void Start ()
    {
        
        renderer = GetComponent<Renderer>();
        eventScript = GetComponent(typeof(VRTK_InteractableObject)) as VRTK_InteractableObject;
        eventScript.InteractableObjectTouched += handleEvent;
    }
	
	// Update is called once per frame
	void Update ()
    {
        renderer.material.color = Color.yellow;
    }

    void handleEvent(object sender, InteractableObjectEventArgs e)
    {
        renderer.material.color = Color.green;
        Spawn();
    }

    void Spawn()
    {
        Object prefab = UnityEditor.PrefabUtility.CreateEmptyPrefab("Assets/Prefabs/Objects/MovableObject.prefab");
        var pos = transform.position;
        pos.y += 1;
        pos.z += 1;
        //EditorUtility.ReplacePrefab(t.gameObject, prefab, ReplacePrefabOptions.ConnectToPrefab);
        Instantiate(prefab, pos, Quaternion.identity);
    }
}
