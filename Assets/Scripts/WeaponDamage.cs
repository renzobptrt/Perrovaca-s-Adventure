using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour
{   
    public int damage;

    private void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag.Equals("Enemy")){
            collider.gameObject.GetComponent<HealthManager>().DamageCharacter(damage);
        }
    }
}
