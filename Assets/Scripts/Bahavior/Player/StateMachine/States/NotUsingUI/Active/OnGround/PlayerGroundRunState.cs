using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundRunState : PlayerOnGroundState
{
    public override PlayerBaseState DoState(PlayerStateMachine playerBehavior)
    {
        //SideMove
        playerBehavior.sideMoveBehavior.moveInput.UpdateInput();
        playerBehavior.sideMoveBehavior.Move();

        //Flip
        playerBehavior.flipBehavior.DoFlipByInput(playerBehavior.sideMoveBehavior.input);

        //Animation
        playerBehavior.playerMovementData.anim.SetBool("isRunning", true);

        /*Debug.LogError("Run");*/

        PlayerBaseState stateCheck = base.DoState(playerBehavior);
        if (stateCheck != playerBehavior.groundRunState)
        {
            playerBehavior.playerMovementData.anim.SetBool("isRunning", false);
        }

        return stateCheck;
    }
}
