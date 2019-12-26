using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageToPlayer : MonoBehaviour
{   

    /*public float timeToRevivePlayer;
    private float timeRivalvalCounter;
    private bool playerReviving;

    private GameObject thePlayer;*/

    public int damage;

    // Update is called once per frame
    /*void Update()
    {
        if(playerReviving){
            timeRivalvalCounter -= Time.deltaTime;
            if(timeRivalvalCounter < 0 ){
                playerReviving = false;
                thePlayer.SetActive(true);
            }
        }
    }*/

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag.Equals("Player")){
            //Colision entre enemigo y jugador
            /*collision.gameObject.SetActive(false);
            playerReviving = true;
            timeRivalvalCounter = timeToRevivePlayer;
            thePlayer = collision.gameObject;*/
            collision.gameObject.GetComponent<HealthManager>().DamageCharacter(damage);  
        }
    }
}
