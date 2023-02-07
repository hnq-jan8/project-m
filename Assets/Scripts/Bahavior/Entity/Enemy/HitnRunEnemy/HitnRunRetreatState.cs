using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitnRunRetreatState : IHitnRunState
{
    public IHitnRunState DoState(HitnRunStateMachine hitnRunStateMachine)
    {
        //trigger dash backwards
        if (hitnRunStateMachine.dashBehavior.IsDashing())
        {
            return hitnRunStateMachine.retreatState;
        }
        return hitnRunStateMachine.chaseState;
    }
}
