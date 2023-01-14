using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState_HnR : IHnR
{
    public IHnR DoState(HnRBehavior HnRBehavior)
    {
        //HnRBehavior.dash.TriggerDash();
        Debug.Log("??i b? mày");
        return HnRBehavior.chaseState;
    }
}
