using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerAbilityState
{
    public override PlayerBaseState DoState(PlayerStateMachine playerBehavior)
    {
        PlayerBaseState parentCheck = base.DoState(playerBehavior);
        if (parentCheck != playerBehavior.abilityState) return parentCheck;

        playerBehavior.dashBehavior.dashInput.TriggerDash();
        playerBehavior.dashBehavior.Dashing();

        //Dash Animation
        if (playerBehavior.dashBehavior.triggerDash)
            playerBehavior.playerMovementData.anim.SetTrigger("Dash");

        //Stay in dash state for the duration of the dash
        if (playerBehavior.dashBehavior.IsDashing())
        {
            return playerBehavior.dashState;
        }

        //Fall Animation
        if (playerBehavior.playerMovementData.IsGrounded() == false)
            playerBehavior.playerMovementData.anim.SetTrigger("falling");

        isAbilityDone = true;

        return base.DoState(playerBehavior);
    }
}
