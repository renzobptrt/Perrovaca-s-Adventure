using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    //NPC Features
    public float speed = 1.5f;

    //Walking features
    private bool isWalking;
    public float walkingTime;
    private float walkingCurrentTime;
    public float stopWalkingTime;
    private float stopWalkingCurrentTime;
    private Vector2[] walkingDirection = {
        new Vector2(1,0),
        new Vector2(0,1),
        new Vector2(-1,0),
        new Vector2(0,-1)
    };
    private int currentDirection;
    public Vector2 lastMovement;

    //Dialog
    public bool isTalking;

    //Bound
    public BoxCollider2D villagerZone;

    //Outside
    private Rigidbody2D npcRigidbody2D;
    private Animator npcAnimator;
    private DialogManager manager;

    private const string horizontal = "Horizontal";
    private const string vertical = "Vertical";
    private const string walking = "Walking";
    private const string lastVertical = "LastVertical";
    private const string lastHorizontal = "LastHorizontal";

    //Load Components
    void Awake()
    {   
        manager = FindObjectOfType<DialogManager>();
        npcRigidbody2D = GetComponent<Rigidbody2D>();
        npcAnimator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        walkingCurrentTime = walkingTime;
        stopWalkingCurrentTime = stopWalkingTime;
    }

    // Update is called once per frame
    void Update()
    {   
        if(!manager.dialogActive){
            isTalking = false;  
        }

        if(isTalking){
            StopWalking();
            npcAnimator.SetBool(walking, false);
            return;
        }

        if (isWalking)
        {   

            if(villagerZone != null){
                if( this.transform.position.x < villagerZone.bounds.min.x  ||
                    this.transform.position.x > villagerZone.bounds.max.x  ||
                    this.transform.position.y < villagerZone.bounds.min.y ||
                    this.transform.position.y > villagerZone.bounds.max.y
                    ){
                        StopWalking();
                    }
            }

            npcRigidbody2D.velocity = walkingDirection[currentDirection] * speed;
            lastMovement = walkingDirection[currentDirection];
            walkingCurrentTime -= Time.deltaTime;
            if (walkingCurrentTime < 0)
            {
                StopWalking();
            }
            npcAnimator.SetFloat(lastHorizontal, lastMovement.x);
            npcAnimator.SetFloat(lastVertical, lastMovement.y);
        }
        else
        {
            npcRigidbody2D.velocity = Vector2.zero;
            stopWalkingCurrentTime -= Time.deltaTime;
            if (stopWalkingCurrentTime < 0)
            {
                StartWalking();
            }
        }
        npcAnimator.SetBool(walking, isWalking);
        npcAnimator.SetFloat(horizontal, npcRigidbody2D.velocity.x);
        npcAnimator.SetFloat(vertical, npcRigidbody2D.velocity.y);
        //npcAnimator.SetFloat(lastHorizontal, npcRigidbody2D.velocity.x);
        //npcAnimator.SetFloat(lastVertical, npcRigidbody2D.velocity.y);

    }

    void StartWalking()
    {
        isWalking = true;
        currentDirection = Random.Range(0, 4);
        walkingCurrentTime = walkingTime;

    }

    void StopWalking()
    {
        isWalking = false;
        stopWalkingCurrentTime = stopWalkingTime;
        npcRigidbody2D.velocity = Vector2.zero;
    }
}
