using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerAbilityState
{
    public override PlayerBaseState DoState(PlayerStateMachine playerBehavior)
    {
        PlayerBaseState parentCheck = base.DoState(playerBehavior);
        if (parentCheck != playerBehavior.abilityState) return parentCheck;

        //Animation
        if (playerBehavior.dashBehavior.canDash)
            playerBehavior.playerData.anim.SetTrigger("Dash");

        //Stay in dash state for the duration of the dash
        if (playerBehavior.dashBehavior.IsDashing())
        {
            return playerBehavior.dashState;
        }

        isAbilityDone = true;

        return base.DoState(playerBehavior);
    }
}
