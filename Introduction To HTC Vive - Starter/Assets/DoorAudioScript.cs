using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAudioScript : MonoBehaviour {

    Animator animator;
    AudioSource audioSource;
    
    void Start ()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        AnimationClip clip;
        
        AnimationEvent eventPlay = new AnimationEvent();
        eventPlay.functionName = "PlayAudio";
        clip = animator.runtimeAnimatorController.animationClips[0];
        clip.AddEvent(eventPlay);

        AnimationEvent eventPlayBackward = new AnimationEvent();
        eventPlayBackward.functionName = "PlayAudioBackward";
        clip = animator.runtimeAnimatorController.animationClips[1];
        clip.AddEvent(eventPlayBackward);
    }
    
    public void PlayAudio()
    {
        audioSource.timeSamples = 0;
        audioSource.pitch = 1.2f;
        audioSource.Play();
    }

    public void PlayAudioBackward()
    {
        audioSource.timeSamples = audioSource.clip.samples -1;
        audioSource.pitch = -1;
        audioSource.Play();
    }
}
