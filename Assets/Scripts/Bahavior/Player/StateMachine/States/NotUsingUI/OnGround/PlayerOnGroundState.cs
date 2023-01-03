using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnGroundState : PlayerNotUsingUIState
{
    public override PlayerBaseState DoState(PlayerStateMachine playerBehavior)
    {
        base.DoState(playerBehavior);

        //If isGrounded == false -> PlayerOnAirState
        if (playerBehavior.movementBehavior.IsGrounded() == false)
        {
            return playerBehavior.onAirState;
        }

        //If trigger attack -> PlayerAttackState
        /*if (playerBehavior.attack.???)
        {
            return playerBehavior.attackState;
        }*/


        //If trigger dash -> PlayerDashState
        if (playerBehavior.playerDashInput.trigger == true)
        {
            return playerBehavior.dashState;
        }

        //If input != 0 -> PlayerRunState


        return playerBehavior.idleState;
    }
}
