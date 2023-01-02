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
        currentState = idleState;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
