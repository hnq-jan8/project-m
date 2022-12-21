using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayerState : Stage1State
{
    float range = 2f;
    public override IBossState DoState(BossBehavior boss)
    {
        if (Physics2D.OverlapCircle(boss.transform.position, range, boss.playerLayer))
        {
            //boss.sideMove.StopChasing();
            boss.sideMove.StopMove();
            boss.anim.SetBool("chase", false);
            return boss.strikeWeaponState;
        }
        else
        {
            boss.sideMove.moveInput.UpdateInput();
            boss.sideMove.Move();
            boss.sideMove.DoFlip();
            boss.anim.SetBool("chase", true);

            //Debug.Log("Chase state");
            return boss.chasePlayerState;
        }
    }
}
