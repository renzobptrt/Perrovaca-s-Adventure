using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthTrigger : MonoBehaviour
{   
    private BossManager bossManager;
    private GameObject bossObject;
    private UIManager uiManager;

    // Start is called before the first frame update
    void Start()
    {
        bossManager = FindObjectOfType<BossManager>();
        bossObject = GameObject.FindWithTag("Final Enemy");
        uiManager = FindObjectOfType<UIManager>();

    }

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag.Equals("Player")){
            Debug.Log("Bienvenido a final");
            bossManager.boss_health.SetActive(true);
            uiManager.bossHealthManager = bossObject.GetComponent<HealthManager>();
        }
    }
}
