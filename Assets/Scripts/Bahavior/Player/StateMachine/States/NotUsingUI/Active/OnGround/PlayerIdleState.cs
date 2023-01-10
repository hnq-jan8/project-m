using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerOnGroundState
{
    public override PlayerBaseState DoState(PlayerStateMachine playerBehavior)
    {
        //If trigger Jump -> PlayerJumpState
        /*if (Input.GetKeyDown(KeyCode.K))
        {
            //playerBehavior.jumpBehavior.Jumping();
            playerBehavior.jumpBehavior.jumpInput.TriggerJump();
            playerBehavior.jumpBehavior.Jumping();
            return playerBehavior.onAirState;
        }*/

        base.DoState(playerBehavior);

        //If input != 0 -> PlayerRunState
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            return playerBehavior.runState;
        }
        else
        {
            //playerBehavior.sideMoveBehavior.StopMove();
            return playerBehavior.idleState;
        }
    }
}
