using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerAbilityState
{
    public override PlayerBaseState DoState(PlayerStateMachine playerBehavior)
    {
        PlayerBaseState parentCheck = base.DoState(playerBehavior);
        if (parentCheck != playerBehavior.abilityState) return parentCheck;

        //Dash Animation
        if (playerBehavior.dashBehavior.triggerDash)
            playerBehavior.playerData.anim.SetTrigger("Dash");

        //Stay in dash state for the duration of the dash
        if (playerBehavior.dashBehavior.IsDashing())
        {
            return playerBehavior.dashState;
        }

        //Fall Animation
        if (playerBehavior.playerData.IsGrounded() == false)
            playerBehavior.playerData.anim.SetTrigger("falling");

        isAbilityDone = true;

        return base.DoState(playerBehavior);
    }
}
