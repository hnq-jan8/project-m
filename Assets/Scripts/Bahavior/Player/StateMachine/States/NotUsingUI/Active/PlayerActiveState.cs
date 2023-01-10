using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActiveState : PlayerNotUsingUIState
{
    public override PlayerBaseState DoState(PlayerStateMachine playerBehavior)
    {
        base.DoState(playerBehavior);
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            return playerBehavior.runState;
        }

        return playerBehavior.activeState;
    }
}
