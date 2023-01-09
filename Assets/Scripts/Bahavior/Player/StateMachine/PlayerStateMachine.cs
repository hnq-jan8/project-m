using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    PlayerBaseState currentState;

    //States
    public PlayerUsingUIState usingUIState { get; private set; }
    public PlayerNotUsingUIState notUsingUIState { get; private set; }
    public PlayerAttackState attackState { get; private set; }
    public PlayerDashState dashState { get; private set; }
    public PlayerRunState runState { get; private set; }
    public PlayerIdleState idleState { get; private set; }
    public PlayerJumpState jumpState { get; private set; }
    public PlayerDoubleJumpState doubleJumpState { get; private set; }
    public PlayerOnWallState onWallState { get; private set; }
    public PlayerWallSlideState wallSlideState { get; private set; }
    public PlayerWallJumpState wallJumpState { get; private set; }
    public PlayerOnGroundState onGroundState { get; private set; }
    public PlayerOnAirState onAirState { get; private set; }

    //Data
    public MovementBehavior movementBehavior { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        usingUIState = new PlayerUsingUIState();
        notUsingUIState = new PlayerNotUsingUIState();
        attackState = new PlayerAttackState();
        dashState = new PlayerDashState();
        runState = new PlayerRunState();
        idleState = new PlayerIdleState();
        jumpState = new PlayerJumpState();
        doubleJumpState = new PlayerDoubleJumpState();
        onWallState = new PlayerOnWallState();
        wallSlideState = new PlayerWallSlideState();
        wallJumpState = new PlayerWallJumpState();
        onGroundState = new PlayerOnGroundState();
        onAirState = new PlayerOnAirState();

        currentState = idleState;

        //Data
        movementBehavior = GetComponentInChildren<MovementBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        currentState = currentState.DoState(this);

        //For debug
        Debug.Log(currentState);
    }
}
