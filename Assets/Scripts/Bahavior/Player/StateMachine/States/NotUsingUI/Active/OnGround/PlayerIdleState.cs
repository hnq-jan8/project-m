using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerOnGroundState
{
    public override PlayerBaseState DoState(PlayerStateMachine playerBehavior)
    {
        playerBehavior.sideMoveBehavior.StopMove();
        playerBehavior.playerMovementData.anim.SetBool("isRunning", false);

        return base.DoState(playerBehavior);
    }
}
