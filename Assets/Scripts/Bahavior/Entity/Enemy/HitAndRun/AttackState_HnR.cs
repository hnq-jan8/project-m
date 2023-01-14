using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState_HnR : IHnR
{
    float timeInState = 2f;
    public IHnR DoState(HnRBehavior HnRBehavior)
    {
        //trigger attack animation
        timeInState -= Time.deltaTime;
        if(timeInState <= 0)
        {
            return HnRBehavior.runState;
        }
        else
        {
            Debug.LogError("djtcumay");
            return HnRBehavior.attackState;
        }
    }
}
