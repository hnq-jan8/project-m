using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitnRunChaseState : IHitnRunState
{
    private float attackRange = 1f;
    private float chaseRange = 8f;

    public IHitnRunState DoState(HitnRunStateMachine hitnRunStateMachine)
    {
        if (Physics2D.OverlapCircle(hitnRunStateMachine.transform.position, attackRange, hitnRunStateMachine.playerLayer) == true)
        {
            /*Debug.Log("Attack");*/
            hitnRunStateMachine.flipBehavior.DoFlipByTargetPosition(hitnRunStateMachine.playerPosition);
            hitnRunStateMachine.movementData.anim.SetBool("Chase", false);
            return hitnRunStateMachine.attackState;
        }

        if(Physics2D.OverlapCircle(hitnRunStateMachine.transform.position, chaseRange, hitnRunStateMachine.playerLayer) == true)
        {
            /*Debug.Log("Chase");*/
            hitnRunStateMachine.flipBehavior.DoFlipByTargetPosition(hitnRunStateMachine.playerPosition);

            hitnRunStateMachine.sideMoveBehavior.moveInput.UpdateInput();
            hitnRunStateMachine.sideMoveBehavior.Move();

            hitnRunStateMachine.movementData.anim.SetBool("Chase", true);

            return hitnRunStateMachine.chaseState;
        }

        /*Debug.Log("Idle");*/
        hitnRunStateMachine.movementData.anim.SetBool("Chase", false);
        return hitnRunStateMachine.idleState;
    }


}
