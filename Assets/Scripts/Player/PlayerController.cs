using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Caracteristicas
    [Header("Features Player")]
    public float speed = 4.0f;
    private float currentSpeed;
    public static bool playerCreated;
    public float attackTime;
    private float attackTimeCounter;
    [SerializeField]
    private Transform startPosition;

    //Comportamiento
    [Header("Features Behaviour")]
    private bool walking = false;
    private bool attacking = false;
    public bool playerTalking;
    
    //Animacion
    [Header("Animation")]
    public Vector2 lastMovement = Vector2.zero;

    //Constantes
    private const string horizontal = "Horizontal";
    private const string vertical = "Vertical";
    private const string lastHorizontal = "LastHorizontal";
    private const string lastVertical = "LastVertical";
    private const string walkingState = "Walking";
    private const string attackingState = "Attacking";
    public string nextPlaceName; //Lugar donde tiene que aparecer

    //Componentes externos
    [Header("Outside Features")]
    private Animator animator;
    private Rigidbody2D playerRigidbody;
    private SFXManager sfxManager;
    private CharacterStats characterStats;

    void Awake()
    {
        animator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        sfxManager = FindObjectOfType<SFXManager>();
        characterStats = GetComponent<CharacterStats>();
    }

    // Start is called before the first frame update
    void Start()
    {
        IsPlayerControllerCreated();
        StartPlayer();
    }

    public void StartPlayer(){
        this.gameObject.SetActive(true);
        this.transform.position = startPosition.position;
        playerTalking = false;
        lastMovement = new Vector2(-1,0);
        characterStats.StartCharacterStats();
    }

    // Update is called once per frame
    void Update()
    {

        //Cambios en la animacion
        animator.SetFloat(horizontal, Input.GetAxisRaw(horizontal));
        animator.SetFloat(vertical, Input.GetAxisRaw(vertical));
        animator.SetBool(walkingState, walking);
        animator.SetFloat(lastHorizontal, lastMovement.x);
        animator.SetFloat(lastVertical, lastMovement.y);
    }

    void FixedUpdate()
    {   
        if(playerTalking){
            playerRigidbody.velocity = Vector2.zero;
            return;
        }

        // s = v * t;
        walking = false;

        //GetClick
        if (Input.GetMouseButtonDown(0))
        {
            attacking = true;
            attackTimeCounter = attackTime;
            playerRigidbody.velocity = Vector2.zero;
            animator.SetBool(attackingState, true);
            sfxManager.playerAttack.Play();
        }

        //Attacking
        if (attacking)
        {
            attackTimeCounter -= Time.deltaTime;
            if (attackTimeCounter < 0)
            {
                attacking = false;
                animator.SetBool(attackingState, false);
            }
        }
        else
        {
            //Walking
            if (Mathf.Abs(Input.GetAxisRaw(horizontal)) > 0.5f ||
                Mathf.Abs(Input.GetAxisRaw(vertical)) > 0.5f
                )
            {
                walking = true;
                lastMovement = new Vector2(Input.GetAxisRaw(horizontal),
                                            Input.GetAxisRaw(vertical));
                playerRigidbody.velocity = lastMovement.normalized * speed * Time.deltaTime;

            }
        }
        if (!walking)
        {
            playerRigidbody.velocity = Vector2.zero;
        }
    }

    void IsPlayerControllerCreated()
    {
        if (!playerCreated)
        {
            playerCreated = true;
            //Evita cargar el sistema
            DontDestroyOnLoad(this.transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetWalking(bool newWalking){
        this.walking = newWalking;
    } 


}
