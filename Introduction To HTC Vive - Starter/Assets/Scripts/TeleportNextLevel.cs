using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportNextLevel : MonoBehaviour {

    // BoxCollider collider;
    public string next_scene;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Head" && next_scene != "")
        {
            SteamVR_LoadLevel.Begin(next_scene);
        }
    }

}
