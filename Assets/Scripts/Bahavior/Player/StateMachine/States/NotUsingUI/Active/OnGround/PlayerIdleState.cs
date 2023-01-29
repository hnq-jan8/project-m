using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerOnGroundState
{
    public override PlayerBaseState DoState(PlayerStateMachine playerBehavior)
    {
        playerBehavior.sideMoveBehavior.StopMove();
        playerBehavior.playerData.anim.SetBool("isRunning", false);
        playerBehavior.playerData.anim.SetBool("isJumping", false);

        return base.DoState(playerBehavior);
    }
}
