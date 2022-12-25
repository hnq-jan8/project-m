using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroState : Stage1State
{
    //Stay in this state for 2s -> RoarState
    public override IBossState DoState(BossBehavior boss)
    {
        float time = boss.CountTimeInState();
        if (time <= 2)
        {
            //Debug.Log("Intro");
            return boss.introState;
        }
        else
        {
            boss.ResetTimeInState();
            return boss.roarState;
        }
    }
}
