using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{   
    /*
        Script que gobernará el movimiento del enemigo
    */
    
    //Caracteristicas
    public float enemySpeed = 1;
    private bool isMoving;

    //Componentes
    private Rigidbody2D enemyRgb;
    private Animator enemyAnimator;
    private const string horizontal = "Horizontal";
    private const string vertical = "Vertical";
    private const string walkingState = "Walking";
    
    //Combinaciones de movimiento
    public float timeBetweenSteps; //Tiempo entre movimiento
    private float timeBetweenStepsCounter; //Cuanto tiempo paso desde el ultimo movimiento
    public float timeToMakeStep; //Tiempo que tarde hacer el paso
    private float timeToMakeStepCounter; //Tiempo desde que inicio el movimiento
    public Vector2 directionToMakeStep;

    void Awake(){
        this.enemyRgb = GetComponent<Rigidbody2D>();
        this.enemyAnimator = GetComponent<Animator>();
    }

    void Start()
    {
        timeBetweenStepsCounter = timeBetweenSteps*Random.Range(0.5f,1.5f);
        timeToMakeStepCounter = timeToMakeStep*Random.Range(0.5f,1.5f);
    }

    void Update()
    {

        if(isMoving){
            timeToMakeStepCounter -= Time.deltaTime;
            enemyRgb.velocity = directionToMakeStep;
            if(timeToMakeStepCounter<0){
                isMoving = false;
                timeBetweenStepsCounter = timeBetweenSteps;
                enemyRgb.velocity = Vector2.zero;   
            }
        }
        else
        {
            timeBetweenStepsCounter -= Time.deltaTime;

            if(timeBetweenStepsCounter<0){
                isMoving = true;
                timeToMakeStepCounter = timeToMakeStep;
                directionToMakeStep = new Vector2(Random.Range(-1,2),
                Random.Range(-1,2))*enemySpeed;
            }    
        }
        
        enemyAnimator.SetBool(walkingState,isMoving);
        enemyAnimator.SetFloat(horizontal,directionToMakeStep.x);
        enemyAnimator.SetFloat(vertical, directionToMakeStep.y);
    }
}
