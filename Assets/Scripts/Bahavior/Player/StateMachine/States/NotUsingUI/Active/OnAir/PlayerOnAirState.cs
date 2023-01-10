using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnAirState : PlayerActiveState
{
    public override PlayerBaseState DoState(PlayerStateMachine playerBehavior)
    {
        base.DoState(playerBehavior);
        if (playerBehavior.playerData.IsGrounded() == true)
        {
            return playerBehavior.onGroundState;
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            //return playerBehavior.doubleJumpState;
            playerBehavior.jumpBehavior.jumpInput.TriggerJump();
            playerBehavior.jumpBehavior.Jumping();

            playerBehavior.playerData.anim.SetTrigger("takeOff");
        }
        if (Input.GetKeyUp(KeyCode.K))
        {
            Debug.LogError("a");
            playerBehavior.jumpBehavior.jumpInput.ReleaseJump();
            playerBehavior.jumpBehavior.Jumping();
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
