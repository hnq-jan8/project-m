using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerOnGroundState
{
    public override PlayerBaseState DoState(PlayerStateMachine playerBehavior)
    {
        //Debug.LogError("BBBBBBBBBBBBBBBB");
        //If trigger Jump -> PlayerJumpState
        /*if (Input.GetKeyDown(KeyCode.K))
        {
            //playerBehavior.jumpBehavior.Jumping();
            playerBehavior.jumpBehavior.jumpInput.TriggerJump();
            playerBehavior.jumpBehavior.Jumping();
            return playerBehavior.onAirState;
        }*/

        base.DoState(playerBehavior);

        //If input != 0 -> PlayerGroundRunState
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            return playerBehavior.groundRunState;
        }
        else
        {
            //playerBehavior.sideMoveBehavior.StopMove();
            return playerBehavior.idleState;
        }
    }
}
