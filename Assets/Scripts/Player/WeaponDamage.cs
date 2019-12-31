using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour
{   
    private int damage;

    //Animacion de sangre
    public GameObject bloodAnimation;
    //Donde se instancia
    public GameObject hitPoint;
    [SerializeField]
    private GameObject damageNumber;


    private void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag.Equals("Enemy")){
            damage = Random.Range(7,15);
            collider.gameObject.GetComponent<HealthManager>().DamageCharacter(damage);
            Instantiate(bloodAnimation, hitPoint.transform.position,hitPoint.transform.rotation);

            var clone = (GameObject)Instantiate(
                damageNumber,
                hitPoint.transform.position,
                Quaternion.Euler(Vector3.zero));
            clone.GetComponent<DamageNumber>().damagePoints = damage;
        }
    }
}
