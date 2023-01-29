using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnAirState : PlayerActiveState
{
    public override PlayerBaseState DoState(PlayerStateMachine playerBehavior)
    {
        PlayerBaseState parentCheck = base.DoState(playerBehavior);
        if (parentCheck != playerBehavior.activeState) return parentCheck;

        playerBehavior.playerData.anim.SetBool("isJumping", true);
        playerBehavior.playerData.anim.SetBool("isRunning", false);

        if (playerBehavior.playerData.IsGrounded() == true)
        {
            return playerBehavior.onGroundState;
        }

        if (Input.GetKeyUp(KeyCode.K))
        {
            playerBehavior.jumpBehavior.jumpInput.ReleaseJump();
            playerBehavior.jumpBehavior.Jumping();
        }

        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            return playerBehavior.airRunState;
        }

        return playerBehavior.onAirState;
    }

    void AirMove()
    {

    }

    void AirJump()
    {

    }
}
