using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreScript : MonoBehaviour {
    
    public enum Mode { continious, fix };
    public Mode mode;

	// Use this for initialization
	void Start () {
        if (mode == Mode.fix)
            setTime();
    }
	
	// Update is called once per frame
	void Update () {
        if (mode == Mode.continious)
            setTime();
    }

    private void setTime()
    {
        float timer = Time.realtimeSinceStartup;
        string minutes = Mathf.Floor(timer / 60).ToString("00");
        string seconds = (timer % 60).ToString("00");
        GetComponent<TextMesh>().text = string.Format("{0}:{1}", minutes, seconds);
    }
}
