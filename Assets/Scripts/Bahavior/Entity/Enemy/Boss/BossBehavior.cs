using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BossBehavior : MonoBehaviour
{
    //public float playerInRangeRadius { get; private set; }

    [Header("Serializable Fields")]
    [SerializeField] private GameObject spriteObject;

    //[SerializeField] private GameObject bossSideMoveObject;

    [SerializeField] private BossFightActivateArea bossFightActivateArea;

    [SerializeField] private Transform test;

    public UnityEvent OnPlayerDetected;

    //[SerializeField] private BossAnimationEventHandler animationEventHandler;

    public int health { get; private set; }
    public Camshake camshake { get; private set; }
    public float timeInState { get; private set; }
    public LayerMask playerLayer { get; private set; }
    public Animator anim { get; private set; }
    public bool fightIsInProgress { get; private set; }
    public BossAnimationEventHandler animationEventHandler { get; private set; }
    public Transform playerTarget { get; private set; }
    //public BossSideMoveInput sideMove { get; private set; }
    public SideMove sideMove { get; private set; }
    public Flip flip { get; private set; }


    #region States
    public IBossState currentState;

    public ManusianStage1State stage1State = new ManusianStage1State();
    public ManusianStage2State stage2State = new ManusianStage2State();
    public ManusianIdleState idleState = new ManusianIdleState();
    public ManusianIntroState introState = new ManusianIntroState();
    public ManusianRoarState roarState = new ManusianRoarState();
    public ManusianChasePlayerState chasePlayerState = new ManusianChasePlayerState();
    public ManusianStrikeWeaponState strikeWeaponState = new ManusianStrikeWeaponState();

    #endregion

    private void OnEnable()
    {
        currentState = idleState;
    }

    // Start is called before the first frame update
    void Start()
    {
        timeInState = 0f;
        health = GetComponent<Life>().GetHealth();
        camshake = PlayerSingleton.instance.transform.Find("Camshake").GetComponent<Camshake>();

        //Side move input
        sideMove = GetComponentInChildren<SideMove>();

        //Flip
        flip = GetComponentInChildren<Flip>();

        //Player Target
        playerTarget = PlayerSingleton.instance.transform;
        playerLayer = LayerMask.GetMask("Player");

        //Animator
        anim = spriteObject.GetComponent<Animator>();

        //Animation Event Handler
        animationEventHandler = spriteObject.GetComponent<BossAnimationEventHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        currentState = currentState.DoState(this);
        test = playerTarget;
    }

    //Boss fight activation and progress check
    public bool FightIsActivated()
    {
        return bossFightActivateArea.fightActivated;
    }
    public void SetFightInProgress()
    {
        fightIsInProgress = true;
    }

    //Time in state
    public float CountTimeInState()
    {
        timeInState += Time.deltaTime;
        //Debug.Log(timeInState);

        return timeInState;
    }
    public void ResetTimeInState()
    {
        timeInState = 0f;
    }

    //Play Cam Shake
    public void PlayCamShake()
    {
        camshake.PlayCamShake();
    }

    private void OnDrawGizmos()
    {
        //Gizmos.DrawSphere(transform.position, 6);
    }
}