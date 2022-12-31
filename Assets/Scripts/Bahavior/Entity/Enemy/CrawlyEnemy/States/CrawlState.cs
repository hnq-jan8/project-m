using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrawlState : CrawlAbstractState
{
    float crawlTime = 0.5f;
    float restTime = 0.5f;
    public CrawlAbstractState DoState(EnemyCrawlBehavior crawlBehavior)
    {
        if (crawlBehavior.IsGrounded() == true && crawlBehavior.IsFacingWall() == false)
        {
            //Move and rest
            crawlTime -= Time.deltaTime;
            if (crawlTime <= 0)   //time is up
            {
                //restTime = 0.5f;
                restTime -= Time.deltaTime;
                if (restTime <= 0)
                {
                    crawlTime = 0.5f;
                    restTime = 0.5f;
                }
                else
                {
                    crawlBehavior.sideMove.StopMove();
                }
            }
            else
            {
                //crawlBehavior.sideMove.moveInput.UpdateInput();
                crawlBehavior.sideMove.Move();
                crawlBehavior.flip.DoFlipByInput(crawlBehavior.sideMove.input);
            }
            Debug.LogError("a");
            return crawlBehavior.crawlState;
        }
        else
        {
            crawlBehavior.sideMove.moveInput.UpdateInput();
            crawlBehavior.sideMove.Move();  //For updating the input of SideMove
            Debug.LogError(crawlBehavior.sideMove.input);
            crawlBehavior.flip.DoFlipByInput(crawlBehavior.sideMove.input);
            crawlBehavior.sideMove.StopMove();
            return crawlBehavior.idleState;
        }
    }
}
