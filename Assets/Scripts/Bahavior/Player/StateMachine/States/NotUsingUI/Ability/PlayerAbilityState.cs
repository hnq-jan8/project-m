using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Done
public class PlayerAbilityState : PlayerNotUsingUIState
{
    public static bool isAbilityDone = false;

    public override PlayerBaseState DoState(PlayerStateMachine playerBehavior)
    {
        PlayerBaseState parentCheck = base.DoState(playerBehavior);
        if (parentCheck != playerBehavior.notUsingUIState) return parentCheck;

        if (isAbilityDone == true)
        {
            isAbilityDone = false;
            if (playerBehavior.playerData.IsGrounded() == true)
            {
                return playerBehavior.onGroundState;    //This line is never called
            }
            if (playerBehavior.playerData.IsGrounded() == false)
            {
                return playerBehavior.onAirState;       //This line is never called
            }
        }
        //Debug.Log("");
        return playerBehavior.abilityState;
    }
}
