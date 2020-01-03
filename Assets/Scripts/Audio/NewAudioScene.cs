using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewAudioScene : MonoBehaviour
{
    private AudioManager audioManager;
    public int newAudioID;
    public bool playOnStart;

    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        if(playOnStart){
            audioManager.PlayNewTrack(newAudioID);
        }
    }

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag.Equals("Player")){
            audioManager.PlayNewTrack(newAudioID);
            gameObject.SetActive(false);
        }
    }
}
