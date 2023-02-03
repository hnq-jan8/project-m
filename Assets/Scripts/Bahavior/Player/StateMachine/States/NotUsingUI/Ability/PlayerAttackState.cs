using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Not done
public class PlayerAttackState : PlayerAbilityState
{
    public override PlayerBaseState DoState(PlayerStateMachine playerBehavior)
    {
        PlayerBaseState parentCheck = base.DoState(playerBehavior);
        if (parentCheck != playerBehavior.abilityState) return parentCheck;


        isAbilityDone = true;

        return base.DoState(playerBehavior);
    }
}
