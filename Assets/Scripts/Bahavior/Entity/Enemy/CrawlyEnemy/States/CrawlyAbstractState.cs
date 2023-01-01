using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface CrawlAbstractState
{
    CrawlAbstractState DoState(EnemyCrawlBehavior crawlBehavior);
}
