using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Done
public class PlayerNotUsingUIState : PlayerBaseState
{
    public virtual PlayerBaseState DoState(PlayerStateMachine playerBehavior)
    {
        if (UIManager.playerIsUsingUI == true)
        {
            return playerBehavior.usingUIState;
        }

        return playerBehavior.notUsingUIState;

        #region remove
        /*//Run
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            return playerBehavior.groundRunState;
        }

        //On air
        if (playerBehavior.playerData.IsGrounded() != true)
        {
            return playerBehavior.onAirState;
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            //playerBehavior.jumpBehavior.Jumping();
            playerBehavior.jumpBehavior.jumpInput.TriggerJump();
            playerBehavior.jumpBehavior.Jumping();

            playerBehavior.playerData.anim.SetTrigger("takeOff");

            return playerBehavior.onAirState;
        }

        //On ground
        if (playerBehavior.playerData.IsGrounded() == true)
        {
            return playerBehavior.onGroundState;
        }*/
        #endregion
    }
}