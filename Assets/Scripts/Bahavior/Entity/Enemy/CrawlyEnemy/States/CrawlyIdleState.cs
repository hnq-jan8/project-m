using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrawlyIdleState : CrawlAbstractState
{
    float timeIdle = 2.5f;
    public CrawlAbstractState DoState(EnemyCrawlBehavior crawlBehavior)
    {
        //Debug.LogError("Idle state " + timeIdle);
        /*if (crawlBehavior.anim != null)
        {
            //crawlBehavior.anim.Play("Crawly Idle");
            return this;
        }
        else
        {
            
        }*/

        timeIdle -= Time.deltaTime;
        if (timeIdle <= 0)   //time is up
        {
            //Debug.Log("Move to crawl state");
            timeIdle = 2.5f;
            
            return crawlBehavior.crawlState;
        }
        else
        {
            return crawlBehavior.idleState;
        }
    }
}
