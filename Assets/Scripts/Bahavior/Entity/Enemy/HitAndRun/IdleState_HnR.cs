using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState_HnR : IHnR
{
    public float detectRange = 10f;

    public IHnR DoState(HnRBehavior HnRBehavior)
    {
        if (Physics2D.OverlapCircle(HnRBehavior.transform.position,detectRange,HnRBehavior.playerLayer) == true)
        {
            return HnRBehavior.detectState;
        }
        else
        {
            return HnRBehavior.idleState;
        }
    }
}
