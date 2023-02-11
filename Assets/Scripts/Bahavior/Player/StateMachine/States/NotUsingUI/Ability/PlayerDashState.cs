using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerAbilityState
{
    float dashTime = 0.18f;
    float currentDashTime = 0f;
    float xScale = 1f;
    float yScale = 1f;
    float sizeY1 = 1f;
    float sizeY2 = 0.6f;
    float sizeX1 = 1f;
    float sizeX2 = 1.5f;

    bool dashed = false;
    public override PlayerBaseState DoState(PlayerStateMachine playerBehavior)
    {
        var dustEmission = playerBehavior.GetDashParticle().emission;
        var windEmission = playerBehavior.GetDashWind().emission;

        PlayerBaseState parentCheck = base.DoState(playerBehavior);
        if (parentCheck != playerBehavior.abilityState)
        {
            yScale = sizeY1;
            playerBehavior.GetDashSelf().localScale = new Vector3(sizeX1, yScale, 1);
            currentDashTime = 0f;
            //playerBehavior.playerMovementData.spriteObject.transform.localRotation = new Quaternion(0, 0, 0, 1);

            dustEmission.rateOverTime = 0;
            windEmission.rateOverTime = 0;

            playerBehavior.playerMovementData.anim.SetBool("Dashing", false);
            dashed = false;

            //playerBehavior.GetDashParticle().SetActive(false);
            return parentCheck;
        }

        playerBehavior.dashBehavior.dashInput.TriggerDash();
        playerBehavior.dashBehavior.Dashing();

        /*if (playerBehavior.dashBehavior.triggerDash && dashed == false)
        {
            playerBehavior.playerMovementData.anim.SetBool("Dashing", true);
            dashed = true;
        }
        else
        {

        }*/

        //Stay in dash state for the duration of the dash
        if (playerBehavior.dashBehavior.IsDashing())
        {
            if(dashed == false)
            {
                playerBehavior.playerMovementData.anim.SetBool("Dashing", true);
                dashed = true;
            }
            else
            {
                playerBehavior.playerMovementData.anim.SetBool("Dashing", false);
            }

            //playerBehavior.playerMovementData.spriteObject.transform.localRotation = new Quaternion(0, 45, 0, 1);
            if (playerBehavior.playerMovementData.FacingWall() == false)
            {
                currentDashTime += Time.deltaTime;
                if(currentDashTime <= dashTime/2)
                {
                    //yScale = -0.26f * (currentDashTime / dashTime) + 0.2017644f;
                    xScale = 2 * (sizeX1 - sizeX2) * (currentDashTime / dashTime) + sizeX2;
                    yScale = 2 * (sizeY2 - sizeY1) * (currentDashTime / dashTime) + sizeY1;
                    
                }
                else if(currentDashTime <= dashTime)
                {
                    //yScale = 0.26f * ((currentDashTime - dashTime / 2) / dashTime) + 0.07f;
                    xScale = 2 * (sizeX2 - sizeX1) * ((currentDashTime - dashTime / 2) / dashTime) + sizeX1;
                    yScale = 2 * (sizeY1 - sizeY2) * ((currentDashTime - dashTime / 2) / dashTime) + sizeY2;
                }

                playerBehavior.GetDashSelf().localScale = new Vector3(sizeX2, yScale, 1);

                dustEmission.rateOverTime = 150;
            }
            windEmission.rateOverTime = 150;
            //playerBehavior.GetDashParticle().SetActive(true);
            //playerBehavior.playerMovementData.anim.SetTrigger("Dash");

            return playerBehavior.dashState;
        }

        //Fall Animation
        if (playerBehavior.playerMovementData.IsGrounded() == false)
            playerBehavior.playerMovementData.anim.SetTrigger("falling");

        isAbilityDone = true;

        yScale = sizeY1;
        playerBehavior.GetDashSelf().localScale = new Vector3(sizeX1, yScale, 1);
        currentDashTime = 0f;
        //playerBehavior.playerMovementData.spriteObject.transform.localRotation = new Quaternion(0, 0, 0, 1);

        dustEmission.rateOverTime = 0;
        windEmission.rateOverTime = 0;

        playerBehavior.playerMovementData.anim.SetBool("Dashing", false);
        dashed = false;

        //playerBehavior.GetDashParticle().SetActive(false);
        return base.DoState(playerBehavior);
    }
}
