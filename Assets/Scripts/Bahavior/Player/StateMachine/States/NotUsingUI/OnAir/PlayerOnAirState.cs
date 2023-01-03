using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnAirState : PlayerNotUsingUIState
{
    public override PlayerBaseState DoState(PlayerStateMachine playerBehavior)
    {
        base.DoState(playerBehavior);
        //If trigger Jump -> PlayerDoubleJumpState
        return playerBehavior.jumpState;
    }
}
