using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    //public float playerInRangeRadius { get; private set; }

    [Header("Serializable Fields")]
    [SerializeField] private GameObject spriteObject;

    [SerializeField] private GameObject bossSideMoveObject;

    [SerializeField] private BossFightActivateArea bossFightActivateArea;

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


    #region States
    public IBossState currentState;

    public Stage1State stage1State = new Stage1State();
    public Stage2State stage2State = new Stage2State();
    public IdleState idleState = new IdleState();
    public IntroState introState = new IntroState();
    public RoarState roarState = new RoarState();
    public ChasePlayerState chasePlayerState = new ChasePlayerState();
    public StrikeWeaponState strikeWeaponState = new StrikeWeaponState();

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
        camshake = FindObjectOfType<PlayerSingleton>().transform.Find("Camshake").GetComponent<Camshake>();

        //Side move input
        //sideMove = bossSideMoveObject.GetComponent<BossSideMoveInput>();
        sideMove = bossSideMoveObject.GetComponent<SideMove>();

        //Player Target
        playerTarget = FindObjectOfType<PlayerSingleton>().transform;
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