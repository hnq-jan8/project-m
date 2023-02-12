using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManusianIntroState : ManusianStage1State
{
    //Stay in this state for 2s -> RoarState
    public override IBossState DoState(BossBehavior boss)
    {
        float time = boss.CountTimeInState();
        if (time <= 2)
        {
            //Debug.Log("Intro");
            CheckPointManager.instance.UpdateCheckPoint("Scene7");
            return boss.introState;
        }
        else
        {
            boss.ResetTimeInState();
            return boss.roarState;
        }
    }
}
