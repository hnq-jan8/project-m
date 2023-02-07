using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitnRunChaseState : IHitnRunState
{
    private float attackRange = 2f;
    private float chaseRange = 9f;

    public IHitnRunState DoState(HitnRunStateMachine hitnRunStateMachine)
    {
        if(Physics2D.OverlapCircle(hitnRunStateMachine.transform.position, chaseRange,hitnRunStateMachine.playerLayer) == true)
        {
            if (Physics2D.OverlapCircle(hitnRunStateMachine.transform.position, attackRange, hitnRunStateMachine.playerLayer) == true)
            {
                return hitnRunStateMachine.attackState;
            }
            hitnRunStateMachine.flipBehavior.DoFlipByTargetPosition(hitnRunStateMachine.playerPosition);

            hitnRunStateMachine.sideMoveBehavior.moveInput.UpdateInput();
            hitnRunStateMachine.sideMoveBehavior.Move();

            return hitnRunStateMachine.chaseState;
        }
        return hitnRunStateMachine.idleState;
    }


}
