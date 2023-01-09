using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnWallState : PlayerOnAirState
{
    public override PlayerBaseState DoState(PlayerStateMachine playerBehavior)
    {
        base.DoState(playerBehavior);

        //If input != 0 facing wall -> PlayerWallSlideState
        return playerBehavior.wallSlideState;
    }
}
