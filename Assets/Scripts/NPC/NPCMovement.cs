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
    public BoxCollider2D walkZone;
    private Vector2 minWalkPoint;
    private Vector2 maxWaltkPoint;
    private bool hasWalkZone;

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
        ChooseDirection();

        if (walkZone != null)
        {
            minWalkPoint = walkZone.bounds.min;
            maxWaltkPoint = walkZone.bounds.max;
            hasWalkZone = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!manager.dialogActive)
        {
            isTalking = false;
        }

        if (isTalking)
        {
            StopWalking();
            npcAnimator.SetBool(walking, false);
            return;
        }

        if (isWalking)
        {
            walkingCurrentTime -= Time.deltaTime;
            if (walkingCurrentTime < 0)
            {
                StopWalking();
            }
            npcRigidbody2D.velocity = walkingDirection[currentDirection] * speed;

            //Bounds
            if (hasWalkZone && transform.position.x >= maxWaltkPoint.x ||
               hasWalkZone && transform.position.x <= minWalkPoint.x ||
               hasWalkZone && transform.position.y >= maxWaltkPoint.y ||
               hasWalkZone && transform.position.y <= minWalkPoint.y
               )
            {
                StopWalking();
            }
            lastMovement = walkingDirection[currentDirection];
            npcAnimator.SetFloat(lastHorizontal, lastMovement.x);
            npcAnimator.SetFloat(lastVertical, lastMovement.y);
        }
        else
        {
            stopWalkingCurrentTime -= Time.deltaTime;
            npcRigidbody2D.velocity = Vector2.zero;
            if (stopWalkingCurrentTime < 0)
            {
                if (hasWalkZone && transform.position.x >= maxWaltkPoint.x)
                {
                    ChooseRightDirection(0);
                }
                else if (hasWalkZone && transform.position.x <= minWalkPoint.x)
                {
                    ChooseRightDirection(2);
                }
                else if (hasWalkZone && transform.position.y >= maxWaltkPoint.y)
                {
                    ChooseRightDirection(1);
                }
                else if (hasWalkZone && transform.position.y <= minWalkPoint.y)
                {
                    ChooseRightDirection(3);
                }
                else
                {
                    ChooseDirection();
                }
            }
        }
        npcAnimator.SetBool(walking, isWalking);
        npcAnimator.SetFloat(horizontal, npcRigidbody2D.velocity.x);
        npcAnimator.SetFloat(vertical, npcRigidbody2D.velocity.y);
        //npcAnimator.SetFloat(lastHorizontal, npcRigidbody2D.velocity.x);
        //npcAnimator.SetFloat(lastVertical, npcRigidbody2D.velocity.y);

    }

    void ChooseDirection()
    {
        isWalking = true;
        currentDirection = Random.Range(0, 4);
        walkingCurrentTime = walkingTime;

    }

    void ChooseRightDirection(int except)
    {
        isWalking = true;
        int randomNumr = except;
        while (randomNumr == except)
        {
            randomNumr = Random.Range(0, 4);
        }
        currentDirection = randomNumr;
        walkingCurrentTime = walkingTime;
    }

    void StopWalking()
    {
        isWalking = false;
        stopWalkingCurrentTime = stopWalkingTime;
        //npcRigidbody2D.velocity = Vector2.zero;
    }
}
