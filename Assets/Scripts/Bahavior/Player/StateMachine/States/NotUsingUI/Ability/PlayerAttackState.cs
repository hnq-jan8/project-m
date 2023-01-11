using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Not done
public class PlayerAttackState : PlayerAbilityState
{
    public override PlayerBaseState DoState(PlayerStateMachine playerBehavior)
    {
        base.DoState(playerBehavior);
        return playerBehavior.attackState;
    }
}
