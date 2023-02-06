using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerAbilityState
{
    public override PlayerBaseState DoState(PlayerStateMachine playerBehavior)
    {
        PlayerBaseState parentCheck = base.DoState(playerBehavior);
        if (parentCheck != playerBehavior.abilityState) return parentCheck;

        playerBehavior.jumpBehavior.jumpInput.TriggerJump();
        playerBehavior.jumpBehavior.Jumping();

        if (playerBehavior.playerData.IsGrounded() || playerBehavior.jumpBehavior.airJump)
            playerBehavior.playerData.anim.SetTrigger("takeOff");

        isAbilityDone = true;

        return playerBehavior.jumpState;

        //Debug.LogError("Change state to: " + base.DoState(playerBehavior));
        //return base.DoState(playerBehavior);
    }
}
