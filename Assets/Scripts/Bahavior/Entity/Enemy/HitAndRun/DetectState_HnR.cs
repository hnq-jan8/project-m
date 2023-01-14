using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectState_HnR : IHnR
{
    float timeInState = 1f;
    IHnR IHnR.DoState(HnRBehavior HnRBehavior)
    {
        if(HnRBehavior.anim != null)
        {
            HnRBehavior.anim.SetTrigger("detected");
            return this;
        }
        else
        {
            timeInState -= Time.deltaTime;
            if(timeInState <= 0f)
            {
                timeInState = 1f;
                return HnRBehavior.chaseState;
            }
            else
            {
                return HnRBehavior.detectState;
            }
        }

    }
}
