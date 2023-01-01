using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManusianStage1State : IBossState
{
    public virtual IBossState DoState(BossBehavior boss)
    {
        if(boss.health <= 5)
        {
            return boss.stage2State;
        }
        else
        {
            //Debug.Log("In State 1");
            return boss.stage1State;
        }
    }
}
