using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportNextLevel : MonoBehaviour {

    // BoxCollider collider;
    public string next_scene;

    // Use this for initialization
    void Start ()
    {
    //   collider = GetComponent<BoxCollider>();
	}
	
	// Update is called once per frame
	void Update ()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Head" && next_scene != "")
        {
            /*
            AssetBundle assetBundle = AssetBundle.LoadFromFile("Assets/Scenes/");
            string[] scenesPath = assetBundle.GetAllScenePaths();
            System.IO.Directory.GetDirectoryRoot(Application.dataPath + "Assets/Scenes/");

            foreach (string scene in scenesPath)
                Debug.Log(scene);
            */
          //  SceneManager.LoadScene(next_scene, LoadSceneMode.Single);
            SteamVR_LoadLevel.Begin(next_scene);
        }
    }

}
