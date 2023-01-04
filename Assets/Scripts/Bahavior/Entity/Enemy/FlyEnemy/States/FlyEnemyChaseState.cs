using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemyChaseState : FlyAbstractState
{
    float chaseRange = 10f;
    //float speed = 3f;

    public FlyAbstractState DoState(FlyEnemyBehavior flyBehavior)
    {
        if (Physics2D.OverlapCircle(flyBehavior.transform.position, chaseRange, flyBehavior.playerLayer))
        {
            //flyBehavior.rb.MovePosition(Vector2.MoveTowards(flyBehavior.transform.position, flyBehavior.player.transform.position, speed * Time.deltaTime));

            flyBehavior.flip.DoFlipByTargetPosition(flyBehavior.player.transform);

            flyBehavior.fly.FlyTowardsTarget();

            Debug.Log("chase");
            
            return flyBehavior.chaseState;
        }
        else
        {
            Debug.Log("idle");
            return flyBehavior.idleState;
        }
    }
}
