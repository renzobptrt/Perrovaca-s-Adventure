using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopPrincess : MonoBehaviour
{   
    [SerializeField]
    private Transform finalRoute;
    private GoToBezierRoute goToBezierRoute;
    private BossManager bossManager;
    // Start is called before the first frame update
    void Start()
    {
        goToBezierRoute = GetComponent<GoToBezierRoute>();
        bossManager = FindObjectOfType<BossManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(this.transform.position, finalRoute.position) < 0.5){
            bossManager.boss_health.SetActive(false);
            goToBezierRoute.enabled = false;
            this.enabled = false;
        }
    }
}
