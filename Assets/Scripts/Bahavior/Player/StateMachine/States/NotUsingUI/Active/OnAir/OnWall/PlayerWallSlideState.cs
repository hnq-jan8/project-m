using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallSlideState : PlayerOnWallState
{
    public override PlayerBaseState DoState(PlayerStateMachine playerBehavior)
    {
        base.DoState(playerBehavior);
        //If trigger Jump -> PlayerWallJumpState
        return this;
    }
}
