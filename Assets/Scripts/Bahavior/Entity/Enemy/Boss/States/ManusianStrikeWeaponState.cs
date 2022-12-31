using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManusianStrikeWeaponState : ManusianStage1State
{
    //bool striked = false;
    public override IBossState DoState(BossBehavior boss)
    {
        if(boss.animationEventHandler.finishedAction == true)
        {
            //Debug.Log("Striked");
            //striked = false;
            boss.anim.SetBool("strike", false);
            boss.animationEventHandler.ResetAction();
            return boss.idleState;
        }
        else
        {
            //boss.anim.SetTrigger("strike");
            //boss.sideMove.StopMove();
            boss.anim.SetBool("strike", true);
            //striked = true;
        }
        //Debug.Log("Strike State");
        return boss.strikeWeaponState;
    }
}
