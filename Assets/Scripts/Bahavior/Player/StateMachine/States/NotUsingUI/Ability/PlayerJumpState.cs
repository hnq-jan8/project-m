using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Done
public class PlayerJumpState : PlayerAbilityState
{
    public override PlayerBaseState DoState(PlayerStateMachine playerBehavior)
    {
        PlayerBaseState parentCheck = base.DoState(playerBehavior);
        if (parentCheck != playerBehavior.abilityState) return parentCheck;
        //Debug.LogError("Jump success");

        playerBehavior.jumpBehavior.jumpInput.TriggerJump();
        playerBehavior.jumpBehavior.Jumping();
        isAbilityDone = true;

        return playerBehavior.jumpState;

        //Debug.LogError("Change state to: " + base.DoState(playerBehavior));
        //return base.DoState(playerBehavior);
    }
}
