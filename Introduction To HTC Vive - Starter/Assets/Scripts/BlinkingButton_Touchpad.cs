using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class BlinkingButton_Touchpad : MonoBehaviour {

    [Header("General Settings")]

    [Tooltip("The amount of time to take to transition to the set highlight colour.")]
    public float pulseDuration = 0.5f;

    [Tooltip("The colour to set the touchpad highlight colour to.")]
    public Color highlightColor = Color.clear;

    private VRTK_ControllerHighlighter highlighter;
    private VRTK_ControllerEvents events;
    private Color pulseColor = Color.clear;

    private bool hasBeenPressed = false;

    // Use this for initialization
    void Start ()
    {
        if (GetComponent<VRTK_ControllerEvents>() == null)
        {
            VRTK_Logger.Error(VRTK_Logger.GetCommonMessage(VRTK_Logger.CommonMessageKeys.REQUIRED_COMPONENT_MISSING_FROM_GAMEOBJECT, "VRTK_ControllerAppearance_Example", "VRTK_ControllerEvents", "the same"));
            return;
        }

        highlighter = GetComponent<VRTK_ControllerHighlighter>();

        highlighter.HighlightElement(SDK_BaseController.ControllerElements.Touchpad, highlightColor);
        events.TouchpadPressed += new ControllerInteractionEventHandler(DoTouchpadPressed);
    }
	
    private void DoTouchpadPressed(object sender, ControllerInteractionEventArgs e)
    {
        if (!hasBeenPressed)
        {
            highlighter.HighlightElement(SDK_BaseController.ControllerElements.Touchpad, highlightColor);
            VRTK_ObjectAppearance.SetOpacity(VRTK_DeviceFinder.GetModelAliasController(events.gameObject), 0.8f);
            hasBeenPressed = true;
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
