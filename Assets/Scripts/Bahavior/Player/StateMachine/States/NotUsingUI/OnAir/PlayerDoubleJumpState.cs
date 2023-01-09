using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDoubleJumpState : PlayerOnAirState
{
    public override PlayerBaseState DoState(PlayerStateMachine playerBehavior)
    {
        base.DoState(playerBehavior);
        //If facing wall && input != 0 -> PlayerOnWallState
        return playerBehavior.doubleJumpState;
    }
}
