using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Almost done
public class PlayerOnAirState : PlayerActiveState
{
    public override PlayerBaseState DoState(PlayerStateMachine playerBehavior)
    {
        //Debug.LogError("Air");
        PlayerBaseState parentCheck = base.DoState(playerBehavior);
        if (parentCheck != playerBehavior.activeState) return parentCheck;

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
