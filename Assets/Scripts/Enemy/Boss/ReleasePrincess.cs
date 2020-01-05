using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleasePrincess : MonoBehaviour
{   
    private HealthManager healthManager;
    [SerializeField]
    private GameObject princessPrission;
    public GameObject princess;

    private float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        healthManager = GetComponent<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = healthManager.currentHealth;
        if(currentHealth <=0){
            RealeseThePrincess();
        }
    }

    void RealeseThePrincess(){
        Destroy(princessPrission);
        princess.GetComponent<GoToBezierRoute>().enabled = true;
    }
}
