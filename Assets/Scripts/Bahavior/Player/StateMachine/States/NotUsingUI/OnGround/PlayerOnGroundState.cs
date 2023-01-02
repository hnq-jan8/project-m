using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnGroundState : PlayerNotUsingUIState
{
    public override PlayerBaseState DoState(PlayerStateMachine playerBehavior)
    {
        base.DoState(playerBehavior);
        //If isGrounded == false -> PlayerOnAirState

        //If trigger attack -> PlayerAttackState

        //If trigger dash -> PlayerDashState

        //If input != 0 -> PlayerRunState
        return playerBehavior.idleState;
    }
}
