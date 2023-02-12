using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitnRunAttackState : IHitnRunState
{
    //this is the duration of the attack animation
    private float timeInState = 0.75f;
    public IHitnRunState DoState(HitnRunStateMachine hitnRunStateMachine)
    {
        //play attack animation
        timeInState -= Time.deltaTime;
        if(timeInState <= 0)
        {
            //reset time in state
            timeInState = 0.75f;
            hitnRunStateMachine.movementData.anim.SetBool("Attack", false);
            return hitnRunStateMachine.retreatState;
        }
        hitnRunStateMachine.movementData.anim.SetBool("Attack", true);
        return hitnRunStateMachine.attackState;
    }
}