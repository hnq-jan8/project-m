using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnGroundState : PlayerNotUsingUIState
{
    public override PlayerBaseState DoState(PlayerStateMachine playerBehavior)
    {
        base.DoState(playerBehavior);

        //If player isGrounded == false -> PlayerOnAirState
        if (!playerBehavior.movementBehavior.IsGrounded())
        {
            return playerBehavior.onAirState;
        }

        //If trigger attack -> PlayerAttackState
        if (Input.GetKeyDown(KeyCode.J))
        {
            return playerBehavior.attackState;
        }

        //If trigger dash -> PlayerDashState
        if (Input.GetKeyDown(KeyCode.L))
        {
            return playerBehavior.dashState;
        }

        //If input != 0 -> PlayerRunState
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            return playerBehavior.runState;
        }

        return playerBehavior.idleState;
    }
}
