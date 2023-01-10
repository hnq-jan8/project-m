using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerOnGroundState
{
    public override PlayerBaseState DoState(PlayerStateMachine playerBehavior)
    {
        base.DoState(playerBehavior);

        //If trigger Jump -> PlayerJumpState
        return playerBehavior.jumpState;
    }
}
