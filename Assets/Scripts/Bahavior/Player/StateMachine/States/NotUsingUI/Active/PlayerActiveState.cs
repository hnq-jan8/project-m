using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActiveState : PlayerNotUsingUIState
{
    private KeyCode jumpInput = KeyCode.K;
    private KeyCode dashInput = KeyCode.L;
    private KeyCode attackInput = KeyCode.J;

    public override PlayerBaseState DoState(PlayerStateMachine playerBehavior)
    {
        //Debug.LogError("A");
        //If the parent state says that the next frame isn't itself then return whatever state it says
        PlayerBaseState parentCheck = base.DoState(playerBehavior);
        if (parentCheck != playerBehavior.notUsingUIState) return parentCheck;

        if (Input.GetKeyDown(dashInput))
        {
            return playerBehavior.dashState;
        }
        if (Input.GetKeyDown(jumpInput) && !playerBehavior.dashBehavior.IsDashing())
        {
            return playerBehavior.jumpState;
        }
        if (Input.GetKeyDown(attackInput))
        {
            return playerBehavior.attackState;
        }

        return playerBehavior.activeState;
    }
}
