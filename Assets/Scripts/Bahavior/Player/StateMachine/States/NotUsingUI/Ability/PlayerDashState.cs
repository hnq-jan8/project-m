using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Not done
public class PlayerDashState : PlayerAbilityState
{
    public override PlayerBaseState DoState(PlayerStateMachine playerBehavior)
    {
        base.DoState(playerBehavior);
        return playerBehavior.dashState;
    }
}
