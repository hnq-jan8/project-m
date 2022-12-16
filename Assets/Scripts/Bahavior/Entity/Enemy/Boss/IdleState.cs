using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IBossState
{
    //Stay in this state until boss fight is activated -> IntroState
    public IBossState DoState(BossBehavior boss)
    {
        if(boss.FightIsActivated() == false)
        {
            //Debug.Log("Idling");
            return boss.idleState;
        }
        else
        {
            return boss.introState;
        }
    }
}
