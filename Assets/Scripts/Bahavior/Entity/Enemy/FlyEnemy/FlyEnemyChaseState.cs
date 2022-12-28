using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemyChaseState : AbstractState
{
    float chaseRange = 10f;
    float speed = 3f;

    public AbstractState DoState(FlyEnemyBehavior flyBehavior)
    {
        if (Physics2D.OverlapCircle(flyBehavior.transform.position, chaseRange, flyBehavior.playerLayer))
        {
            flyBehavior.rb.MovePosition(Vector2.MoveTowards(flyBehavior.transform.position, flyBehavior.player.transform.position, speed * Time.deltaTime));

            return flyBehavior.chaseState;
        }
        else
        {
            return flyBehavior.idleState;
        }
    }
}
