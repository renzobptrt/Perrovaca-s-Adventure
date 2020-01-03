using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioVolumenController : MonoBehaviour
{

    private AudioSource audioSource;
    private float currentAudioLevel;
    public float defaultAudioLevel;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }

    public void SetAudioLevel(float newVolumen){
        if(audioSource == null){
            audioSource = GetComponent<AudioSource>();
        }
        currentAudioLevel = defaultAudioLevel * newVolumen;
        audioSource.volume = currentAudioLevel;
    }

    public float GetAudioLevel(){
        return defaultAudioLevel;
    }
}
