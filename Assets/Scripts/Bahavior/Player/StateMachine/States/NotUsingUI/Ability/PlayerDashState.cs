using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerAbilityState
{
    public override PlayerBaseState DoState(PlayerStateMachine playerBehavior)
    {
        PlayerBaseState parentCheck = base.DoState(playerBehavior);
        if (parentCheck != playerBehavior.abilityState)
        {
            playerBehavior.dashBehavior.dashInput.SetTrigger(false);
            return parentCheck;
        }

        //Dash Animation
        //if (playerBehavior.dashBehavior.triggerDash)

        Debug.LogError("A");

        playerBehavior.dashBehavior.dashInput.SetTrigger(true);
        playerBehavior.dashBehavior.Dashing();
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
