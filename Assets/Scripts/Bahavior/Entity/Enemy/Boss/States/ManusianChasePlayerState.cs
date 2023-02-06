using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManusianChasePlayerState : ManusianStage1State
{
    float range = 3f;
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
            boss.flip.DoFlipByTargetPosition(boss.playerTarget);

            boss.sideMove.moveInput.UpdateInput();
            boss.sideMove.Move();
            //boss.sideMove.DoFlip();
            //boss.flip.DoFlipByInput(boss.sideMove.input);
            boss.anim.SetBool("chase", true);

            //Debug.Log("Chase state");
            return boss.chasePlayerState;
        }
    }
}
