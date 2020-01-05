using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    public int totalDamage;

    //Animacion de sangre
    public GameObject bloodAnimation;
    //Donde se instancia
    public GameObject hitPoint;
    [SerializeField]
    private GameObject damageNumber;

    //Stats
    private CharacterStats stats;

    void Start()
    {
        stats = GetComponentInParent<CharacterStats>();

    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag.Equals("Enemy") || collider.gameObject.tag.Equals("Final Enemy"))
        {
            int damage = totalDamage;
            if (stats != null)
            {
                damage += stats.strengthLevels[stats.currentLevel];
            }
            damage = Random.Range(damage - 8,damage);
            
            collider.gameObject.GetComponent<HealthManager>().DamageCharacter(damage);
            Instantiate(bloodAnimation, hitPoint.transform.position, hitPoint.transform.rotation);

            var clone = (GameObject)Instantiate(
                damageNumber,
                hitPoint.transform.position,
                Quaternion.Euler(Vector3.zero));
            clone.GetComponent<DamageNumber>().damagePoints = damage;
        }
    }
}
