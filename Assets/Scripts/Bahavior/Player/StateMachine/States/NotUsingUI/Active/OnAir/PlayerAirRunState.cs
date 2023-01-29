using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirRunState : PlayerOnAirState
{
    public override PlayerBaseState DoState(PlayerStateMachine playerBehavior)
    {
        //If input == 0 -> Dont move
        /*if (Input.GetAxisRaw("Horizontal") == 0)
        {
            playerBehavior.sideMoveBehavior.StopMove();
            playerBehavior.playerData.anim.SetBool("isRunning", false);
        }*/

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
