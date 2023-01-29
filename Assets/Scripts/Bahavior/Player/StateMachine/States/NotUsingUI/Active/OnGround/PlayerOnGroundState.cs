using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnGroundState : PlayerActiveState
{
    public override PlayerBaseState DoState(PlayerStateMachine playerBehavior)
    {
        PlayerBaseState parentCheck = base.DoState(playerBehavior);
        if (parentCheck != playerBehavior.activeState) return parentCheck;

        if (playerBehavior.playerData.IsGrounded() == false)
        {
            return playerBehavior.onAirState;
        }

        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            return playerBehavior.groundRunState;
        }

        playerBehavior.playerData.anim.SetBool("isRunning", false);
        playerBehavior.playerData.anim.SetBool("isJumping", false);

        return playerBehavior.onGroundState;
    }
}