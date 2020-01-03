using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioVolumeManager : MonoBehaviour
{
    
    private AudioVolumenController[] audios;
    public float maxVolumeLevel;
    public float currentVolumeLevel; 

    void Start()
    {
        audios = FindObjectsOfType<AudioVolumenController>();
        ChangeGlobalAudioVolume();
    }

    void Update(){
        ChangeGlobalAudioVolume();
    }

    public void ChangeGlobalAudioVolume(){
        if(currentVolumeLevel >= maxVolumeLevel){
            currentVolumeLevel = maxVolumeLevel;
        }
        if(currentVolumeLevel <= 0){
            currentVolumeLevel = 0;
        }
        foreach(AudioVolumenController avc in audios){
            avc.SetAudioLevel(currentVolumeLevel);
        }
    }

}
