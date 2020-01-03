using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageToPlayer : MonoBehaviour
{   
    public int damage;

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag.Equals("Player")){
            
            //For less damage with player defense
            CharacterStats stast = collision.gameObject.GetComponent<CharacterStats>();
            int totalDamage = damage - stast.defenseLevels[stast.currentLevel];
            if(totalDamage < 0){
                totalDamage = 1;
            }
            collision.gameObject.GetComponent<HealthManager>().DamageCharacter(totalDamage);  
        }
    }
}
