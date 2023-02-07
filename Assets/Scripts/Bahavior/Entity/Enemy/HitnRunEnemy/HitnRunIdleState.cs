using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitnRunIdleState : IHitnRunState
{
    private float detectRadius = 5f;
    public IHitnRunState DoState(HitnRunStateMachine hitnRunStateMachine)
    {
        if(Physics2D.OverlapCircle(hitnRunStateMachine.transform.position, detectRadius, hitnRunStateMachine.playerLayer) == true)
        {
            return hitnRunStateMachine.chaseState;
        }      
        return hitnRunStateMachine.idleState;
    }

}
