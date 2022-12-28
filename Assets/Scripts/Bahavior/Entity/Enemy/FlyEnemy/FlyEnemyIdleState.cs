using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemyIdleState : AbstractState
{
    //public Transform playerCheck;
    public float detectRange = 3f;
    //public LayerMask player;

    public AbstractState DoState(FlyEnemyBehavior flyBehavior)
    {
        if (Physics2D.OverlapCircle(flyBehavior.transform.position, detectRange, flyBehavior.playerLayer) == true)
        {
            return flyBehavior.detectState;
        }
        else
        {
            return flyBehavior.idleState;
        }
    }
}
