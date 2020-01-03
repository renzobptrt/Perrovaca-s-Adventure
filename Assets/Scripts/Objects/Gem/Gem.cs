using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{

    public int value;
    private GemManager manager;


    void Start()
    {
        manager = FindObjectOfType<GemManager>();
    }

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag.Equals("Player")){
            manager.AddGem(value);
            Destroy(gameObject);
        }
    }

}
