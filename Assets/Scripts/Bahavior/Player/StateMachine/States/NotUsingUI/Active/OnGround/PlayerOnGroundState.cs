using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnGroundState : PlayerActiveState
{
    public override PlayerBaseState DoState(PlayerStateMachine playerBehavior)
    {
        PlayerBaseState parentCheck = base.DoState(playerBehavior);
        if (parentCheck != playerBehavior.activeState) return parentCheck;

        //If trigger attack -> PlayerAttackState
        if (playerBehavior.playerData.IsGrounded() == false)
        {
            return playerBehavior.onAirState;
        }

        //Debug.Log("On ground");
        return playerBehavior.onGroundState;
    }
}
