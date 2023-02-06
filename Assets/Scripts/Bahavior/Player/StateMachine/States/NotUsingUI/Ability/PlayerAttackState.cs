using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerAbilityState
{
    public override PlayerBaseState DoState(PlayerStateMachine playerBehavior)
    {
        PlayerBaseState parentCheck = base.DoState(playerBehavior);
        if (parentCheck != playerBehavior.abilityState) return parentCheck;

        //Fall Animation
        if (playerBehavior.playerData.IsGrounded() == false)
            playerBehavior.playerData.anim.SetTrigger("falling");

        isAbilityDone = true;

        return base.DoState(playerBehavior);
    }
}
