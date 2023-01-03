using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerNotUsingUIState
{
    public override PlayerBaseState DoState(PlayerStateMachine playerBehavior)
    {
        base.DoState(playerBehavior);
        return this;
    }
}
