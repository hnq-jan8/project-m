using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitnRunStateMachine : MonoBehaviour
{
    public IHitnRunState currentState;


    public HitnRunIdleState idleState { get; private set; }
    public HitnRunChaseState chaseState { get; private set; }
    public HitnRunAttackState attackState { get; private set; }
    public HitnRunRetreatState retreatState { get; private set; }


    public MovementData movementData { get; private set; }
    public Transform playerPosition { get; private set; }
    public LayerMask playerLayer { get; private set; }
    public SideMove sideMoveBehavior { get; private set; }
    public Flip flipBehavior { get; private set; }
    public Dash dashBehavior { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        idleState = new HitnRunIdleState();
        chaseState = new HitnRunChaseState();
        attackState = new HitnRunAttackState();
        retreatState = new HitnRunRetreatState();

        movementData = GetComponent<MovementData>();
        playerPosition = PlayerSingleton.instance.transform;
        playerLayer = LayerMask.GetMask("Player");

        sideMoveBehavior = GetComponentInChildren<SideMove>();
        flipBehavior = GetComponentInChildren<Flip>();
        dashBehavior = GetComponentInChildren<Dash>();


        currentState = idleState;
    }

    // Update is called once per frame
    void Update()
    {
        currentState = currentState.DoState(this);
    }
}
