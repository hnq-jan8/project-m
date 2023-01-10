using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnGroundState : PlayerActiveState
{
    public override PlayerBaseState DoState(PlayerStateMachine playerBehavior)
    {
        base.DoState(playerBehavior);

        //If trigger attack -> PlayerAttackState
        if (playerBehavior.playerData.IsGrounded() == false)
        {
            return playerBehavior.onAirState;
        }

        //Debug.Log("On ground");
        return playerBehavior.onGroundState;
    }
}
