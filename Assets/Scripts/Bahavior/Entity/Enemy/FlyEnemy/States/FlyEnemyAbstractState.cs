using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface FlyAbstractState
{
    FlyAbstractState DoState(FlyEnemyBehavior flyBehavior);
}