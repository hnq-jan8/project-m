using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemyDetectState : AbstractState
{
    float timeInState = 1f;


    public AbstractState DoState(FlyEnemyBehavior flyBehavior)
    {
        if (flyBehavior.anim != null)
        {
            flyBehavior.anim.SetTrigger("detected");    //Play player detected animation

            //If finished animation then return chase state

            return this;
        }
        else
        {
            timeInState -= Time.deltaTime;      //Decrease variable by time

            if (timeInState <= 0f)       //time is up
            {
                return flyBehavior.chaseState;
            }
            else
            {
                return flyBehavior.detectState;
            }
        }
    }
}
