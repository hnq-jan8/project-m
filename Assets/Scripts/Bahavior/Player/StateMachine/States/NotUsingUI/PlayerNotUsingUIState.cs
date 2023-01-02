using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNotUsingUIState : PlayerBaseState
{
    public virtual PlayerBaseState DoState(PlayerStateMachine playerBehavior)
    {
        if (UIManager.playerIsUsingUI == true)
        {
            return playerBehavior.usingUIState;
        }
        return playerBehavior.notUsingUIState;
    }
}