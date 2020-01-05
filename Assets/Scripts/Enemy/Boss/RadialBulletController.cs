using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialBulletController : MonoBehaviour
{   
    [Header("Projectiles Settings")]
    public int numberProjectiles;
    public float projectilesSpeed;
    public GameObject projectilePrefab;


    [Header("Private Settings")]
    private Vector3 startPoint; //Pos
    private const float radius = 1F;
    private HealthManager healthManager;

    void Start(){
        InvokeRepeating("SpawnProjectiles",2.0f,3.0f);
        healthManager = GetComponent<HealthManager>();
    }

    void Update()
    {
        startPoint = transform.position;

        if(healthManager.currentHealth<=0){
            Debug.Log("Terminando de disparar");
            CancelInvoke("SpawnProjectiles");
        }
    }

    void SpawnProjectiles(){
        float angleStep = 360 / numberProjectiles;
        float angle = 0f;

        for(int i=0; i<numberProjectiles; i++){

            //Direction bullet
            float projectileDirXPosition = startPoint.x - Mathf.Sin((angle * Mathf.PI)/180) * radius;
            float projectileDirYPosition = startPoint.y - Mathf.Cos((angle * Mathf.PI)/180) * radius;

            Vector3 projectileVector = new Vector3(projectileDirXPosition, projectileDirYPosition, 0);
            Vector3 projectileMoveDirection = (projectileVector - startPoint).normalized * projectilesSpeed;

            GameObject tempObj = Instantiate(projectilePrefab, startPoint, Quaternion.identity);
            tempObj.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileMoveDirection.x, projectileMoveDirection.y);
            //Angle to shot projectile
            angle+= angleStep;
        }
    }
}
