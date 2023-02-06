using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnGroundState : PlayerActiveState
{
    public override PlayerBaseState DoState(PlayerStateMachine playerBehavior)
    {
        PlayerBaseState parentCheck = base.DoState(playerBehavior);
        if (parentCheck != playerBehavior.activeState) return parentCheck;

        playerBehavior.playerMovementData.anim.SetBool("isJumping", false);

        if (playerBehavior.playerMovementData.IsGrounded() == false)
        {
            playerBehavior.playerMovementData.anim.SetTrigger("falling");
            return playerBehavior.onAirState;
        }

        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            return playerBehavior.idleState;
        }

        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            return playerBehavior.groundRunState;
        }

        return playerBehavior.onGroundState;
    }
}
