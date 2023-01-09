using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerOnGroundState
{
    public override PlayerBaseState DoState(PlayerStateMachine playerBehavior)
    {
        base.DoState(playerBehavior);

        //If trigger Jump -> PlayerJumpState
        if (Input.GetKeyDown(KeyCode.K))
        {
            return playerBehavior.jumpState;
        }

        //If input != 0 -> PlayerRunState
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            return playerBehavior.runState;
        }

        return playerBehavior.idleState;
    }
}
