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
            if (playerBehavior.dashBehavior.IsDashing() == false)
            {
                playerBehavior.sideMoveBehavior.StopMove();
            }
            return playerBehavior.usingUIState;
        }

        if (playerBehavior.playerMovementData.IsGrounded() == false)
        {
            return playerBehavior.onAirState;
        }

        return playerBehavior.idleState;
    }
}
