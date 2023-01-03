using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnWallState : PlayerNotUsingUIState
{
    public override PlayerBaseState DoState(PlayerStateMachine playerBehavior)
    {
        base.DoState(playerBehavior);
        return playerBehavior.wallSlideState;
    }
}
