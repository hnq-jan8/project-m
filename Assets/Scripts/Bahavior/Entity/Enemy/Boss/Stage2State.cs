using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2State : IBossState
{
    public IBossState DoState(BossBehavior boss)
    {
        //Debug.Log("Stage 2");
        return boss.stage2State;
    }
}
