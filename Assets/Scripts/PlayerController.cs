using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    //Caracteristicas
    public float speed = 4.0f;
    private bool walking = false;
    public Vector2 lastMovement = Vector2.zero;

    //Comportamiento
    private const string horizontal = "Horizontal";
    private const string vertical = "Vertical";
    private const string lastHorizontal = "LastHorizontal";
    private const string lastVertical = "LastVertical";
    private const string walkingState = "Walking";

    //Componentes externos
    private Animator animator;
    private Rigidbody2D playerRigidbody;
    
    void Awake(){
        animator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // s = v * t;
        walking = false;

        if(Mathf.Abs(Input.GetAxisRaw(horizontal)) > 0.5f){
            /*this.transform.Translate(new Vector3(
                                                Input.GetAxisRaw(horizontal)*
                                                speed*
                                                Time.deltaTime
                                                ,0,0));*/
            playerRigidbody.velocity = new Vector2(
                                                Input.GetAxisRaw(horizontal)*
                                                speed*
                                                Time.deltaTime
                                                ,playerRigidbody.velocity.y);
            walking = true;
            lastMovement = new Vector2(Input.GetAxisRaw(horizontal),0f);
        }
        else{
            playerRigidbody.velocity = new Vector2(0f,playerRigidbody.velocity.y);
        }

        if(Mathf.Abs(Input.GetAxisRaw(vertical)) > 0.5f){
            /*this.transform.Translate(new Vector3(
                                                0,
                                                Input.GetAxisRaw(vertical)*
                                                speed*
                                                Time.deltaTime
                                                ,0));*/
            playerRigidbody.velocity = new Vector2(
                                                playerRigidbody.velocity.x,
                                                Input.GetAxisRaw(vertical)*
                                                speed*
                                                Time.deltaTime);                                    
            walking = true;
            lastMovement = new Vector2(0,Input.GetAxisRaw(vertical));
        }
        else{
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x,0f);
        }

        if(!walking){
            playerRigidbody.velocity = Vector2.zero;
        }

        //Cambios en la animacion
        animator.SetFloat(horizontal, Input.GetAxisRaw(horizontal));
        animator.SetFloat(vertical, Input.GetAxisRaw(vertical));
        animator.SetBool(walkingState,walking);
        animator.SetFloat(lastHorizontal, lastMovement.x);
        animator.SetFloat(lastVertical, lastMovement.y);
    }
}
