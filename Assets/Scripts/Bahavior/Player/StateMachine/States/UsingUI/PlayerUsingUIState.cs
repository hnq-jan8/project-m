using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//If player dont use UI -> PlayerNotUsingUIState
public class PlayerUsingUIState : PlayerBaseState
{
    public PlayerBaseState DoState(PlayerStateMachine playerBehavior)
    {
        if (UIManager.playerIsUsingUI == true)
        {
            return playerBehavior.usingUIState;
        }
        return playerBehavior.notUsingUIState;
    }
}
