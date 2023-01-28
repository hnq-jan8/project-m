using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirRunState : PlayerOnAirState
{
    public override PlayerBaseState DoState(PlayerStateMachine playerBehavior)
    {
        //If input == 0 -> PlayerIdleState
        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            playerBehavior.sideMoveBehavior.StopMove();
            playerBehavior.playerData.anim.SetBool("isRunning", false);
        }

        //If the player press K -> OnAirState
        /*else if (Input.GetKeyDown(KeyCode.K))
        {
            //playerBehavior.jumpBehavior.Jumping();
            playerBehavior.jumpBehavior.jumpInput.TriggerJump();
            playerBehavior.jumpBehavior.Jumping();

            playerBehavior.playerData.anim.SetBool("isRunning", false);
            playerBehavior.playerData.anim.SetTrigger("takeOff");

            return playerBehavior.onAirState;
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
