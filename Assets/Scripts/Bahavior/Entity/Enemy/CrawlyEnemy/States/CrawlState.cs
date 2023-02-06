using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrawlState : CrawlAbstractState
{
    float crawlTime = 1.3f;
    float restTime = 1.7f;
    public CrawlAbstractState DoState(EnemyCrawlBehavior crawlBehavior)
    {
        if (crawlBehavior.IsGrounded() == true && crawlBehavior.IsFacingWall() == false)
        {
            crawlBehavior.anim.SetBool("Crawl", true);

            //Move and rest
            crawlTime -= Time.deltaTime;
            if (crawlTime <= 0)   //time is up
            {
                //restTime = 0.5f;
                restTime -= Time.deltaTime;
                if (restTime <= 0)
                {
                    crawlTime = 1.3f;
                    restTime = 1.7f;
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
                //crawlBehavior.flip.DoFlipByInput(crawlBehavior.sideMove.input);
            }
            //Debug.LogError("a");
            return crawlBehavior.crawlState;
        }
        else
        {
            crawlTime = 1.3f;
            restTime = 1.7f;

            crawlBehavior.sideMove.moveInput.UpdateInput();
            crawlBehavior.sideMove.Move();  //For updating the input of SideMove
            //Debug.LogError(crawlBehavior.sideMove.input);
            crawlBehavior.flip.DoFlipByInput(crawlBehavior.sideMove.input);
            crawlBehavior.sideMove.StopMove();

            crawlBehavior.anim.SetBool("Crawl", false);

            return crawlBehavior.idleState;
        }
    }
}
