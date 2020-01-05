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

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            startPoint = transform.position;
            SpawnProjectiles(numberProjectiles);
        }
    }

    void SpawnProjectiles(int numberOfProjectiles){
        float angleStep = 360 / numberOfProjectiles;
        float angle = 0f;

        for(int i=0; i<numberOfProjectiles; i++){

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
