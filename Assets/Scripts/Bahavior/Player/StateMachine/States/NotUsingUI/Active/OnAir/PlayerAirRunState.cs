using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirRunState : PlayerOnAirState
{
    public override PlayerBaseState DoState(PlayerStateMachine playerBehavior)
    {
        /*PlayerBaseState parentCheck = base.DoState(playerBehavior);
        if (parentCheck != playerBehavior.activeState) return parentCheck;*/

        //SideMove
        playerBehavior.sideMoveBehavior.moveInput.UpdateInput();
        playerBehavior.sideMoveBehavior.Move();

        //Flip
        playerBehavior.flipBehavior.DoFlipByInput(playerBehavior.sideMoveBehavior.input);

        //Animation
        /*playerBehavior.playerData.anim.SetBool("isRunning", true);*/

        /*Debug.LogError("Run");*/
        return base.DoState(playerBehavior);
    }
}
