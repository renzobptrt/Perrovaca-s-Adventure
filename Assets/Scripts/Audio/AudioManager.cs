using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{   
    public AudioSource[] audioTracks;

    public int currentTrack;
    public bool audioCantBePlayed;

    void Update()
    {
        if(audioCantBePlayed){
            if(!audioTracks[currentTrack].isPlaying){
                audioTracks[currentTrack].Play();
            }
        }
    }

    public void PlayNewTrack(int newTrack){
        audioTracks[currentTrack].Stop();
        currentTrack = newTrack;
        audioTracks[currentTrack].Play();
    }
}
