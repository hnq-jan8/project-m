using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState_HnR : IHnR
{
    float chaseRange = 5f;
    float attackRange = 3f;
    float speed = 5f;
    public IHnR DoState(HnRBehavior HnRBehavior)
    {
        if (Physics2D.OverlapCircle(HnRBehavior.transform.position, chaseRange,HnRBehavior.playerLayer) == true)
        {
            if (Physics2D.OverlapCircle(HnRBehavior.transform.position, attackRange, HnRBehavior.playerLayer) == true)
            {
                HnRBehavior.move.StopMove();
                return HnRBehavior.attackState;
            }
            else
            {
                HnRBehavior.flip.DoFlipByTargetPosition(HnRBehavior.player.transform);

                HnRBehavior.move.moveInput.UpdateInput();
                HnRBehavior.move.Move();
                //boss.sideMove.DoFlip();
                //boss.flip.DoFlipByInput(boss.sideMove.input);
                //HnRBehavior.anim.SetBool("chase", true);

                return HnRBehavior.chaseState;
            }
        }
        return HnRBehavior.idleState;       
    }
}
